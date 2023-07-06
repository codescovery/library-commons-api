using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Reflection;
using Codescovery.Library.Api.Attributes;
using Codescovery.Library.Api.Constants;

namespace Codescovery.Library.Api.Conventions;

internal class ContextRouteConventions : IActionModelConvention
{
    public void Apply(ActionModel action)
    {
        var value = action.Controller.ControllerType.GetCustomAttribute<ContextRouteAttribute>()?.ContextName;
        if (value is null) return;
        action.RouteValues.Add(DefaultValues.ContextRouteAttributeName, value);
    }
}