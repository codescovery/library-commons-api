using Codescovery.Library.Api.Handlers;
using Codescovery.Library.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Codescovery.Library.Api.Extensions;

public static class AuthorizationExtensions
{
    public static IServiceCollection AddDefaultRolesPermissionsAuthorizationHandler(this IServiceCollection services,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    {
        services.AddRolesPermissionsAuthorizationHandler<DefaultRolesPermissionsAuthorizationHandler>(serviceLifetime);
        return services;
    }
    public static IServiceCollection AddRolesPermissionsAuthorizationHandler<T>(this IServiceCollection services,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    where T:class, IAuthorizationHandler

    {
        services.Add<IAuthorizationHandler, T>(serviceLifetime);
        return services;
    }
    public static IServiceCollection AddRolesPermissionsAuthorizationHandler(this IServiceCollection services, Func<IAuthorizationHandler> handlerFactory,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)

    {
        services.Add(handlerFactory.Invoke(), serviceLifetime);
        return services;
    }
}