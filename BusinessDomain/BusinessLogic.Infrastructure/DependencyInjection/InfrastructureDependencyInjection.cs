using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Interfaces.TextChat;
using BusinessLogic.Infrastructure.Authorization;
using BusinessLogic.Infrastructure.Authorization.Handlers;
using BusinessLogic.Infrastructure.Authorization.PolicyProviders;
using BusinessLogic.Infrastructure.NetworkCalls;
using BusinessLogic.Infrastructure.NetworkCalls.TextChat;
using BusinessLogic.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Infrastructure.DependencyInjection;
public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IFileManager, FileManager>();
        services.AddScoped<IHttpHelper, HttpHelper>();
        services.AddScoped<HttpHelper>();
        services.AddScoped<IAuthorizationHandler, CanJoinHubAuthorizationHandler>();
        services.AddScoped<IAuthorizationHandler, CanJoinRoomAuthorizationHandler>();
        services.AddScoped<IAuthorizationHandler, CanDeployHubsAuthorizationHandler>();
        services.AddScoped<IAuthorizationHandler, CanCreateChannelAuthorizationHandler>();

        services.AddScoped<ITextChatService, TextChatService>();

        services.AddHttpClient(ServiceNames.TextChatAPI, configure =>
        {
            configure.BaseAddress = new Uri(configuration.GetSection("textChatUri").Value);
        }
        );
        return services;
    }
}