using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Channels;
using ErrorOr;

namespace BusinessLogic.Application.Commands.Users.JoinChannel;
public record JoinChannelCommand(
    string UserName,
    Guid ChannelId
) : IUserNameInCommand<ErrorOr<ChannelReadModel>>;