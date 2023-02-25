using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using FluentValidation;
using Mapster;
using MediatR;

namespace BusinessLogic.Application.Commands.Hubs.AddHub;
public class AddRoomCommandHandler : IHandler<AddHubCommand, ErrorOr<HubReadModel>>
{
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IFileManager _fileManager;
    private readonly IValidator<AddHubCommand> _validator;
    private readonly IUserHubRepository _userHubRepository;
    public AddRoomCommandHandler(
        IHubRepository hubRepository,
        IUserRepository userRepository,
        IValidator<AddHubCommand> validator,
        IFileManager fileManager,
        IUserHubRepository userHubRepository)
    {
        _hubRepository = hubRepository;
        _userRepository = userRepository;
        _validator = validator;
        _fileManager = fileManager;
        _userHubRepository = userHubRepository;
    }

    public async Task<ErrorOr<HubReadModel>> Handle(AddHubCommand request, CancellationToken cancellationToken)
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
        hub.Logo = request.Logo is null ? image : request.Logo;

        var creatorUser = (await _userRepository.GetUserWithHubsAsync(request.Username));
        if (creatorUser is null)
        {
            return DomainErrors.User.NotFound;
        }
        var UserHub = new UserHub
        {
            User = creatorUser,
            Hub = hub,
            Role = "Creator"
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
