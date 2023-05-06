using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Queries.channels.ViewChannels;
using BusinessLogic.Domain;
using Mapster;

namespace BusinessLogic.Application.Queries.Channels.VewChannels;
public class GetAllChannelsQueryHandler : IHandler<ViewChannelsQuery, List<ChannelReadModel>>
{
    private readonly IChannelRepository _channelRepository;
    private readonly ICacheService _cacheService;

    public GetAllChannelsQueryHandler(IChannelRepository channelRepository, ICacheService cacheService)
    {
        _channelRepository = channelRepository;
        _cacheService = cacheService;
    }

    public async Task<List<ChannelReadModel>> Handle(ViewChannelsQuery request, CancellationToken cancellationToken)
    {

        var CachedData = await _cacheService.GetAsync<IEnumerable<Channel>>("channels");

        if (CachedData != null && CachedData.Count() > 0)
        {
            return CachedData.Adapt<List<ChannelReadModel>>();
        }

        var channels = await _channelRepository.GetAllAsync();

        var expiryTime = DateTime.Now.AddSeconds(30);
        _cacheService.SetData<IEnumerable<Channel>>("channels", channels, expiryTime);



        var skip = (request.PageNumber - 1) * request.PageSize;
        return (await _channelRepository.GetAsync(null!, null!, ""))
            .Skip(skip)
            .Take(request.PageSize)
            .ToList()
            .Adapt<List<ChannelReadModel>>();


    }


}
