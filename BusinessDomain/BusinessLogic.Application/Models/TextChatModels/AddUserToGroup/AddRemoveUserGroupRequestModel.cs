namespace BusinessLogic.Application.Models.TextChatModels.AddUserToGroup;
public record AddRemoveUserGroupRequestModel
{
    public Guid chatId { get; set; }
    public Guid userId { get; set; }
}