using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;
using MediatR;

namespace BusinessLogic.Application.Commands.Rooms.DeleteRoom;
public class AddRoomCommandHandler : IHandler<AddRoomCommand, ErrorOr<Room>>
{
    private readonly IRoomRepository _RoomRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddRoomCommandHandler(
        IRoomRepository roomRepository,
        IHubRepository hubRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _RoomRepository = roomRepository;
        _hubRepository = hubRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Room>> Handle(AddRoomCommand request, CancellationToken cancellationToken)
    {
        User creatorUser = (await _userRepository.GetAsync(u => u.UserName == request.Username)).FirstOrDefault()!;
        if (creatorUser is null)
        {
            return DomainErrors.User.NotFound;
        }
        Hub hub = await _hubRepository.GetByIdAsync(request.HubId);
        if (hub is null)
        {
            return DomainErrors.Hub.NotFound;
        }
        var room = request.Adapt<Room>();
        await _RoomRepository.AddRoomWithUser(room, creatorUser);
        if (await _unitOfWork.Save() == 0)
        {
            return DomainErrors.Room.InvalidRoom;
        }
        return room;
    }
}
