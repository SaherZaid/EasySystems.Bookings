using EasySystems.Bookings.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace EasySystems.Bookings.Services;

public class EmailOutboxWorker : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly EmailSettings _settings;
    private readonly ILogger<EmailOutboxWorker> _logger;

    public EmailOutboxWorker(
        IServiceScopeFactory scopeFactory,
        IOptions<EmailSettings> options,
        ILogger<EmailOutboxWorker> logger)
    {
        _scopeFactory = scopeFactory;
        _settings = options.Value;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await ProcessEmailsAsync(stoppingToken);
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }

    private async Task ProcessEmailsAsync(CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();

        var dbFactory = scope.ServiceProvider
            .GetRequiredService<IDbContextFactory<ApplicationDbContext>>();

        await using var db = await dbFactory.CreateDbContextAsync(cancellationToken);

        var emails = await db.EmailOutbox
            .Where(x => x.Status == "Pending" || x.Status == "Failed")
            .Where(x => x.Attempts < 5)
            .OrderBy(x => x.CreatedAt)
            .Take(10)
            .ToListAsync(cancellationToken);

        foreach (var email in emails)
        {
            try
            {
                email.Attempts++;
                email.LastAttemptAt = DateTime.UtcNow;

                await SendRawEmailAsync(
                    email.ToEmail,
                    email.Subject,
                    email.HtmlBody,
                    cancellationToken);

                email.Status = "Sent";
                email.SentAt = DateTime.UtcNow;
                email.LastError = null;
            }
            catch (Exception ex)
            {
                email.Status = "Failed";
                email.LastError = ex.Message;

                _logger.LogError(
                    ex,
                    "Failed to send queued email {EmailId} to {ToEmail}",
                    email.Id,
                    email.ToEmail);
            }
        }

        await db.SaveChangesAsync(cancellationToken);
    }

    private async Task SendRawEmailAsync(
        string toEmail,
        string subject,
        string htmlBody,
        CancellationToken cancellationToken)
    {
        ValidateSettings();

        using var mailMessage = new MailMessage
        {
            From = new MailAddress(_settings.Email, _settings.DisplayName),
            Subject = subject,
            Body = htmlBody,
            IsBodyHtml = true,
            BodyEncoding = System.Text.Encoding.UTF8,
            SubjectEncoding = System.Text.Encoding.UTF8
        };

        mailMessage.To.Add(toEmail);

        mailMessage.AlternateViews.Add(
            AlternateView.CreateAlternateViewFromString(
                htmlBody,
                null,
                MediaTypeNames.Text.Html));

        using var smtpClient = new SmtpClient(_settings.Host, _settings.Port)
        {
            EnableSsl = _settings.EnableSsl,
            Credentials = new NetworkCredential(_settings.Email, _settings.Password)
        };

        await smtpClient.SendMailAsync(mailMessage, cancellationToken);
    }

    private void ValidateSettings()
    {
        if (string.IsNullOrWhiteSpace(_settings.Host))
            throw new InvalidOperationException("EmailSettings:Host is missing.");

        if (string.IsNullOrWhiteSpace(_settings.Email))
            throw new InvalidOperationException("EmailSettings:Email is missing.");

        if (string.IsNullOrWhiteSpace(_settings.Password))
            throw new InvalidOperationException("EmailSettings:Password is missing.");
    }
}