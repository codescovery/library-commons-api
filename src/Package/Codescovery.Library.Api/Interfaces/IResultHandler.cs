using Microsoft.AspNetCore.Mvc;

namespace Codescovery.Library.Api.Interfaces;

public interface IResultHandler
{
    Task<bool> CanHandleAsync<T>(T? result=default);
    Task<IActionResult> HandleResultAsync<T>(T? entity=default, CancellationToken cancellationToken = default);
}