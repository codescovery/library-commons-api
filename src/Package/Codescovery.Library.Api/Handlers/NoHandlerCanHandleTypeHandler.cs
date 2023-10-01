using System.Net;
using Codescovery.Library.Api.Extensions;
using Codescovery.Library.Api.Interfaces;
using Codescovery.Library.Commons.Interfaces.Result;
using Microsoft.AspNetCore.Mvc;

namespace Codescovery.Library.Api.Handlers;

internal class NoHandlerCanHandleTypeHandler:IResponseHandler,IResponseResultHandler
{
    public bool CanHandle<T>(T? result = default)
    {
        return true;
    }

    public  Task<IActionResult> HandleResponseAsync<T>(T? entity = default, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new ObjectResult($"There isn't a handler that can handle result type {typeof(T).Name}")
        {
            StatusCode = HttpStatusCode.InternalServerError.ToInt()
        } as IActionResult);
    }

    public bool CanHandle<T>(IResult<T>? result = default)
    {
        return true;
    }

    public Task<IActionResult> HandleResponseAsync<T>(IResult<T>? entity = default, CancellationToken cancellationToken = default) where T : class
    {
        return Task.FromResult(new ObjectResult($"There isn't a handler that can handle result type {typeof(T).Name}")
        {
            StatusCode = HttpStatusCode.InternalServerError.ToInt()
        } as IActionResult);
    }
}