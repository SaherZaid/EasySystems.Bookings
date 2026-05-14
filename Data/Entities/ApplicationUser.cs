using Microsoft.AspNetCore.Identity;

namespace EasySystems.Bookings.Data.Entities;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumberNormalized { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<BusinessUser> Businesses { get; set; } = [];
}