using Codescovery.Library.Api.Interfaces;
using Microsoft.Extensions.Logging;

namespace Codescovery.Library.Api.Abstractions;

public class BaseApiControllerWithResultHandler<TController> : BaseApiController<TController> where TController : BaseApiController<TController>
{
    public IResultsHandlers ResultsHandlers { get; }

    public BaseApiControllerWithResultHandler(IResultsHandlers resultsHandlers, ILogger<TController> logger) : base(logger)
    {
        ResultsHandlers = resultsHandlers;
    }

}