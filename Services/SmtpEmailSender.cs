using EasySystems.Bookings.Data;
using EasySystems.Bookings.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.Encodings.Web;

namespace EasySystems.Bookings.Services;

public class EmailSettings
{
    public string Host { get; set; } = "";
    public int Port { get; set; } = 587;
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string DisplayName { get; set; } = "EasySystems";
    public bool EnableSsl { get; set; } = true;
    public string CompanyName { get; set; } = "EasySystems";
}

public class SmtpEmailSender : IEmailSender<ApplicationUser>
{
    private readonly EmailSettings _settings;
    private readonly HtmlEncoder _htmlEncoder;
    private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;

    public SmtpEmailSender(
        IOptions<EmailSettings> options,
        HtmlEncoder htmlEncoder,
        IDbContextFactory<ApplicationDbContext> dbFactory)
    {
        _settings = options.Value;
        _htmlEncoder = htmlEncoder;
        _dbFactory = dbFactory;
    }

    public async Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
    {
        var businessName = await GetBusinessNameAsync(user.Id);
        var safeLink = _htmlEncoder.Encode(confirmationLink);

        await SendEmailAsync(
            toEmail: email,
            businessName: businessName,
            subject: $"Confirm your email | {businessName}",
            preHeader: $"Welcome to {businessName}, powered by {_settings.CompanyName}.",
            title: "Welcome, your booking account is ready",
            message: $"""
            We are happy to welcome you to <strong>{Encode(businessName)}</strong>.
            Please confirm your email to activate your account and securely manage your bookings.
            """,
            buttonText: "Confirm email",
            buttonUrl: safeLink,
            footerNote: $"This email was sent by {_settings.CompanyName} for {businessName}."
        );
    }

    public async Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
    {
        var businessName = await GetBusinessNameAsync(user.Id);
        var safeLink = _htmlEncoder.Encode(resetLink);

        await SendEmailAsync(
            toEmail: email,
            businessName: businessName,
            subject: $"Reset your password | {businessName}",
            preHeader: $"Password reset request for your {businessName} account.",
            title: "Reset your password",
            message: $"""
            We received a request to reset the password for your <strong>{Encode(businessName)}</strong> account.
            Click the button below to create a new secure password.
            """,
            buttonText: "Reset password",
            buttonUrl: safeLink,
            footerNote: "If you did not request this, you can safely ignore this email."
        );
    }

    public async Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
    {
        var businessName = await GetBusinessNameAsync(user.Id);

        await SendEmailAsync(
            toEmail: email,
            businessName: businessName,
            subject: $"Your reset code | {businessName}",
            preHeader: $"Use this code to reset your {businessName} password.",
            title: "Your password reset code",
            message: """
            Use the code below to continue resetting your password.
            For your security, do not share this code with anyone.
            """,
            code: resetCode,
            footerNote: $"Powered by {_settings.CompanyName}."
        );
    }

    private async Task<string> GetBusinessNameAsync(string userId)
    {
        await using var db = await _dbFactory.CreateDbContextAsync();

        var businessName = await db.Set<BusinessUser>()
            .AsNoTracking()
            .Where(x => x.UserId == userId && x.Business.IsActive)
            .OrderBy(x => x.Id)
            .Select(x => x.Business.Name)
            .FirstOrDefaultAsync();

        return string.IsNullOrWhiteSpace(businessName)
            ? "your booking account"
            : businessName;
    }

