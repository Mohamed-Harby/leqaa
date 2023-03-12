namespace BusinessLogic.Application.Models.RecentActivities;
public record HubRecentReadModel(
    Guid Id,
    string HubName,
    string HubDescription,
    bool IsPrivate,
    byte[]? HubLogo,
    DateTime CreationDate
) : BaseReadModel(Id, CreationDate);