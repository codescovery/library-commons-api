using Codescovery.Library.Api.Attributes.Filters;
using Codescovery.Library.Api.Constants;
using Codescovery.Library.Api.Entities.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Codescovery.Library.Api.Extensions;

public static class SwaggerExtensions
{


    public static IServiceCollection ConfigureSwaggerDependency(this IServiceCollection services,
        SwaggerConfiguration? swaggerConfiguration = null)
    {
        var persistedSwaggerConfiguration = swaggerConfiguration ?? new SwaggerConfiguration();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.OperationFilter<SwaggerOptionalRouteParameterOperationFilter>();
            options.SwaggerDoc(persistedSwaggerConfiguration.Version, new OpenApiInfo
            {
                Title = persistedSwaggerConfiguration.Title,
                Version = persistedSwaggerConfiguration.Version,
                Description = persistedSwaggerConfiguration.Description
            });


            if (persistedSwaggerConfiguration.Servers != null && persistedSwaggerConfiguration.Servers.Any())
                foreach (var sever in persistedSwaggerConfiguration.Servers)
                    options.AddServer(new OpenApiServer { Url = sever });

            if (!string.IsNullOrEmpty(persistedSwaggerConfiguration.Project))
            {
                var file = Path.Combine(AppContext.BaseDirectory, $"{persistedSwaggerConfiguration.Project}.xml");
                options.IncludeXmlComments(file);
            }

            if (persistedSwaggerConfiguration.AuthenticationConfiguration == null) return;

            options.AddSecurityDefinition(persistedSwaggerConfiguration.AuthenticationConfiguration.Name,
                persistedSwaggerConfiguration.AuthenticationConfiguration);
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {{persistedSwaggerConfiguration.AuthenticationConfiguration, new List<string>()}});
        });
        return services;
    }

    public static IApplicationBuilder ConfigureSwaggerUsingApiConfigurations(this IApplicationBuilder appBuilder, ApiConfiguration apiConfigurations)
    {
        if (!apiConfigurations.UseSwagger) return appBuilder;
        appBuilder.UseSwagger();
        appBuilder.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint(apiConfigurations.Swagger!.Endpoint,
                apiConfigurations.Swagger.Name);
        });
        return appBuilder;
    }

    
}