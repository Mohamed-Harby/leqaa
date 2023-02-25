using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Queries.channels.ViewChannels;
using Mapster;

namespace BusinessLogic.Application.Queries.channels.GetAllchannels;
public class GetAllChannelsQueryHandler : IHandler<ViewRoomQuery, List<ChannelReadModel>>
{
    private readonly IChannelRepository _channelRepository;

    public GetAllChannelsQueryHandler(IChannelRepository channelRepository)
    {
        _channelRepository = channelRepository;
    }

    public async Task<List<ChannelReadModel>> Handle(ViewRoomQuery request, CancellationToken cancellationToken)
    {
        var channels = (await _channelRepository.GetAllAsync())

            .Where(c => c.Id.CompareTo(request.Cursor) > 0)
            .OrderBy(c => c.Id)
            .Take(request.Limit)
            .ToList()
            .Adapt<List<ChannelReadModel>>();

        return channels;
    }


}
