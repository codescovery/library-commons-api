using Codescovery.Library.Api.Handlers;
using Codescovery.Library.Api.Interfaces;
using Codescovery.Library.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DefaultExceptionHandlerMiddleware = Codescovery.Library.Api.Middlewares.ExceptionHandlerMiddleware;

namespace Codescovery.Library.Api.Extensions;

public static class ExceptionHandlerMiddlewareExtensions
{
    public static IServiceCollection AddDefaultExceptionHandlerMiddleware(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    {
        services.AddExceptionHandlerMiddleware<DefaultExceptionHandlerMiddleware>(serviceLifetime);
        return services;
    }
    public static IServiceCollection AddExceptionHandlerMiddleware<T>(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        where T : class, IExceptionHandlerMiddleware<T>
    {
        services.Add<IExceptionHandlerMiddleware<T>, T>(serviceLifetime);
        return services;
    }
    public static IServiceCollection AddRequestExceptionHandler<T>(this IServiceCollection services,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    where T:class, IRequestExceptionHandler
    {
        services.Add<IRequestExceptionHandler,T >(serviceLifetime);
        return services;
    }
    public static IServiceCollection AddRequestsExceptionHandlers(this IServiceCollection services,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    {
        services.Add<IRequestsExceptionHandlers, RequestsExceptionHandlers>(serviceLifetime);
        return services;
    }
    /// <summary>
    /// Add ExceptionHandlerMiddleware to the application pipeline with the specified <see cref="IExceptionHandlerMiddleware{T}"/> type.
    /// This method should be the top most middleware in the pipeline, else it will not be able to catch exceptions from other middlewares.
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    /// <param name="configureDelegate"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public static IApplicationBuilder UseDefaultExceptionHandlerMiddleWare(this IApplicationBuilder app, IWebHostEnvironment env, Func<IApplicationBuilder,IWebHostEnvironment, IApplicationBuilder>? configureDelegate=null)
    {
        return app.UseExceptionHandlerMiddleware<DefaultExceptionHandlerMiddleware>(env, configureDelegate);
    }
    /// <summary>
    /// Add ExceptionHandlerMiddleware to the application pipeline with the specified <see cref="IExceptionHandlerMiddleware{T}"/> type.
    /// This method should be the top most middleware in the pipeline, else it will not be able to catch exceptions from other middlewares.
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public static IApplicationBuilder UseExceptionHandlerMiddleware<T>(this IApplicationBuilder app, IWebHostEnvironment env, Func<IApplicationBuilder, IWebHostEnvironment,IApplicationBuilder>? configureDelegate = null)
        where T : class, IExceptionHandlerMiddleware<T>
    {
        using var scope = app.ApplicationServices.CreateScope();
        var exceptionHandlerMiddleware = scope.ServiceProvider.GetService<IExceptionHandlerMiddleware<T>>();
        if (exceptionHandlerMiddleware == null)
            throw new NullReferenceException($"The {nameof(IExceptionHandlerMiddleware<T>)} is not registered in the service provider. Please register it using the {nameof(AddExceptionHandlerMiddleware)} or {nameof(AddDefaultExceptionHandlerMiddleware)} method.");


        var requestExceptionHandler = scope.ServiceProvider.GetServices<IRequestExceptionHandler>();
        var requestsExceptionHandlers = scope.ServiceProvider.GetService<IRequestsExceptionHandlers>();
        if ((requestsExceptionHandlers == null || !requestsExceptionHandlers.Any()) && (requestExceptionHandler.Any()))
            return configureDelegate?.Invoke(app, env) ?? app;
        app.UseMiddleware<IExceptionHandlerMiddleware<T>>();
        return configureDelegate?.Invoke(app, env) ?? app;
    }
}