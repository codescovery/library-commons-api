using Codescovery.Library.Api.Entities.Configurations;
using Codescovery.Library.DependencyInjection.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Codescovery.Library.Api.Extensions;

public static class ApiConfigurationExtensions
{

    public static IServiceCollection ConfigureUsingApiConfiguration(this IServiceCollection services, IConfiguration configuration, bool corsAllowAllIfNotConfigured = true, string sectionName = ApiConfiguration.SectionName,
        Action<IMvcBuilder>? configureMvcBuilder = null)
    {
        var apiConfigurationSection = configuration.GetSection(sectionName);
        if (apiConfigurationSection == null) throw new NullReferenceException($"Unable to get the api configuration section from {sectionName}");
        var apiConfiguration = apiConfigurationSection.Get<ApiConfiguration>();
        if (apiConfiguration == null)
            throw new NullReferenceException($"Unable to get a deserialized {nameof(ApiConfiguration)} from section with name {sectionName}");
        if (apiConfiguration.UseSwagger)
            services.ConfigureSwaggerDependency(apiConfiguration.Swagger);
        if (apiConfiguration.UseHealthCheck)
            services.AddHealthChecks();
        if (apiConfiguration.UseHttpContextAccessor)
            services.AddHttpContextAccessor();
        if (apiConfiguration.UseDefaultJsonSerializerOptions)
            services.AddDefaultJsonSerializeOptions();
        if (apiConfiguration.UseControllers)
            if(configureMvcBuilder == null)
                services.AddControllers();
            else
              configureMvcBuilder.Invoke(services.AddControllers());
        
        services.Configure<ApiConfiguration>(apiConfigurationSection);

        return services;
    }
}