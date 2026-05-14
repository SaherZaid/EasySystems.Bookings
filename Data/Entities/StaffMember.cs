using System.ComponentModel.DataAnnotations;

namespace EasySystems.Bookings.Data.Entities;

public class StaffMember
{
    public int Id { get; set; }

    public int BusinessId { get; set; }

    [Required]
    [MaxLength(150)]
    public string FullName { get; set; } = string.Empty;

    [MaxLength(150)]
    [EmailAddress]
    public string? Email { get; set; }

    [MaxLength(30)]
    public string? Phone { get; set; }

    [MaxLength(250)]
    public string? Specialization { get; set; }

    [MaxLength(500)]
    public string? Bio { get; set; }

    [MaxLength(500)]
    public string? ImageUrl { get; set; }

    public bool IsActive { get; set; } = true;

    public bool AllowOnlineBookings { get; set; } = true;

    public int SortOrder { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public Business Business { get; set; } = default!;

    public ICollection<Booking> Bookings { get; set; } = [];
}