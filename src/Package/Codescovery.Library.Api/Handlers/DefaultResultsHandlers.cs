using Codescovery.Library.Api.Abstractions;
using Codescovery.Library.Api.Interfaces;

namespace Codescovery.Library.Api.Handlers;

internal class DefaultResultsHandlers:BaseResultsHandlers
{
    public DefaultResultsHandlers(IEnumerable<IResultHandler> handlers) : base(handlers)
    {
    }
    
}