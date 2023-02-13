using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Queries.Hubs.GetAllHubs;
using Mapster;

namespace BusinessLogic.Application.Queries.channels.GetAllchannels;
public class GetAllChannelsQueryHandler : IHandler<GetAllChannelsQuery, List<ChannelReadModel>>
{
    private readonly IChannelRepository _channelRepository;

    public GetAllChannelsQueryHandler(IChannelRepository channelRepository)
    {
        _channelRepository = channelRepository;
    }

    public async Task<List<ChannelReadModel>> Handle(GetAllChannelsQuery request, CancellationToken cancellationToken)
    {
        return (await _channelRepository.GetAllAsync())
            .ToList()
            .Adapt<List<ChannelReadModel>>();
    }


}
