using System.Text.Json.Serialization;
using Codescovery.Library.Api.Constants;
using Microsoft.Extensions.Configuration;

namespace Codescovery.Library.Api.Entities.Configurations;

public class ApiConfiguration
{
    public ApiConfiguration()
    {
        UseCors = true;
        UseSwagger = true;
        UseHealthCheck = true;
        UseHttpContextAccessor = true;
        UseDefaultJsonSerializerOptions = true;
        UseControllers = true;
        UseHealthCheck = true;
        UseHttpsRedirection = true;
        Cors = new List<CorsConfiguration> ();
        Swagger = new SwaggerConfiguration();
    }
    public const string SectionName = nameof(ApiConfiguration);
    [JsonPropertyName("useCors")]
    [ConfigurationKeyName("useCors")]
    public bool UseCors { get; set; }
    [JsonPropertyName("useSwagger")]
    [ConfigurationKeyName("useSwagger")]
    public bool UseSwagger { get; set; }

    [JsonPropertyName("useHealthCheck")]
    [ConfigurationKeyName("useHealthCheck")]
    public bool UseHealthCheck { get; set; }
    [JsonPropertyName("useHttpContextAccessor")]
    [ConfigurationKeyName("useHttpContextAccessor")]
    public bool UseHttpContextAccessor { get; set; }
    [JsonPropertyName("useHttpsRedirection")]
    [ConfigurationKeyName("useHttpsRedirection")]
    public bool UseHttpsRedirection { get; set; }

    [JsonPropertyName("useDefaultJsonSerializerOptions")]
    [ConfigurationKeyName("useDefaultJsonSerializerOptions")]
    public bool UseDefaultJsonSerializerOptions { get; set; }
    [JsonPropertyName("useControllers")]
    [ConfigurationKeyName("useControllers")]
    public bool UseControllers { get; set; }

    [JsonPropertyName("swagger")]
    [ConfigurationKeyName("swagger")]
    public SwaggerConfiguration? Swagger { get; set; }
    [JsonPropertyName("cors")]
    [ConfigurationKeyName("cors")]
    public IEnumerable<CorsConfiguration>? Cors { get; set; }

    
}