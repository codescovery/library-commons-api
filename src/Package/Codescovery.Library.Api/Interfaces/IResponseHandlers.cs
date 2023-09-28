namespace Codescovery.Library.Api.Interfaces;

public interface IResponseHandlers
{
    IEnumerable<IResponseHandler>? Handlers { get; }
    IResponseHandler GetHandler<T>(T? result = default);

    IResponseHandler GetFirstThatCanHandle<T>(T? result = default);
    IEnumerable<IResponseHandler> GetHandlersThatCanHandle<T>(T? result = default);
    bool HasHandlers();
    bool HasAnyHandlerThatCanHandle<T>(T? result = default);

}