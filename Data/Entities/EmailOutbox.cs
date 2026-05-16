namespace EasySystems.Bookings.Data.Entities;

public class EmailOutbox
{
    public int Id { get; set; }

    public string ToEmail { get; set; } = "";
    public string Subject { get; set; } = "";
    public string HtmlBody { get; set; } = "";

    public string Status { get; set; } = "Pending";

    public int Attempts { get; set; }

    public string? LastError { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? SentAt { get; set; }

    public DateTime? LastAttemptAt { get; set; }
}