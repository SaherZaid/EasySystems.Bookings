using EasySystems.Bookings.Data.Identity;

namespace EasySystems.Bookings.Data.Entities;

public class BusinessUser
{
    public int Id { get; set; }

    public int BusinessId { get; set; }

    public string UserId { get; set; } = string.Empty;

    public string Role { get; set; } = AppRoles.Staff;

    public bool CanManageServices { get; set; }

    public bool CanManageStaff { get; set; }

    public bool CanManageBookings { get; set; }

    public bool CanManageCalendar { get; set; }

    public bool CanManageSettings { get; set; }
    public bool CanManageLegal { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Business Business { get; set; } = default!;

    public ApplicationUser User { get; set; } = default!;
}