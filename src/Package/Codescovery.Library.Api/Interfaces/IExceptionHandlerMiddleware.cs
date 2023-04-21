using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Codescovery.Library.Api.Interfaces;

public interface IExceptionHandlerMiddleware<out T>:IMiddleware
{
    ILogger<T>? Logger { get;}
    IEnumerable<IRequestExceptionHandler>? Handlers { get; }
    bool HasHandlers();
}