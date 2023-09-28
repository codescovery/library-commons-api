using Codescovery.Library.Api.Abstractions;
using Codescovery.Library.Api.Handlers;
using Codescovery.Library.Api.Interfaces;
using Codescovery.Library.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;


namespace Codescovery.Library.Api.Extensions;

public  static class ResponseHandlerExtensions
{
    public static IServiceCollection AddDefaultResultsHandler(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        services.AddResponsesHandler<DefaultResponseHandlers>(lifetime);
        return services;
    }

    public static IServiceCollection AddResponsesHandler<T>(this IServiceCollection services,
        ServiceLifetime lifetime = ServiceLifetime.Scoped)
        where T : BaseResponseHandlers,IResponseHandlers  
    {
        services.Add<IResponseHandlers, T>(lifetime);
        return services;
    }
    public static IServiceCollection AddResponseHandler<T>(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        where T : class, IResponseHandler
    {
        services.Add<IResponseHandler, T>(serviceLifetime);
        return services;
    }
    public static IServiceCollection AddResponseHandlers(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped, params Type[] handlers)
    {
        foreach (var handler in handlers)
        {
            if (handler.GetInterfaces().Contains(typeof(IResponseHandler)))
                services.Add(new ServiceDescriptor(typeof(IResponseHandler), handler, serviceLifetime));
        }
        return services;
    }
}