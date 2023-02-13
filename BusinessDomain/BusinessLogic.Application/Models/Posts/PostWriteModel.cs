namespace BusinessLogic.Application.Models.Posts;
public record PostWriteModel(
        string hubId,
    string channelId,
    string name,
    string description,
    Guid postId
);