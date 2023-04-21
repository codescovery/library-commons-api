using Codescovery.Library.Commons.Entities.Base64;
using Codescovery.Library.Commons.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Codescovery.Library.Api.Entities.ViewModels.Request.Filter;
using Codescovery.Library.Commons.Extensions;
using Microsoft.Extensions.Logging;
namespace Codescovery.Library.Api.Abstractions;
public abstract class BaseApiController<TController> : Controller 
where TController : BaseApiController<TController>
{
    public ILogger<TController>? Logger { get; }

    protected BaseApiController(ILogger<TController>? logger=null)
    {
        Logger = logger;
    }
    
    protected string? DecodeBase64(Base64Encoded? base64Encoded)
    {
        return base64Encoded;
    }

    protected Base64Encoded? DecodeBase64(Base64Decoded? base64Decoded)
    {
        return base64Decoded;
    }

    protected virtual T? Deserialize<T>(string? json, JsonSerializerOptions? options = null, bool throwExceptionOnError=false,T? defaultValue=null) where T : class
    {
        try
        {
            return json.IsNullOrEmptyOrWhiteSpace() ? null : JsonSerializer.Deserialize<T>(json!, options);
        }
        catch (Exception e)
        {
            var message = $"Error while deserializing json to {typeof(T).Name}";
            var newException = new CastingException(typeof(string), typeof(T), message, e);
            Logger?.LogError(newException, newException.Message);
            if (throwExceptionOnError)
                throw newException;
            return defaultValue;
        }
    }

    protected virtual string? Serialize<T>(T? obj, JsonSerializerOptions? options = null, bool throwExceptionOnError = false, string? defaultValue = null) where T : class
    {
        try
        {
            return obj == null ? null : JsonSerializer.Serialize(obj, options);
        }
        catch (Exception e)
        {
            var message = $"Error while serializing {typeof(T).Name} to json";
            var newException = new CastingException(typeof(T), typeof(string), message, e);
            Logger?.LogError(newException, newException.Message);
            if (throwExceptionOnError)
                throw newException;
            return defaultValue;
        }
    }

    protected virtual FilterRequest? GetFilterRequest(Base64Encoded? filterEncoded)
    {
        try
        {
            var filterDecoded = (Base64Decoded)filterEncoded;
            return ((string)filterDecoded).IsNullOrEmptyOrWhiteSpace()
                ? null
                : Deserialize<FilterRequest>(filterDecoded);

        }
        catch (Exception e)
        {
            throw new CastingException(typeof(FilterRequest), typeof(FilterRequest), $"Error while casting FilterRequest to Filter from base64 {filterEncoded}", e);
        }
    }
}
