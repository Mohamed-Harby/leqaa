using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Application.Commands.Channels.DeleteChannel;
public record DeleteChannelCommand(
    string Name,
    string? Description,
    Guid HubId,
    string Username
) : ICommand<ErrorOr<Channel>>;