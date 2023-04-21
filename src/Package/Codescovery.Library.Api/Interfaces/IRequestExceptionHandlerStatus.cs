namespace Codescovery.Library.Api.Interfaces;

public interface IRequestExceptionHandlerStatus
{
    bool Handled { get; }
    bool ReThrow { get; }
    void SetAsHandled();
    void SetAsReThrow();
    void SetAsUnhandled();
    
}