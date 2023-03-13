using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Annoucements.ChannelAnnoucements;

namespace BusinessLogic.Application.Queries.Announcements;
public record ViewChannelAnnouncementsQuery(
    int PageNumber,
    int PageSize
) : IQuery<List<ChannelAnnouncementReadModel>>;