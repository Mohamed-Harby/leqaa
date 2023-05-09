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


    public GetAllChannelsQueryHandler(IChannelRepository channelRepository)
    {
        _channelRepository = channelRepository;
    }

    public async Task<List<ChannelReadModel>> Handle(ViewChannelsQuery request, CancellationToken cancellationToken)
    {



        var channels = await _channelRepository.GetAllAsync();

     



        var skip = (request.PageNumber - 1) * request.PageSize;
        return (await _channelRepository.GetAsync(null!, null!, ""))
            .Skip(skip)
            .Take(request.PageSize)
            .ToList()
            .Adapt<List<ChannelReadModel>>();


    }


}
