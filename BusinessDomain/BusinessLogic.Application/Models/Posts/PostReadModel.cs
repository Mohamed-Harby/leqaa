namespace BusinessLogic.Application.Models.Posts;

public record PostReadModel(
    Guid Id,
    string PostTitle,
    byte[]? PostImage,
    string PostContent,
    DateTime CreationDate) : BaseReadModel(Id, CreationDate);

