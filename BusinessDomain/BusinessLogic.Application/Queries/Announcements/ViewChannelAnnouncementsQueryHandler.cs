using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Annoucements.ChannelAnnoucements;
using Mapster;

namespace BusinessLogic.Application.Queries.Announcements;
public class ViewChannelAnnouncementsQueryHandler : IHandler<ViewChannelAnnouncementsQuery, List<ChannelAnnouncementReadModel>>
{
    private readonly IChannelAnnouncementRepository _channelAnnouncementsQuery;

    public ViewChannelAnnouncementsQueryHandler(IChannelAnnouncementRepository channelAnnouncementsQuery)
    {
        _channelAnnouncementsQuery = channelAnnouncementsQuery;
    }

    public async Task<List<ChannelAnnouncementReadModel>> Handle(ViewChannelAnnouncementsQuery request, CancellationToken cancellationToken)
    {
        var result = (await _channelAnnouncementsQuery.GetAllAsync())
        .Skip((request.PageNumber - 1) * request.PageSize)
        .Take(request.PageNumber);
        return result.Adapt<List<ChannelAnnouncementReadModel>>();
    }
}
