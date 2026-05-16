namespace EasySystems.Bookings.Services;

public interface IEmailQueue
{
    Task QueueEmailAsync(string toEmail, string subject, string htmlBody);
}