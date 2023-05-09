using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.TextChatModels.SendMessage;
using BusinessLogic.Application.Models.Users;
using ErrorOr;

namespace BusinessLogic.Application.Commands.Users.SendMessage;
public record SendMessageCommand(
    string UserName,
    string Content
) : IUserNameInCommand<ErrorOr<SendMessageResponseModel>>;