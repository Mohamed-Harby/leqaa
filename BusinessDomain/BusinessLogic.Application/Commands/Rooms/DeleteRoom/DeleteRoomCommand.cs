using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Application.Commands.Rooms.DeleteRoom;
public record DeleteRoomCommand(
    string Name,
    string? Description,
    Guid RoomId,
    string UserName
) : IUserNameInCommand<ErrorOr<Room>>;
