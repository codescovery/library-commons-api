using Codescovery.Library.Api.Handlers;
using Codescovery.Library.Api.Interfaces;

namespace Codescovery.Library.Api.Abstractions;

public abstract class BaseResponseHandlers:IResponseHandlers
{
    protected BaseResponseHandlers(IEnumerable<IResponseHandler> handlers)
    {
        Handlers = handlers;
    }


        

    public virtual IEnumerable<IResponseHandler>? Handlers { get; }
    public virtual IResponseHandler GetHandler<T>(T? result = default)
    {
        var handler = Handlers?.FirstOrDefault(handler => handler.GetType() == typeof(T));
        return handler ?? new NoHandlerCanHandleTypeHandler();
    }

    public virtual IResponseHandler GetFirstThatCanHandle<T>(T? result = default)
    {
        var handler = Handlers?.FirstOrDefault(handler => handler.CanHandle(result));
        return handler ?? new NoHandlerCanHandleTypeHandler();
    }

    public virtual IEnumerable<IResponseHandler> GetHandlersThatCanHandle<T>(T? result = default)
    {
        return Handlers?.Where(handler => handler.CanHandle(result)) ?? Enumerable.Empty<IResponseHandler>();
    }

    public virtual bool HasHandlers()
    {
        return Handlers != null && Handlers.Any();
    }

    public virtual bool HasAnyHandlerThatCanHandle<T>(T? result = default)
    {
        return Handlers?.Any(handler => handler.CanHandle(result)) ?? false;
    }
}