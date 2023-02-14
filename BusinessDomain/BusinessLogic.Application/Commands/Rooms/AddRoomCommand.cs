using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Application.Commands.Rooms.DeleteRoom;
public record AddRoomCommand(
    string Name,
    string? Description,
    Guid HubId,
    Guid ChannelId,
    string Username
) : ICommand<ErrorOr<Room>>;