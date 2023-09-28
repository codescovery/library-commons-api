using Codescovery.Library.Api.Interfaces;
using Microsoft.Extensions.Logging;

namespace Codescovery.Library.Api.Abstractions;

public class BaseApiControllerWithResultHandler<TController> : BaseApiController<TController> where TController : BaseApiController<TController>
{
    public IResponseHandlers ResponseHandlers { get; }

    public BaseApiControllerWithResultHandler(IResponseHandlers responseHandlers, ILogger<TController> logger) : base(logger)
    {
        ResponseHandlers = responseHandlers;
    }

}