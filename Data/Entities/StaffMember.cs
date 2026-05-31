using System.ComponentModel.DataAnnotations;

namespace EasySystems.Bookings.Data.Entities;

public class StaffMember
{
    public int Id { get; set; }

    public int BusinessId { get; set; }

    [Required(ErrorMessage = "Fullständigt namn krävs.")]
    [MaxLength(150, ErrorMessage = "Namnet får vara max 150 tecken.")]
    public string FullName { get; set; } = string.Empty;

    [MaxLength(150, ErrorMessage = "E-post får vara max 150 tecken.")]
    [EmailAddress(ErrorMessage = "Ange en giltig e-postadress.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Telefonnummer krävs.")]
    [MaxLength(30, ErrorMessage = "Telefonnummer får vara max 30 tecken.")]
    [RegularExpression(@"^[0-9+\-\s()]{6,30}$", ErrorMessage = "Ange ett giltigt telefonnummer.")]
    public string Phone { get; set; } = string.Empty;

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