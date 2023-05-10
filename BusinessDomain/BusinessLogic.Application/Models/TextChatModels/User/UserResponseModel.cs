namespace BusinessLogic.Application.Models.TextChatModels.User;
using BusinessLogic.Application.Models.TextChatModels;
public record UserResponseModel : BaseResponseModel
{
    public string name { get; init; } = string.Empty;
    public string email { get; init; } = string.Empty;
}