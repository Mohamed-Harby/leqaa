using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;
using MediatR;

namespace BusinessLogic.Application.Commands.Rooms.DeleteRoom;
public class DeleteRoomCommandHandler : IHandler<DeleteRoomCommand, ErrorOr<Room>>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRoomCommandHandler(
        IRoomRepository roomRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _roomRepository = roomRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<ErrorOr<Room>> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    /*   public async Task<ErrorOr<Room>> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
       {
           User creatorUser = (await _userRepository.GetAsync(u => u.Username == request.Username)).FirstOrDefault()!;
           if (creatorUser is null)
           {
               return DomainErrors.User.NotFound;
           }
           Room Room = await _RoomRepository.GetByIdAsync(request.RoomId);
           if (Room is null)
           {
               return DomainErrors.Room.NotFound;
           }
           var Room = request.Adapt<Room>();
           await _RoomRepository.DeleteRoomWithUserAsync(Room, creatorUser);
           if (await _unitOfWork.Save() == 0)
           {
               return DomainErrors.Room.InvalidRoom;
           }
           return Room;
       }*/
}
