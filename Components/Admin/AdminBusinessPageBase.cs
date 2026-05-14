using System.Security.Claims;
using EasySystems.Bookings.Data.Access;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace EasySystems.Bookings.Components.Admin;

public abstract class AdminBusinessPageBase : ComponentBase
{
    [Inject]
    protected AuthenticationStateProvider AuthStateProvider { get; set; } = default!;

    [Inject]
    protected BusinessAccessService BusinessAccessService { get; set; } = default!;

    [Inject]
    protected NavigationManager Navigation { get; set; } = default!;

    [Parameter]
    public int BusinessId { get; set; }

    protected BusinessPermissionResult Permissions { get; set; } = new();

    protected ClaimsPrincipal User { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthStateProvider.GetAuthenticationStateAsync();

        User = authState.User;

        if (User.Identity?.IsAuthenticated != true)
        {
            Navigation.NavigateTo("/Account/Login", forceLoad: true);
            return;
        }

        Permissions = await BusinessAccessService
            .GetPermissionsAsync(User, BusinessId);

        if (!Permissions.HasAccess)
        {
            Navigation.NavigateTo("/Account/AccessDenied", forceLoad: true);
        }
    }
}