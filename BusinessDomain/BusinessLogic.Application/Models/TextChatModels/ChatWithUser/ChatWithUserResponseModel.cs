using BusinessLogic.Application.Models.TextChatModels.User;

namespace BusinessLogic.Application.Models.TextChatModels.ChatWithUser;
public record ChatWithUserResponseModel : BaseResponseModel
{
    public ChatWithUserResponseModel()
    {
        Users = new List<UserResponseModel>();
    }
    public string ChatName { get; init; } = string.Empty;
    public bool IsChatName { get; init; }
    List<UserResponseModel> Users { get; init; }
}