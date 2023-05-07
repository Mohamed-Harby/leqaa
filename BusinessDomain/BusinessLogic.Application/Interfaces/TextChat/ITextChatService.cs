using BusinessLogic.Application.Models.TextChatModels.ChatWithUser;
using BusinessLogic.Application.Models.TextChatModels.SendMessage;
using BusinessLogic.Application.Models.TextChatModels.User;

namespace BusinessLogic.Application.Interfaces.TextChat;
public interface ITextChatService
{
    Task<ChatWithUserResponseModel> ChatWithUser(ChatWithUserRequestModel requestModel);
    Task<UserResponseModel> SearchUser(string username);
    Task<SendMessageResponseModel> SendMessage(SendMessageRequestModel requestModel);
}