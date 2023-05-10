using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Annoucements.ChannelAnnoucements;
using ErrorOr;

namespace BusinessLogic.Application.Queries.Announcements.ViewChannelAnnoucement;
public record ViewChannelAnnouncementsQuery(
    int PageNumber,
    int PageSize,
    Guid ChannelId
) : IQuery<ErrorOr<List<ChannelAnnouncementReadModel>>>;