using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Annoucements.HubAnnoucements;

namespace BusinessLogic.Application.Queries.Announcements;
public record ViewHubAnnouncementsQuery(
    int PageNumber,
    int PageSize
):IQuery<List<HubAnnouncementReadModel>>;