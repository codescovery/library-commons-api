using Microsoft.AspNetCore.Http;
using System.Net;

namespace Codescovery.Library.Api.Interfaces;

public interface IRequestExceptionHandler
{
    bool CanHandle(Exception exception);
    Task HandleExceptionAsync(HttpContext context, Exception exception, CancellationToken cancellationToken = default);
    HttpStatusCode StatusCodeFromExceptionType(Exception exception);
}