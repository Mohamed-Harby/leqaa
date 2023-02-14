namespace BusinessLogic.Application.Models.Posts;
public record PostWriteModel(
    string name,
    string description,
    byte[]? logo,
    Guid hubId,
    Guid channelId
);