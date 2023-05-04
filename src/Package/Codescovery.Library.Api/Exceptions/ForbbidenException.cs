namespace Codescovery.Library.Api.Exceptions;

public class ForbbidenException : Exception
{
    private const string DefaultMessage = "You are not authorized to access this resource";
    private const string DefaultMessageWithResource = "You are not authorized to access the resource {0}";
    public ForbbidenException() : base(DefaultMessage) { }
    public ForbbidenException(Exception innerException) : base(DefaultMessage,innerException) { }
    public ForbbidenException(string resource) : base(string.Format(DefaultMessageWithResource, resource)) { }

    public ForbbidenException(string? resource, Exception innerException) : base(string.Format(DefaultMessage, resource), innerException) { }
}