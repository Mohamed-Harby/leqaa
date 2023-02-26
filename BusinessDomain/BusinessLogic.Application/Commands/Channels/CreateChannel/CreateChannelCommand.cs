using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Application.Commands.Channels.CreateChannel;
public record CreateChannelCommand(
    string Name,
    string? Description,
    Guid ChannelId,
    string Username,
    string? hubId
) : ICommand<ErrorOr<Channel>>;