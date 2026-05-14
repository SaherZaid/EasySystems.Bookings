using System.Security.Claims;
using EasySystems.Bookings.Data.Identity;
using Microsoft.EntityFrameworkCore;

namespace EasySystems.Bookings.Data.Access;

public class BusinessAccessService
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;

    public BusinessAccessService(IDbContextFactory<ApplicationDbContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<BusinessPermissionResult> GetPermissionsAsync(
        ClaimsPrincipal user,
        int businessId)
    {
        if (user.Identity?.IsAuthenticated != true)
            return new BusinessPermissionResult();

        if (user.IsInRole(AppRoles.PlatformSuperAdmin))
        {
            return new BusinessPermissionResult
            {
                HasAccess = true,
                IsPlatformSuperAdmin = true,
                Role = AppRoles.PlatformSuperAdmin,
                CanManageServices = true,
                CanManageStaff = true,
                CanManageBookings = true,
                CanManageCalendar = true,
                CanManageSettings = true
            };
        }

        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrWhiteSpace(userId))
            return new BusinessPermissionResult();

        await using var db = await _dbFactory.CreateDbContextAsync();

        var businessUser = await db.BusinessUsers
            .AsNoTracking()
            .FirstOrDefaultAsync(x =>
                x.BusinessId == businessId &&
                x.UserId == userId);

        if (businessUser is null)
            return new BusinessPermissionResult();

        return new BusinessPermissionResult
        {
            HasAccess = true,
            Role = businessUser.Role,
            CanManageServices = businessUser.CanManageServices,
            CanManageStaff = businessUser.CanManageStaff,
            CanManageBookings = businessUser.CanManageBookings,
            CanManageCalendar = businessUser.CanManageCalendar,
            CanManageSettings = businessUser.CanManageSettings
        };
    }
}