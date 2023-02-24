using BusinessLogic.Application.Interfaces;
using BusinessLogic.Infrastructure.Authorization;
using BusinessLogic.Infrastructure.NetworkCalls.MessageQueue;
using BusinessLogic.Infrastructure.OSCalls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Infrastructure.DependencyInjection;
public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IFileManager, FileManager>();
        services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
        return services;
    }
}