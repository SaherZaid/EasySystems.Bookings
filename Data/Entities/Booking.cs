using System.ComponentModel.DataAnnotations;

namespace EasySystems.Bookings.Data.Entities;

public class Booking
{
    public int Id { get; set; }

    public int BusinessId { get; set; }

    public int ServiceId { get; set; }

    public int StaffMemberId { get; set; }

    [Required]
    [MaxLength(150)]
    public string CustomerName { get; set; } = string.Empty;

    [MaxLength(150)]
    [EmailAddress]
    public string? CustomerEmail { get; set; }

    [MaxLength(30)]
    public string? CustomerPhone { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    [MaxLength(50)]
    public string Status { get; set; } = "Pending";

    [MaxLength(1000)]
    public string? Notes { get; set; }

    public bool IsPaid { get; set; }

    public decimal PaidAmount { get; set; }

    [MaxLength(100)]
    public string? PaymentMethod { get; set; }

    [MaxLength(100)]
    public string? CancellationReason { get; set; }

    public bool CustomerNotified { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public Business Business { get; set; } = default!;

    public Service Service { get; set; } = default!;

    public StaffMember StaffMember { get; set; } = default!;
}