using Codescovery.Library.Api.Handlers;
using Codescovery.Library.Api.Interfaces;
using Codescovery.Library.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ExceptionHandlerMiddleware = Codescovery.Library.Api.Middlewares.ExceptionHandlerMiddleware;

namespace Codescovery.Library.Api.Extensions;

public static class ExceptionHandlerMiddlewareExtensions
{

    public static IServiceCollection AddDefaultExceptionHandlerMiddleware<T>(this IServiceCollection services,
        Func<IServiceProvider, IEnumerable<IRequestExceptionHandler>>? requestsExceptionHandlersFactory = null,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped) where T : class, IExceptionHandlerMiddleware<T>
    {
        services.AddExceptionHandlerMiddleware<ExceptionHandlerMiddleware>(requestsExceptionHandlersFactory, serviceLifetime);
        return services;
    }
    public static IServiceCollection AddExceptionHandlerMiddleware<T>(this IServiceCollection services,
        Func<IServiceProvider, IEnumerable<IRequestExceptionHandler>>? requestsExceptionHandlersFactory = null,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped) 
        where T : class, IExceptionHandlerMiddleware<T>
    {
        var handlers = requestsExceptionHandlersFactory?.Invoke(services.BuildServiceProvider());
        if (handlers != null)
            services.Add<IRequestsExceptionHandlers>(new RequestsExceptionHandlers(handlers), serviceLifetime);
        services.Add<IExceptionHandlerMiddleware<T>, T>();
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
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app, IWebHostEnvironment env, Action<IApplicationBuilder,IWebHostEnvironment>? configureDelegate=null)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider.GetServices<ExceptionHandlerMiddleware>();
        var hasExceptionHandler = services.Any();
        if (!hasExceptionHandler) throw new  NullReferenceException("No IExceptionHandlerMiddleware found");
        app.UseMiddleware<ExceptionHandlerMiddleware>();
        configureDelegate?.Invoke(app, env);
        return app;
    }
    /// <summary>
    /// Add ExceptionHandlerMiddleware to the application pipeline with the specified <see cref="IExceptionHandlerMiddleware{T}"/> type.
    /// This method should be the top most middleware in the pipeline, else it will not be able to catch exceptions from other middlewares.
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public static IApplicationBuilder UseExceptionHandling<T>(this IApplicationBuilder app, IWebHostEnvironment env, Action<IApplicationBuilder, IWebHostEnvironment>? configureDelegate = null)
        where T : class, IExceptionHandlerMiddleware<T>
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider.GetServices<T>();
        var hasExceptionHandler = services.Any();
        if (!hasExceptionHandler) return app;
        app.UseMiddleware<T>();
        configureDelegate?.Invoke(app, env);
        return app;
    }
}