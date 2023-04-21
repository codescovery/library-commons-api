using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace Codescovery.Library.Api.Entities.Configurations;

public class SwaggerConfiguration
{
    public SwaggerConfiguration()
    {
        var applicationName = Assembly.GetEntryAssembly()?.GetName()?.Name ?? "Default Application Name";
        Name = applicationName;
        Title = $"{applicationName} API";
        Version = "v1";
        Description = $"{applicationName} API";
        Endpoint = "/swagger/v1/swagger.json";
        Description = $"{applicationName} API description";
        Servers = null;
        AuthenticationConfiguration = null;
        Project = string.Empty;
    }
    [JsonPropertyName("name")]
    [ConfigurationKeyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("title")]
    [ConfigurationKeyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("endpoint")]
    [ConfigurationKeyName("endpoint")]
    public string? Endpoint { get; set; }
    [JsonPropertyName("version")]
    [ConfigurationKeyName("version")]
    public string? Version { get; set; }
    [JsonPropertyName("description")]
    [ConfigurationKeyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("project")]
    [ConfigurationKeyName("project")]
    public string? Project { get; set; }
    [JsonPropertyName("servers")]
    [ConfigurationKeyName("servers")]
    public IEnumerable<string>? Servers { get; set; }
    [JsonPropertyName("authenticationConfiguration")]
    [ConfigurationKeyName("authenticationConfiguration")]
    public OpenApiSecurityScheme? AuthenticationConfiguration { get; set; }
}