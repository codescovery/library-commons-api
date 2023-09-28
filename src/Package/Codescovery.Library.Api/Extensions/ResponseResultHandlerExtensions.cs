using Codescovery.Library.Api.Abstractions;
using Codescovery.Library.Api.Handlers;
using Codescovery.Library.Api.Interfaces;
using Codescovery.Library.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;


namespace Codescovery.Library.Api.Extensions;

public  static class ResponseResponseResultHandlerExtensions
{
    public static IServiceCollection AddDefaultResponseResultsHandler(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        services.AddResponsesResultsHandler<DefaultResponseResultHandlers>(lifetime);
        return services;
    }

    public static IServiceCollection AddResponsesResultsHandler<T>(this IServiceCollection services,
        ServiceLifetime lifetime = ServiceLifetime.Scoped)
        where T : BaseResponseResultHandlers,IResponseResultHandlers  
    {
        services.Add<IResponseResultHandlers, T>(lifetime);
        return services;
    }
    public static IServiceCollection AddResponseResultHandler<T>(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        where T : class, IResponseResultHandler
    {
        services.Add<IResponseResultHandler, T>(serviceLifetime);
        return services;
    }
    public static IServiceCollection AddResponseResultHandlers(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped, params Type[] handlers)
    {
        foreach (var handler in handlers)
        {
            if (handler.GetInterfaces().Contains(typeof(IResponseResultHandler)))
                services.Add(new ServiceDescriptor(typeof(IResponseResultHandler), handler, serviceLifetime));
        }
        return services;
    }
}