using BusinessLogic.Application.Interfaces;
using BusinessLogic.Infrastructure.Authorization;
using BusinessLogic.Infrastructure.Authorization.Handlers;
using BusinessLogic.Infrastructure.OSCalls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Infrastructure.DependencyInjection;
public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IFileManager, FileManager>();
        services.AddScoped<IAuthorizationHandler, CanJoinRoomAuthorizationHandler>();
        services.AddScoped<IAuthorizationHandler, CanDeployHubsAuthorizationHandler>();
        services.AddSingleton<IAuthorizationPolicyProvider, CanJoinRoomPolicyProvider>();
        services.AddSingleton<IAuthorizationPolicyProvider, CanDeployHubsPolicyProvider>();
        return services;
    }
}