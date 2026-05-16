using EasySystems.Bookings.Data;
using EasySystems.Bookings.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasySystems.Bookings.Services;

public class EmailQueue : IEmailQueue
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;

    public EmailQueue(IDbContextFactory<ApplicationDbContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task QueueEmailAsync(string toEmail, string subject, string htmlBody)
    {
        if (string.IsNullOrWhiteSpace(toEmail))
            return;

        await using var db = await _dbFactory.CreateDbContextAsync();

        db.EmailOutbox.Add(new EmailOutbox
        {
            ToEmail = toEmail.Trim(),
            Subject = subject.Trim(),
            HtmlBody = htmlBody,
            Status = "Pending",
            CreatedAt = DateTime.UtcNow
        });

        await db.SaveChangesAsync();
    }
}