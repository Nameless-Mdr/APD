using APD.DAL.Implements;
using APD.DAL.Interfaces;
using APD.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace APD.DAL;

public class ServiceDal : IModule
{
    public void Registry(IServiceCollection services)
    {
        services.AddTransient<IOfficeRepo, OfficeRepo>();
    }
}