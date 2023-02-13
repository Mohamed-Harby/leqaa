using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Domain;
using ErrorOr;

namespace BusinessLogic.Application.Commands.Rooms.AddRoom;
public record AddRoomCommand(
    string Name,
    string Description,
    byte[]? Logo,
    string Username
 ) : ICommand<ErrorOr<Room>>;