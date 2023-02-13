using System.Reflection;
using Authentication.Application.Commands.RegisterUser;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Application.DependencyInjection;
public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(RegisterUserCommand).Assembly);
        return services;
    }
}