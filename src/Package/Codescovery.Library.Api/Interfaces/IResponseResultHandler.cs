﻿using Codescovery.Library.Commons.Interfaces.Result;
using Microsoft.AspNetCore.Mvc;

namespace Codescovery.Library.Api.Interfaces;

public interface IResponseResultHandler:IResponseHandler
{
   new bool CanHandle<T>(T? result = default) where T: IResult<T>;
   new Task<IActionResult> HandleResponseAsync<T>(T? entity = default, CancellationToken cancellationToken = default) where T: IResult<T>;
}