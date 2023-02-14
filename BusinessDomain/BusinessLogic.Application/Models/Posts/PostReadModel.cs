namespace BusinessLogic.Application.Models.Posts;
public record PostReadModel(
    Guid Id,
    string name,
    string description,
    string? logo
);