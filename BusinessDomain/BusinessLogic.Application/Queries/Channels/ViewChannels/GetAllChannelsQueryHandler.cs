using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Queries.channels.ViewChannels;
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
        var skip = (request.PageNumber - 1) * request.PageSize;
        return (await _channelRepository.GetAsync(null!, null!, "ChannelAnnouncements"))
            .Skip(skip)
            .Take(request.PageSize)
            .ToList()
            .Adapt<List<ChannelReadModel>>();


    }


}
