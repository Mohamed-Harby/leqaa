using BusinessLogic.Application.Models.TextChatModels.User;

namespace BusinessLogic.Application.Models.TextChatModels.Chat;
public record ChatResponseModel : BaseResponseModel
{
    public string chatName { get; init; } = string.Empty;
    public bool isGroupChat { get; init; }
    public Guid latestMessage { get; init; }
    public List<UserResponseModel>? users { get; init; }
}