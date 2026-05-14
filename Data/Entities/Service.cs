using System.ComponentModel.DataAnnotations;

namespace EasySystems.Bookings.Data.Entities;

public class Service
{
    public int Id { get; set; }

    public int BusinessId { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int DurationMinutes { get; set; }

    public bool IsActive { get; set; } = true;

    public int SortOrder { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public Business Business { get; set; } = default!;

    public ICollection<Booking> Bookings { get; set; } = [];
}