using Codescovery.Library.Api.Exceptions;
using Codescovery.Library.Api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Codescovery.Library.Api.Middlewares;

internal class ExceptionHandlerMiddleware:IExceptionHandlerMiddleware<ExceptionHandlerMiddleware>
{
    public ILogger<ExceptionHandlerMiddleware>? Logger { get; }
    public IEnumerable<IRequestExceptionHandler>? Handlers { get; }


    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware>? logger=null, IEnumerable<IRequestExceptionHandler>? handlers=null)
    {
        Logger = logger;
        Handlers = handlers;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
           await next(context);
        }
        catch (Exception ex)
        {
            Logger?.LogError(ex, ex.Message);

            if (!HasHandlers()) throw;
            var handler = Handlers!.FirstOrDefault(x => x.CanHandle(ex));
            if (handler == null) throw new NoHandlerCanHandleException(ex.GetType(),ex);
            await handler.HandleExceptionAsync(context, ex);
        }
    }
    public bool HasHandlers()
    {
        return Handlers != null && Handlers.Any();
    }
}