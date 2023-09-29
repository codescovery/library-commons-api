using Codescovery.Library.Api.Interfaces;
using Microsoft.Extensions.Logging;

namespace Codescovery.Library.Api.Abstractions;

public abstract class BaseApiControllerWithResponsesHandler<TController>:BaseApiController<TController> where TController : BaseApiController<TController>
{
    public IResponseResultHandlers ResponseHandlers { get; }

    public BaseApiControllerWithResponsesHandler(IResponseResultHandlers responseHandlers, ILogger<TController> logger):base(logger)
    {
        ResponseHandlers = responseHandlers;
    }

}