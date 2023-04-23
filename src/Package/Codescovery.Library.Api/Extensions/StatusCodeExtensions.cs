using System.Net;

namespace Codescovery.Library.Api.Extensions;

public static class StatusCodeExtensions
{
    public static HttpStatusCode ToHttpStatusCode(this int? code, HttpStatusCode defaultCode = HttpStatusCode.InternalServerError)
    {
        if (code == null) return defaultCode;
        return Enum.IsDefined(typeof(HttpStatusCode), code) ? (HttpStatusCode)code : defaultCode;
    }
    public static HttpStatusCode ToHttpStatusCode(this int code, HttpStatusCode defaultCode = HttpStatusCode.InternalServerError)
    {
        return Enum.IsDefined(typeof(HttpStatusCode), code) ? (HttpStatusCode)code : defaultCode;
    }
    public static int ToInt(this HttpStatusCode? code, int defaultCode = 500)
    {
        if (code == null) return defaultCode;
        return Enum.IsDefined(typeof(HttpStatusCode), code) ? (int)code : defaultCode;
    }
    public static int ToInt(this HttpStatusCode code, int defaultCode = 500)
    {
        return Enum.IsDefined(typeof(HttpStatusCode), code) ? (int)code : defaultCode;
    }
}