namespace BusinessLogic.Application.Models.TextChatModels.SendMessage;
public record SendMessageRequestModel(
    string content,
    Guid chatId
);