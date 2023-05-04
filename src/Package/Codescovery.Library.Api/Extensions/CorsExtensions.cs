using Codescovery.Library.Api.Entities.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Codescovery.Library.Api.Extensions;

public static class CorsExtensions
{
    public static IApplicationBuilder ConfigureCors(this IApplicationBuilder appBuilder, ApiConfiguration apiConfigurations, bool corsAllowAllNoConfiguration = true)
    {
        
        if (!apiConfigurations.UseCors) return appBuilder;
        if (apiConfigurations.Cors == null && corsAllowAllNoConfiguration)
            return appBuilder.UseCors(builder => builder.ConfigureAllowAllPolicy());
                
        var corsConfigurationAsList = apiConfigurations.Cors?.ToList() ?? new List<CorsConfiguration>();
        if(corsConfigurationAsList.Any(c=>c.AllowAll))
            return appBuilder.UseCors(builder => builder.ConfigureAllowAllPolicy());

        foreach (var corsConfiguration in apiConfigurations.Cors!)
            appBuilder.UseCors(builder =>
            {
                if (corsConfiguration.AllowedMethods != null && corsConfiguration.AllowedMethods.Any())
                    builder.WithMethods(corsConfiguration.AllowedMethods.ToArray());
                if (corsConfiguration.AllowedOrigins != null && corsConfiguration.AllowedOrigins.Any())
                    builder.WithOrigins(corsConfiguration.AllowedOrigins.ToArray());
                if (corsConfiguration.AllowedCredentials != null && corsConfiguration.AllowedCredentials.Any())
                    builder.WithOrigins(corsConfiguration.AllowedCredentials.ToArray());
                if (corsConfiguration.AllowedHeaders != null && corsConfiguration.AllowedHeaders.Any())
                    builder.WithHeaders(corsConfiguration.AllowedHeaders.ToArray());

            });

        return appBuilder;
    }

    public static CorsPolicyBuilder ConfigureAllowAllPolicy(this CorsPolicyBuilder builder)
    {
        return builder
            .SetIsOriginAllowed(_ => true)
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    }
}