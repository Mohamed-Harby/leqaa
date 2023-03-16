using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Queries.Hubs.GetAllHubs;
using ErrorOr;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Queries.Hubs.viewHubChannels
{
    public class ViewHubChannelsQueryHandler : IHandler<ViewHubChannelsQuery, ErrorOr<List<ChannelReadModel>>>
    {
        private readonly IHubRepository _hubRepository;

        private readonly IChannelRepository _channelRepository;

        public ViewHubChannelsQueryHandler(IHubRepository hubRepository, IChannelRepository channelRepository)
        {
            _hubRepository = hubRepository;
            _channelRepository = channelRepository;

        }







        public async Task<ErrorOr<List<ChannelReadModel>>> Handle(ViewHubChannelsQuery request, CancellationToken cancellationToken)
        {
            var channels = await _channelRepository.GetAsync(c => c.HubId == request.hubid, null, "");
            var hupChannels = channels.Adapt<List<ChannelReadModel>>();
            return hupChannels;


        }
    }

}