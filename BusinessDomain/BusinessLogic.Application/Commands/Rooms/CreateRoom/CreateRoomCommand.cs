using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Domain;
using ErrorOr;

namespace BusinessLogic.Application.Commands.Rooms.AddRoom;
public record CreateRoomCommand(
    string Name,
    string Description,
    byte[]? Logo,
    string UserName
 ) : IUserNameInCommand<ErrorOr<Room>>;
