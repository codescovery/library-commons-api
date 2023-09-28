using Codescovery.Library.Commons.Interfaces.Result;
using Microsoft.AspNetCore.Mvc;

namespace Codescovery.Library.Api.Interfaces;

public interface IResponseHandler
{
    bool CanHandle<T>(T? result = default);
    Task<IActionResult> HandleResponseAsync<T>(T? entity = default, CancellationToken cancellationToken = default);
}