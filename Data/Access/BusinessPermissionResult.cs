namespace EasySystems.Bookings.Data.Access;

public class BusinessPermissionResult
{
    public bool HasAccess { get; set; }

    public bool IsPlatformSuperAdmin { get; set; }

    public string Role { get; set; } = string.Empty;

    public bool CanManageServices { get; set; }

    public bool CanManageStaff { get; set; }

    public bool CanManageBookings { get; set; }

    public bool CanManageCalendar { get; set; }

    public bool CanManageSettings { get; set; }
}