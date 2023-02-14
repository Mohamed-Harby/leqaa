using BusinessLogic.Application.Commands.Hubs.AddHub;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;
using BusinessLogic.Application.Validations;

namespace BusinessLogic.Application.DependencyInjection;
public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(HubValidator).Assembly);
        services.AddMediatR(typeof(AddHubCommand).Assembly);
        return services;
    }
}