using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Annoucements.HubAnnoucements;
using ErrorOr;

namespace BusinessLogic.Application.Queries.Announcements.ViewHubAnnouncements;
public record ViewHubAnnouncementsQuery(
    int PageNumber,
    int PageSize,
    Guid HubId
) : IQuery<ErrorOr<List<HubAnnouncementReadModel>>>;