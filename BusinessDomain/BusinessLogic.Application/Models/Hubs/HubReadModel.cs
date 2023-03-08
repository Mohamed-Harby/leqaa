namespace BusinessLogic.Application.Models.Hubs;
public record HubReadModel(
    Guid Id,
    string HubName,
    string HubDescription,
    bool IsPrivate,
    byte[]? HubLogo,
    DateTime CreationDate
) : BaseReadModel(Id, CreationDate);