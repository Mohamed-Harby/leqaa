using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using BusinessLogic.Persistence.Repositories;
using ErrorOr;
using FluentValidation;
using Mapster;
using MediatR;

namespace BusinessLogic.Application.Commands.Hubs.AddHub;
public class AddHubCommandHandler : IHandler<AddHubCommand, ErrorOr<Hub>>
{
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileManager _fileManager;
    private readonly IValidator<AddHubCommand> _validator;
    public AddHubCommandHandler(
        IHubRepository hubRepository,
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IValidator<AddHubCommand> validator,
        IFileManager fileManager)
    {
        _hubRepository = hubRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _validator = validator;
        _fileManager = fileManager;
    }

    public async Task<ErrorOr<Hub>> Handle(AddHubCommand request, CancellationToken cancellationToken)
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

        var creatorUser = (await _userRepository.GetAsync(u => u.Username == request.Username)).FirstOrDefault();
        if (creatorUser is null)
        {
            return DomainErrors.User.NotFound;
        }

        await _hubRepository.AddHubWithUserAsync(hub, creatorUser);
        if (await _unitOfWork.Save() == 0)
        {
            return DomainErrors.Hub.InvalidHub;
        }
        return hub;
    }
}