    private async Task SendEmailAsync(
        string toEmail,
        string businessName,
        string subject,
        string preHeader,
        string title,
        string message,
        string? buttonText = null,
        string? buttonUrl = null,
        string? code = null,
        string? footerNote = null)
    {
        ValidateSettings();

        var htmlBody = BuildHtmlTemplate(
            businessName,
            preHeader,
            title,
            message,
            buttonText,
            buttonUrl,
            code,
            footerNote
        );

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
            AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html)
        );

        using var smtpClient = new SmtpClient(_settings.Host, _settings.Port)
        {
            EnableSsl = _settings.EnableSsl,
            Credentials = new NetworkCredential(_settings.Email, _settings.Password)
        };

        await smtpClient.SendMailAsync(mailMessage);
    }

    private string BuildHtmlTemplate(
        string businessName,
        string preHeader,
        string title,
        string message,
        string? buttonText,
        string? buttonUrl,
        string? code,
        string? footerNote)
    {
        var companyName = Encode(_settings.CompanyName);
        var safeBusinessName = Encode(businessName);

        var buttonHtml = !string.IsNullOrWhiteSpace(buttonText) && !string.IsNullOrWhiteSpace(buttonUrl)
            ? $"""
              <tr>
                <td align="center" style="padding: 30px 0 10px;">
                  <a href="{buttonUrl}"
                     style="display:inline-block;background:#111827;color:#ffffff;text-decoration:none;
                            padding:15px 30px;border-radius:999px;font-weight:800;font-size:15px;
                            box-shadow:0 14px 34px rgba(17,24,39,.24);">
                    {Encode(buttonText)}
                  </a>
                </td>
              </tr>
              """
            : "";

        var codeHtml = !string.IsNullOrWhiteSpace(code)
            ? $"""
              <tr>
                <td align="center" style="padding: 28px 0 12px;">
                  <div style="display:inline-block;letter-spacing:8px;background:#f3f4f6;color:#111827;
                              padding:18px 26px;border-radius:20px;font-size:30px;font-weight:900;
                              border:1px solid #e5e7eb;">
                    {Encode(code)}
                  </div>
                </td>
              </tr>
              """
            : "";

        return $$"""
        <!doctype html>
        <html lang="en">
        <head>
          <meta charset="utf-8">
          <meta name="viewport" content="width=device-width, initial-scale=1">
          <title>{{Encode(title)}}</title>
        </head>

        <body style="margin:0;padding:0;background:#f6f2ec;font-family:Arial,Helvetica,sans-serif;color:#111827;">
          <div style="display:none;max-height:0;overflow:hidden;opacity:0;">
            {{Encode(preHeader)}}
          </div>

          <table role="presentation" width="100%" cellpadding="0" cellspacing="0" style="background:#f6f2ec;padding:38px 16px;">
            <tr>
              <td align="center">
                <table role="presentation" width="100%" cellpadding="0" cellspacing="0"
                       style="max-width:660px;background:#ffffff;border-radius:34px;overflow:hidden;
                              box-shadow:0 28px 80px rgba(17,24,39,.14);">

                  <tr>
                    <td style="background:linear-gradient(135deg,#111827,#2f3542,#6b5b4f);padding:38px 36px;color:#ffffff;">
                      <div style="font-size:12px;text-transform:uppercase;letter-spacing:2.4px;opacity:.78;font-weight:700;">
                        {{companyName}}
                      </div>

                      <div style="font-size:32px;font-weight:900;margin-top:10px;line-height:1.2;">
                        {{safeBusinessName}}
                      </div>

                      <div style="font-size:14px;margin-top:10px;opacity:.82;">
                        Smart online bookings, beautifully managed.
                      </div>
                    </td>
                  </tr>

                  <tr>
                    <td style="padding:40px 36px 18px;">
                      <h1 style="margin:0;font-size:29px;line-height:1.25;color:#111827;">
                        {{Encode(title)}}
                      </h1>

                      <div style="margin-top:18px;font-size:16px;line-height:1.8;color:#4b5563;">
                        {{message}}
                      </div>
                    </td>
                  </tr>

                  {{buttonHtml}}
                  {{codeHtml}}

                  <tr>
                    <td style="padding:28px 36px 38px;">
                      <div style="border-top:1px solid #eeeeee;padding-top:22px;font-size:13px;line-height:1.7;color:#6b7280;">
                        {{Encode(footerNote ?? $"Sent by {_settings.CompanyName} for {businessName}.")}}
                      </div>
                    </td>
                  </tr>

                </table>

                <div style="font-size:12px;color:#9ca3af;margin-top:18px;">
                  © {{DateTime.Now.Year}} {{companyName}}. Built for modern service businesses.
                </div>
              </td>
            </tr>
          </table>
        </body>
        </html>
        """;
    }

    private string Encode(string value)
    {
        return _htmlEncoder.Encode(value ?? "");
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