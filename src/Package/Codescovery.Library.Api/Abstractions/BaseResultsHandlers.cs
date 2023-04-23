using Codescovery.Library.Api.Interfaces;

namespace Codescovery.Library.Api.Abstractions;

public abstract class BaseResultsHandlers:IResultsHandlers
{
    protected BaseResultsHandlers(IEnumerable<IResultHandler> handlers)
    {
        Handlers = handlers;
    }


        

    public virtual IEnumerable<IResultHandler>? Handlers { get; }
    public virtual IResultHandler? GetHandler<T>(T? result = default)
    {
        return Handlers?.FirstOrDefault(handler => handler.GetType() == typeof(T));
    }

    public virtual IResultHandler? GetFirstThatCanHandle<T>(T? result = default)
    {
        return Handlers?.FirstOrDefault(handler => handler.CanHandle(result));
    }

    public virtual IEnumerable<IResultHandler> GetHandlersThatCanHandle<T>(T? result = default)
    {
        return Handlers?.Where(handler => handler.CanHandle(result)) ?? Enumerable.Empty<IResultHandler>();
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