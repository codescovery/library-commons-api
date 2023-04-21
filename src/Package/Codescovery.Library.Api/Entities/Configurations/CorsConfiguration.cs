using System.Text.Json.Serialization;
using Codescovery.Library.Api.Constants;
using Microsoft.Extensions.Configuration;

namespace Codescovery.Library.Api.Entities.Configurations;

public class CorsConfiguration
{
    public CorsConfiguration()
    {
        AllowAll = true;
        PolicyName = DefaultValues.CorsAllowAllDefaultPolicyName;
        AllowedMethods = null;
        AllowedOrigins = null;
        AllowedCredentials = null;
        AllowedHeaders = null;
    }   
    [JsonPropertyName("allowAll")]
    [ConfigurationKeyName("allowAll")]
    public bool AllowAll { get; set; }
    [JsonPropertyName("policyName")]
    [ConfigurationKeyName("policyName")]
    public string PolicyName { get; set; }
    [JsonPropertyName("allowedMethods")]
    [ConfigurationKeyName("allowedMethods")]
    public IEnumerable<string>? AllowedMethods { get; set; }
    [JsonPropertyName("allowedOrigins")]
    [ConfigurationKeyName("allowedOrigins")]
    public IEnumerable<string>? AllowedOrigins { get; set; }
    [JsonPropertyName("allowedCredentials")]
    [ConfigurationKeyName("allowedCredentials")]
    public IEnumerable<string>? AllowedCredentials { get; set; }
    [JsonPropertyName("allowedHeaders")]
    [ConfigurationKeyName("allowedHeaders")]
    public IEnumerable<string>? AllowedHeaders { get; set; }
}