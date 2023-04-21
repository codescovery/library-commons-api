using Microsoft.Extensions.DependencyInjection;

namespace Codescovery.Library.Api.Interfaces;

public interface IExceptionHandlerDependencyInjectionAddHandler
{
    IServiceCollection Add(IServiceCollection services);
}