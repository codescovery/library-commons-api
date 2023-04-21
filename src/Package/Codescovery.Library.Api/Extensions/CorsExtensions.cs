using Codescovery.Library.Api.Constants;
using Codescovery.Library.Api.Entities.Configurations;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Codescovery.Library.Api.Extensions;

public static class CorsExtensions
{
    public static IServiceCollection ConfigureCorsDependency(this IServiceCollection services,
       IEnumerable<CorsConfiguration>? corsConfiguration = null, bool corsAllowAllIfNotConfigured = true)
    {
        if (corsConfiguration == null && corsAllowAllIfNotConfigured)
            return services.AddCors(options => options.ConfigureCorsDependencyWithDefaultAllowAllPolicy());
        var corsConfigurationAsList = corsConfiguration?.ToList() ?? new List<CorsConfiguration>();

        if (corsConfigurationAsList.Any())
            return services.AddCors(options =>
            {
                foreach (var configuration in corsConfigurationAsList)
                    options.ConfigureUsingCorsConfiguration(configuration);
            });
        return services;
    }

    public static void ConfigureCorsDependencyWithDefaultAllowAllPolicy(this CorsOptions options,
        string policyName = DefaultValues.CorsAllowAllDefaultPolicyName)
    {
        var existentDefaultAllowAllPolicy = options.GetPolicy(policyName);
        if (existentDefaultAllowAllPolicy != null) return;
        options.AddPolicy(policyName, builder =>
        {
            builder
                .SetIsOriginAllowed(_ => true)
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
    }

    public static void ConfigureUsingCorsConfiguration(this CorsOptions options, CorsConfiguration corsConfiguration)
    {
        var existentPolicy = options.GetPolicy(corsConfiguration.PolicyName);
        if (existentPolicy != null) return;
        if (corsConfiguration.AllowAll)
            options.ConfigureCorsDependencyWithDefaultAllowAllPolicy(corsConfiguration.PolicyName);

        options.AddPolicy(corsConfiguration.PolicyName, builder =>
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
    }
}