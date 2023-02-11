using Authentication.Application.Interfaces;
using Authentication.Infrastructure.Models;
using Authentication.Infrastructure.NetworkCalls.EmailSender;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Infrastructure.DependencyInjection;
public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<Jwt>(configuration.GetSection("Jwt"));
        services.Configure<Smtp>(configuration.GetSection("Smtp"));

        services.AddSingleton<ITokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IEmailSender, EmailSender>();
        services.AddSingleton<IConfirmationEmailSender, ConfirmationEmailSender>();
        services.AddSingleton<IResetPasswordEmailSender, ResetPasswordEmailSender>();

        return services;
    }
}