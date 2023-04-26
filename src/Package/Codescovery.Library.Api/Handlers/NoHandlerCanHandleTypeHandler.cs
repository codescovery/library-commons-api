using System.Net;
using Codescovery.Library.Api.Extensions;
using Codescovery.Library.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Codescovery.Library.Api.Handlers;

internal class NoHandlerCanHandleTypeHandler:IResultHandler
{
    public bool CanHandle<T>(T? result = default)
    {
        return true;
    }

    public  Task<IActionResult> HandleResultAsync<T>(T? entity = default, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new ObjectResult($"There isn't a handler that can handle result type {typeof(T).Name}")
        {
            StatusCode = HttpStatusCode.InternalServerError.ToInt()
        } as IActionResult);
    }
}