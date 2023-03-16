using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Application.Commands.Channels.CreateChannel;
public record CreateChannelCommand(
    string Name,
    string? Description,
    Guid? HubId,
    string UserName
)
: IUserNameInCommand<ErrorOr<ChannelReadModel>>;
