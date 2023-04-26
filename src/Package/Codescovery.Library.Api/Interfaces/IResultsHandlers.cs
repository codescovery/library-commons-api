namespace Codescovery.Library.Api.Interfaces;

public interface IResultsHandlers
{
    IEnumerable<IResultHandler>? Handlers { get; }
    IResultHandler GetHandler<T>(T? result = default);

    IResultHandler GetFirstThatCanHandle<T>(T? result = default);
    IEnumerable<IResultHandler> GetHandlersThatCanHandle<T>(T? result = default);
    bool HasHandlers();
    bool HasAnyHandlerThatCanHandle<T>(T? result = default);

}