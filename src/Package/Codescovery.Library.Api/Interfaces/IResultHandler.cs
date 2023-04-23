using Microsoft.AspNetCore.Mvc;

namespace Codescovery.Library.Api.Interfaces;

public interface IResultHandler
{
    bool CanHandle<T>(T? result=default);
    Task<IActionResult> HandleResultAsync<T>(T? entity=default, CancellationToken cancellationToken = default);
}