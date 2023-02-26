using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using BusinessLogic.Domain.SharedEnums;
using BusinessLogic.Shared;
using ErrorOr;
using FluentValidation;
using Mapster;
using MediatR;

namespace BusinessLogic.Application.Commands.Hubs.DeployHub;
public class DeployHubCommandHandler : IHandler<DeployHubCommand, ErrorOr<HubReadModel>>
{
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IFileManager _fileManager;
    private readonly IValidator<DeployHubCommand> _validator;
    private readonly IUserHubRepository _userHubRepository;
    public DeployHubCommandHandler(
        IHubRepository hubRepository,
        IUserRepository userRepository,
        IValidator<DeployHubCommand> validator,
        IFileManager fileManager,
        IUserHubRepository userHubRepository)
    {
        _hubRepository = hubRepository;
        _userRepository = userRepository;
        _validator = validator;
        _fileManager = fileManager;
        _userHubRepository = userHubRepository;
    }

    public async Task<ErrorOr<HubReadModel>> Handle(DeployHubCommand request, CancellationToken cancellationToken)
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

        byte[] image = await _fileManager
        .GetByteArrayFromImageAsync(
            Path.Combine(Environment.CurrentDirectory, "../Assets/HubPlaceHolder.png")
            );

        var hub = request.Adapt<Hub>();
        hub.Logo = request.Logo ?? image;

        var creatorUser = (await _userRepository.GetUserWithHubsAsync(request.Username));
        if (creatorUser is null)
        {
            return DomainErrors.User.NotFound;
        }
        var UserHub = new UserHub
        {
            User = creatorUser,
            Hub = hub,
            Role = GroupRole.Founder
        };
        await _userHubRepository.UpdateAsync(UserHub);
        creatorUser.Hubs.Add(hub);
        if (await _userRepository.SaveAsync() == 0)
        {
            return DomainErrors.Hub.InvalidHub;
        }

        return hub.Adapt<HubReadModel>();
    }
}
