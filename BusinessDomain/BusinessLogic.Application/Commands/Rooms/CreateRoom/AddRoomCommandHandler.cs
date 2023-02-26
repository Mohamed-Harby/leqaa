using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Rooms;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using BusinessLogic.Shared;
using ErrorOr;
using FluentValidation;
using Mapster;
using MediatR;

namespace BusinessLogic.Application.Commands.Rooms.AddRoom;
public class AddRoomCommandHandler : IHandler<AddRoomCommand, ErrorOr<Room>>
{
    private readonly IRoomRepository _RoomRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileManager _fileManager;
    private readonly IValidator<AddRoomCommand> _validator;
    public AddRoomCommandHandler(
        IRoomRepository RoomRepository,
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IValidator<AddRoomCommand> validator,
        IFileManager fileManager)
    {
        _RoomRepository = RoomRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _validator = validator;
        _fileManager = fileManager;
    }

    public async Task<ErrorOr<Room>> Handle(AddRoomCommand request, CancellationToken cancellationToken)
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
            Path.Combine(Environment.CurrentDirectory, "../Assets/RoomPlaceHolder.png")
            );

        var Room = request.Adapt<Room>();
        //Room.Logo = request.Logo is null ? image : request.Logo;

        var creatorUser = (await _userRepository.GetAsync(u => u.UserName == request.Username)).FirstOrDefault();
        if (creatorUser is null)
        {
            return DomainErrors.User.NotFound;
        }

        await _RoomRepository.AddRoomWithUserAsync(Room, creatorUser);
        if (await _unitOfWork.Save() == 0)
        {
            //return DomainErrors.Room.InvalidRoom;
        }
        return Room;
    }
}
