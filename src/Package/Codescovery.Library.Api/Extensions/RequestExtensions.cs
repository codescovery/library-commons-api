using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.Extensions.Primitives;

namespace Codescovery.Library.Api.Extensions;

public static class RequestExtensions
{
    public static string? GetValueFromHeader(this HttpRequest request,string headerName,string? defaultValue=default, bool throwExceptionIfNotFound = false)
    {
        var valueFound = request.Headers.TryGetValue(headerName, out var value);

        if (valueFound) return value.FirstOrDefault();
        if(throwExceptionIfNotFound) throw new ArgumentOutOfRangeException($"{headerName} not found");
        return defaultValue;

    }
    public static string? GetValueFromHeader(this HttpRequest request, string headerName, StringValues? defaultValue = default, bool throwExceptionIfNotFound = false)
    {
        var valueFound = request.Headers.TryGetValue(headerName, out var value);

        if (valueFound) return value;
        if (throwExceptionIfNotFound) throw new ArgumentOutOfRangeException($"{headerName} not found");
        return defaultValue;

    }

    /// <summary>
    /// Gets the request body as a string. if encoding is not specified, UTF8 is used.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returns the raw body string with the provided encoding, which if is not provided UTF8 will be used</returns>
    public static Task<string> BodyAsString(this HttpRequest request, Encoding? encoding = null, CancellationToken cancellationToken = default)
    {
        var persistedEncoding = encoding ?? Encoding.UTF8;
        using var reader = new StreamReader(request.Body, persistedEncoding);
        return reader.ReadToEndAsync(cancellationToken);
    }

    public static Task<string> BodyAsString(this HttpContext context, Encoding? encoding = null, CancellationToken cancellationToken = default)
    {
        return context.Request.BodyAsString(encoding, cancellationToken);
    }
    public static string? GetValueFromHeader(this HttpContext context, string headerName, string? defaultValue = default, bool throwExceptionIfNotFound = false)
    {
        return context.Request.GetValueFromHeader(headerName,defaultValue,throwExceptionIfNotFound);
    }
}