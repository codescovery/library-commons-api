using Codescovery.Library.Api.Interfaces.Attributes;

namespace Codescovery.Library.Api.Attributes;
[AttributeUsage(AttributeTargets.Class)]
public class ContextRouteAttribute : Attribute,IContextRouteAttribute
{
    public ContextRouteAttribute(string contextName)
        => ContextName = contextName;

    public string ContextName { get; }
}