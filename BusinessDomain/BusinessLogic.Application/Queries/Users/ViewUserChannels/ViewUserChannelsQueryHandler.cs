using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.CreateChannel;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using FluentValidation;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BusinessLogic.Application.Queries.Users.ViewUserChannels
{
    public class ViewUserChannelsQueryHandler : IHandler<ViewUserChannelsQuery, ErrorOr<List<ChannelReadModel>>>
    {
        private readonly IChannelRepository _channelRepository;
        private readonly IHubRepository _hubRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserHubRepository _userChannelRepository;
        private readonly ICacheService _cacheService;
        public ViewUserChannelsQueryHandler(
            IChannelRepository channelRepository,
            IHubRepository hubRepository,
            IUserRepository userRepository,
            IUserHubRepository userChannelRepository,
            IValidator<CreateChannelCommand> validator,
            ICacheService cacheService)
        {
            _channelRepository = channelRepository;
            _hubRepository = hubRepository;
            _userRepository = userRepository;
            _userChannelRepository = userChannelRepository;
            _cacheService = cacheService;
        }
        public async Task<ErrorOr<List<ChannelReadModel>>> Handle(ViewUserChannelsQuery request, CancellationToken cancellationToken)
        {


            var CachedData = await _cacheService.GetAsync<IEnumerable<Post>>("userChannels");

            if (CachedData != null && CachedData.Count() > 0)
            {
                return CachedData.Adapt<List<ChannelReadModel>>();
            }

            var user = await _userRepository.GetUserWithChannelsIncludingAnnouncements(request.UserName);
            var channels = user!.Channels.ToList();



            var expiryTime = DateTime.Now.AddSeconds(30);
            _cacheService.SetData<IEnumerable<Channel>>("userChannels", channels, expiryTime);


         

          

            return channels
        .Adapt<List<ChannelReadModel>>();




        }


    }

}
