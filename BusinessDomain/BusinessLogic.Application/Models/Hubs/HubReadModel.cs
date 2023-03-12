using BusinessLogic.Application.Models.Annoucements.HubAnnoucements;
using BusinessLogic.Domain;

namespace BusinessLogic.Application.Models.Hubs;
public record HubReadModel(
    Guid Id,
    string Name,
    string Description,
    bool IsPrivate,
    byte[]? Logo,
    DateTime CreationDate,
    List<HubAnnouncementReadModel> HubAnnouncements,
    List<User> JoinedUsers
) : BaseReadModel(Id, CreationDate);