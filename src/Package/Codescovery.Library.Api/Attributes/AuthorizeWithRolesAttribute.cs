using Microsoft.AspNetCore.Authorization;

namespace Codescovery.Library.Api.Attributes;

public class AuthorizeWithRolesAttribute:AuthorizeAttribute
{
    public AuthorizeWithRolesAttribute(params string[] roles)
    {
        Roles = string.Join(",", roles.Select(r => r));

    }
}