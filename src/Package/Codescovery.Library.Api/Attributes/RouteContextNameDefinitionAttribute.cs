using Microsoft.AspNetCore.Mvc.Routing;

namespace Codescovery.Library.Api.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class RouteContextNameDefinitionAttribute : Attribute, IRouteValueProvider
{
    public RouteContextNameDefinitionAttribute(string contextDefinitionName)
    {
        ContextDefinitionName = contextDefinitionName;
        RouteKey = "contextName";
        RouteValue = contextDefinitionName;
    }
    public string ContextDefinitionName { get; }
    public string RouteKey { get; }
    public string RouteValue { get; }
}