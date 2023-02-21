using BusinessLogic.Application.Interfaces;
using BusinessLogic.Infrastructure.OSCalls;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Infrastructure.DependencyInjection;
public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IFileManager, FileManager>();
        return services;
    }
}