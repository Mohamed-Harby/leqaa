namespace BusinessLogic.Application.Models.TextChatModels.CreateGroup;
public record CreateGroupRequestModel
{
    public CreateGroupRequestModel()
    {
        users = new List<Guid>();
    }
    string name { get; init; } = string.Empty;
    List<Guid> users { get; init; }
}