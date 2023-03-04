using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.UpdateChannel;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using FluentValidation;
using Mapster;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Application.Commands.Hubs.DeleteHub;
public class DeleteHubCommandHandler : IHandler<DeleteHubCommand, ErrorOr<Unit>>
{
    private readonly IHubRepository _HubRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IValidator<DeleteHubCommand> _validator;



    public DeleteHubCommandHandler(
        IHubRepository HubRepository,
        IHubRepository hubRepository,
        IUserRepository userRepository,
       IValidator<DeleteHubCommand> validator)

    {
        _HubRepository = HubRepository;
        _hubRepository = hubRepository;
        _userRepository = userRepository;
        _validator = validator;

    }

    public async Task<ErrorOr<Unit>> Handle(DeleteHubCommand request, CancellationToken cancellationToken)
    {

        var result = await _validator.ValidateAsync(request);
        if (!result.IsValid)
        {
            return result.Errors.ConvertAll(
                validationFailure => Error.Validation(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage)
            );
        }

        var hub = await _HubRepository.GetByIdAsync(request.hubId);
        if (hub is null)
        {
            return DomainErrors.Hub.NotFound;
        }
      
        _hubRepository.Remove(hub);

        if (await _hubRepository.SaveAsync() == 0)
        {
            return DomainErrors.Hub.InvalidHub;
        }
        return Unit.Value;
    }
}
