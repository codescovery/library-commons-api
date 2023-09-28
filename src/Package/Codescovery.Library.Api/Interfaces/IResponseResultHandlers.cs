using Codescovery.Library.Commons.Interfaces.Result;

namespace Codescovery.Library.Api.Interfaces;

public interface IResponseResultHandlers
{
    IEnumerable<IResponseResultHandler>? Handlers { get; }
    IResponseResultHandler GetHandler<T>(IResult<T>? result = default);

    IResponseResultHandler GetFirstThatCanHandle<T>(IResult<T>? result = default);
    IEnumerable<IResponseResultHandler> GetHandlersThatCanHandle<T>(IResult<T>? result = default);
    bool HasHandlers();
    bool HasAnyHandlerThatCanHandle<T>(IResult<T>? result = default);

}