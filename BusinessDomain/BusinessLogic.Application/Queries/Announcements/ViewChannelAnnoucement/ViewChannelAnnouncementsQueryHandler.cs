using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Annoucements.ChannelAnnoucements;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Queries.Announcements.ViewChannelAnnoucement;
public class ViewChannelAnnouncementsQueryHandler : IHandler<ViewChannelAnnouncementsQuery, ErrorOr<List<ChannelAnnouncementReadModel>>>
{
    private readonly IChannelAnnouncementRepository _channelAnnouncementsQuery;

    public ViewChannelAnnouncementsQueryHandler(IChannelAnnouncementRepository channelAnnouncementsQuery)
    {
        _channelAnnouncementsQuery = channelAnnouncementsQuery;
    }

    public async Task<ErrorOr<List<ChannelAnnouncementReadModel>>> Handle(ViewChannelAnnouncementsQuery request, CancellationToken cancellationToken)
    {
        var result = await _channelAnnouncementsQuery.GetAsync(ca => ca.ChannelId == request.ChannelId, null, "");
        result.Skip((request.PageNumber - 1) * request.PageSize)
        .Take(request.PageNumber);
        return result.Adapt<List<ChannelAnnouncementReadModel>>();
    }
}
