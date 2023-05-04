using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Codescovery.Library.Api.Handlers;

internal class DefaultRolesPermissionsAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
    {
        if (context?.User == null || requirement?.AllowedRoles == null || !requirement.AllowedRoles.Any())
            return Task.CompletedTask;
        if (context.HasSucceeded) return Task.CompletedTask;
        if (!(context?.User?.Identity?.IsAuthenticated ?? false)) return Task.CompletedTask;

        var userRoles = context.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList();
        var isInAnyRequirementRole = requirement.AllowedRoles.Any(role =>
        {
            return userRoles.Any(userRole => userRole.Equals(role, StringComparison.InvariantCultureIgnoreCase));
        });

        if (isInAnyRequirementRole)
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}