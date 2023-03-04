using BusinessLogic.Application.Commands.Hubs.DeployHub;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using BusinessLogic.Application.Validations;

namespace BusinessLogic.Application.DependencyInjection;
public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(HubValidator).Assembly);
        services.AddMediatR(typeof(DeployHubCommand).Assembly);
        return services;
    }
}