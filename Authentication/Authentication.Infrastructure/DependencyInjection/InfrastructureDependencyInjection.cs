using System.Reflection;
using Authentication.Application.Interfaces;
using Authentication.Infrastructure.Models;
using Authentication.Infrastructure.NetworkCalls.EmailSender;
using Authentication.Infrastructure.NetworkCalls.MessageQueue;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Infrastructure.DependencyInjection;
public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<Jwt>(configuration.GetSection("Jwt"));
        services.Configure<Smtp>(configuration.GetSection("Smtp"));
        services.Configure<RabbitMQConnectionModel>(configuration.GetSection("RabbitMQ"));

        services.AddSingleton<ITokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IEmailSender, EmailSender>();
        services.AddSingleton<IConfirmationEmailSender, ConfirmationEmailSender>();
        services.AddSingleton<IResetPasswordEmailSender, ResetPasswordEmailSender>();
        services.AddScoped<IMessageQueueManager, MessageQueueManager>();

        return services;

    }
}