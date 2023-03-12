using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models;
using Mapster;

namespace BusinessLogic.Application.Queries.Channels.ViewRecentActivities;
public class ViewChannelRecentActivitiesQueryHandler : IHandler<ViewChannelRecentActivitiesQuery, List<BaseReadModel>>
{
    private readonly IChannelRepository _channelRepository;

    public ViewChannelRecentActivitiesQueryHandler(IChannelRepository channelRepository)
    {
        _channelRepository = channelRepository;
    }

    public async Task<List<BaseReadModel>> Handle(ViewChannelRecentActivitiesQuery request, CancellationToken cancellationToken)
    {
        var recentActivities = await _channelRepository.GetRecentActivitiesAsync(request.Id, request.PageNumber, request.PageSize);
        return recentActivities.Adapt<List<BaseReadModel>>();
    }
}
