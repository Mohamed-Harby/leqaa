namespace BusinessLogic.Application.Models.Posts;
public record PostReadModel(
    Guid Id,
    string Title,
    byte[]? Image,
    string Content,
    DateTime CreationDate) : BaseReadModel(Id, CreationDate);