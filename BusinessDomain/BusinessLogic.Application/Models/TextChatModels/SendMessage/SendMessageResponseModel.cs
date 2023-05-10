using BusinessLogic.Application.Models.TextChatModels.Chat;
using BusinessLogic.Application.Models.TextChatModels.User;

namespace BusinessLogic.Application.Models.TextChatModels.SendMessage;

public record SendMessageResponseModel : BaseResponseModel
{
    public SendMessageResponseModel()
    {
        readBy = new List<UserResponseModel>();
    }
    public ChatResponseModel? chat { get; init; }
    public UserResponseModel? sender { get; init; }
    public string content { get; init; } = string.Empty;
    public List<UserResponseModel> readBy { get; init; }
}