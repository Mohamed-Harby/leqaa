namespace BusinessLogic.Application.Models.TextChatModels;
public record BaseResponseModel
{
    public Guid _id { get; init; }
    public DateTime createdAt { get; init; }
}