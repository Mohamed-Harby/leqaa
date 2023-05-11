namespace BusinessLogic.Application.Models.Posts;

public record PostRecentReadModel(
    Guid Id,
    string PostTitle,
    byte[]? PostImage,
    string PostContent,
    DateTime CreationDate) : BaseReadModel(Id, CreationDate);

