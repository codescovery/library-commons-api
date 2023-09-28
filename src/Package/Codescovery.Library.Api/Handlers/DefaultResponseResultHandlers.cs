using Codescovery.Library.Api.Abstractions;
using Codescovery.Library.Api.Interfaces;

namespace Codescovery.Library.Api.Handlers;

internal class DefaultResponseResultHandlers : BaseResponseResultHandlers
{
    public DefaultResponseResultHandlers(IEnumerable<IResponseResultHandler> handlers) : base(handlers)
    {
    }
    
}