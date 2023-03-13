using BusinessLogic.Application.Commands.Hubs.DeployHub;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using BusinessLogic.Application.Validations.HubValidations;
using BusinessLogic.Application.Behaviours;
using Mapster;
using MapsterMapper;

namespace BusinessLogic.Application.DependencyInjection;
public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DeployHubCommandValidations).Assembly, includeInternalTypes: true);
        services.AddMediatR(typeof(DeployHubCommand));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CheckUserBehaviour<,>));

        var mappingConfig = TypeAdapterConfig.GlobalSettings;
        mappingConfig.Scan(typeof(ApplicationDependencyInjection).Assembly);
        services.AddSingleton(mappingConfig);
        services.AddSingleton<IMapper, ServiceMapper>();
        return services;
    }
}