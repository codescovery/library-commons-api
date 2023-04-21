using Codescovery.Library.Api.Abstractions;
using Codescovery.Library.Api.Handlers;
using Codescovery.Library.Api.Interfaces;
using Codescovery.Library.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;


namespace Codescovery.Library.Api.Extensions;

public  static class ResultHandlerExtensions
{
    public static IServiceCollection AddDefaultResultsHandler(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        services.Add<IResultsHandlers, DefaultResultsHandlers>(lifetime);
        return services;
    }

    public static IServiceCollection AddResultsHandler<T>(this IServiceCollection services,
        ServiceLifetime lifetime = ServiceLifetime.Scoped)
        where T : BaseResultsHandlers,IResultsHandlers  
    {
        services.Add<IResultsHandlers, T>(lifetime);
        return services;
    }
    public static IServiceCollection AddResultHandler<T>(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        where T : class, IResultHandler
    {
        services.Add<IResultHandler, T>(serviceLifetime);
        return services;
    }
    public static IServiceCollection AddResultHandlers(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped, params Type[] handlers)
    {
        foreach (var handler in handlers)
        {
            if (handler.GetInterfaces().Contains(typeof(IResultHandler)))
                services.Add(new ServiceDescriptor(typeof(IResultHandler), handler, serviceLifetime));
        }
        return services;
    }
}