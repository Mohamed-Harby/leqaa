namespace BusinessLogic.Application.Models.Hubs;
public record HubReadModel(
    Guid Id,
    string Name,
    string Description,
    bool IsPrivate,
    byte[]? Logo,
    DateTime CreationDate
) : BaseReadModel(Id, CreationDate);