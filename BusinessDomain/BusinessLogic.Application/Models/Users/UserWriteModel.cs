namespace BusinessLogic.Application.Models.Channels;
public record UserlWriteModel(
    string name,
    string description,
    Guid userId
);