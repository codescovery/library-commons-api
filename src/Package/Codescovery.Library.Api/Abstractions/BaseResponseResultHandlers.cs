using Codescovery.Library.Api.Handlers;
using Codescovery.Library.Api.Interfaces;
using Codescovery.Library.Commons.Interfaces.Result;

namespace Codescovery.Library.Api.Abstractions;

public abstract class BaseResponseResultHandlers : IResponseResultHandlers
{
    protected BaseResponseResultHandlers(IEnumerable<IResponseResultHandler> handlers)
    {
        Handlers = handlers;
    }

    public virtual IEnumerable<IResponseResultHandler>? Handlers { get; }
    public virtual IResponseResultHandler GetHandler<T>(IResult<T>? result = default)
    {
        var handler = Handlers?.FirstOrDefault(handler => handler.GetType() == typeof(T));
        return handler ?? new NoHandlerCanHandleTypeHandler();
    }

    public virtual IResponseResultHandler GetFirstThatCanHandle<T>(IResult<T>? result = default)
    {
        var handler = Handlers?.FirstOrDefault(handler => handler.CanHandle(result));
        return handler ?? new NoHandlerCanHandleTypeHandler();
    }

    public virtual IEnumerable<IResponseResultHandler> GetHandlersThatCanHandle<T>(IResult<T>? result = default)
    {
        return Handlers?.Where(handler => handler.CanHandle(result)) ?? Enumerable.Empty<IResponseResultHandler>();
    }

    public virtual bool HasHandlers()
    {
        return Handlers != null && Handlers.Any();
    }

    public virtual bool HasAnyHandlerThatCanHandle<T>(IResult<T>? result = default)
    {
        return Handlers?.Any(handler => handler.CanHandle(result)) ?? false;
    }
}