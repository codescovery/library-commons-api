namespace Codescovery.Library.Api.Exceptions;

public class NoHandlerCanHandleException:ApplicationException
{
    public const string MessageTemplate = "No handler can handle the request exception of type {0}";
    public Type ExceptionType { get;}
    public NoHandlerCanHandleException(Type exceptionType, Exception? innerException = null) : base(string.Format(MessageTemplate,exceptionType.FullName), innerException)
    {
        ExceptionType = exceptionType;
    }

}