using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Application.Commands.Channels.DeleteChannel;
public record DeletePostCommand(
 Guid ChannelId
) : ICommand<ErrorOr<Unit>>;