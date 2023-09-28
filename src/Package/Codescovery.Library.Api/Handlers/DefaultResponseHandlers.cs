using Codescovery.Library.Api.Abstractions;
using Codescovery.Library.Api.Interfaces;

namespace Codescovery.Library.Api.Handlers;

internal class DefaultResponseHandlers:BaseResponseHandlers
{
    public DefaultResponseHandlers(IEnumerable<IResponseHandler> handlers) : base(handlers)
    {
    }
    
}