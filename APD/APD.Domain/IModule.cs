using Microsoft.Extensions.DependencyInjection;

namespace APD.Domain;

public interface IModule
{
    public void Registry(IServiceCollection services);
}