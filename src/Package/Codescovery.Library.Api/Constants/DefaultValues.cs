using Codescovery.Library.Api.Entities.Configurations;

namespace Codescovery.Library.Api.Constants;

public class DefaultValues
{
    public const string CorsAllowAllDefaultPolicyName = "DefaultAllowAllCorsPolicyName";
    public static CorsConfiguration AllowAllCorsConfiguration => new()
    {
        AllowAll = true
    };
}