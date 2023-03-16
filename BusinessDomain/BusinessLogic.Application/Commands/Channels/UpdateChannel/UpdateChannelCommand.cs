using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Application.Commands.Channels.UpdateChannel;
public record UpdateChannelCommand(
       Guid Id,
    string Name,
    string? Description
 
) : ICommand<ErrorOr<ChannelWriteModel>>;