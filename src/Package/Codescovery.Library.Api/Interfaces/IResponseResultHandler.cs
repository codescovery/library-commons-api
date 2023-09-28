using Codescovery.Library.Commons.Interfaces.Result;
using Microsoft.AspNetCore.Mvc;

namespace Codescovery.Library.Api.Interfaces;

public interface IResponseResultHandler
{
    bool CanHandle<T>(IResult<T>? result = default);
    Task<IActionResult> HandleResponseAsync<T>(IResult<T>? entity = default, CancellationToken cancellationToken = default);
}