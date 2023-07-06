using Codescovery.Library.Api.Conventions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Codescovery.Library.Api.Extensions;

public static class MvcOptionsExtensions
{
    public static MvcOptions AddContextRouteConvention(this MvcOptions options)
    {
        options.Conventions.Add(new ContextRouteConventions());
        return options;
    }
}