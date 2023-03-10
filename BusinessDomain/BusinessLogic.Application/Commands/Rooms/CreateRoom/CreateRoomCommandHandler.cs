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
public class CreateRoomCommandHandler : IHandler<CreateRoomCommand, ErrorOr<Room>>
{
    private readonly IRoomRepository _RoomRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileManager _fileManager;
    private readonly IValidator<CreateRoomCommand> _validator;
    public CreateRoomCommandHandler(
        IRoomRepository RoomRepository,
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IValidator<CreateRoomCommand> validator,
        IFileManager fileManager)
    {
        _RoomRepository = RoomRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _validator = validator;
        _fileManager = fileManager;
    }

    public async Task<ErrorOr<Room>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        byte[] image = await _fileManager
            .GetByteArrayFromImageAsync(
        Path.Combine(Environment.CurrentDirectory, "../Assets/RoomPlaceHolder.png")
        );

        var Room = request.Adapt<Room>();
        //Room.Logo = request.Logo is null ? image : request.Logo;

        var creatorUser = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault();

        await _unitOfWork.CreateRoomAsync(Room, creatorUser!);
        if (await _unitOfWork.SaveAsync() == 0)
        {
            //return DomainErrors.Room.InvalidRoom;
        }
        return Room;
    }
}
