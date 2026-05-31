using System.ComponentModel.DataAnnotations;

namespace EasySystems.Bookings.Data.Entities;

public class Service
{
    public int Id { get; set; }

    public int BusinessId { get; set; }

    [Required(ErrorMessage = "Tjänstens namn krävs.")]
    [MaxLength(150, ErrorMessage = "Namnet får vara max 150 tecken.")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500, ErrorMessage = "Beskrivningen får vara max 500 tecken.")]
    public string? Description { get; set; }

    [Range(0, 999999, ErrorMessage = "Priset kan inte vara negativt.")]
    public decimal Price { get; set; }

    [Range(1, 1440, ErrorMessage = "Tiden måste vara mellan 1 och 1440 minuter.")]
    public int DurationMinutes { get; set; }

    public bool IsActive { get; set; } = true;

    public int SortOrder { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public Business Business { get; set; } = default!;

    public ICollection<Booking> Bookings { get; set; } = [];
}