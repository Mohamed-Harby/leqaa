using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Queries.Channels.ViewChannel;
public class ViewChannelqueryHandler : IHandler<ViewChannelQuery, ErrorOr<ChannelReadModel>>
{
    private readonly IChannelRepository _channelRepository;
    public ViewChannelqueryHandler(IChannelRepository channelRepository)
    {
        _channelRepository = channelRepository;
    }

    public async Task<ErrorOr<ChannelReadModel>> Handle(ViewChannelQuery request, CancellationToken cancellationToken)
    {
        var channel = await _channelRepository.GetAsync(c => c.Id == request.Id, null!, "ChannelAnnouncements");
        if (channel is null)
        {
            return DomainErrors.Channel.NotFound;
        }
        return channel.Adapt<ChannelReadModel>();
    }
}
