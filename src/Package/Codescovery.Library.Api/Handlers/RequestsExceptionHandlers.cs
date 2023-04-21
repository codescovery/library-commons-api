using System.Collections;
using Codescovery.Library.Api.Interfaces;
namespace Codescovery.Library.Api.Handlers;
internal class RequestsExceptionHandlers : IRequestsExceptionHandlers
{
    private readonly IEnumerable<IRequestExceptionHandler> _handlers;

    public RequestsExceptionHandlers(IEnumerable<IRequestExceptionHandler> handlers)
    {
        _handlers = handlers;
    }
    public IEnumerator<IRequestExceptionHandler> GetEnumerator()
    {
        return _handlers.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}