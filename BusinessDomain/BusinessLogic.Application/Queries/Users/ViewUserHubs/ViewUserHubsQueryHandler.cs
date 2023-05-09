using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.CreateChannel;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Application.Queries.Users.ViewUserHubs;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using FluentValidation;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Queries.Users.ViewUserHubs
{
    public class ViewUserPostsQueryHandler : IHandler<ViewUserHubsQuery, ErrorOr<List<HubReadModel>>>
    {
        private readonly ICacheService _cacheService;
        private readonly IChannelRepository _channelRepository;
        private readonly IHubRepository _hubRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserHubRepository _userChannelRepository;

        public ViewUserPostsQueryHandler(
            ICacheService cacheService,
            IChannelRepository channelRepository,
            IHubRepository hubRepository,
            IUserRepository userRepository,
            IUserHubRepository userChannelRepository)
        {
            _cacheService = cacheService;
            _channelRepository = channelRepository;
            _hubRepository = hubRepository;
            _userRepository = userRepository;
            _userChannelRepository = userChannelRepository;
        }
        public async Task<ErrorOr<List<HubReadModel>>> Handle(ViewUserHubsQuery request, CancellationToken cancellationToken)
        {




            /*
                        var CachedData = await _cacheService.GetAsync<IEnumerable<Hub>>("userHubs");

                        if (CachedData != null && CachedData.Count() > 0)
                        {
                            return CachedData.Adapt<List<HubReadModel>>();
                        }
            */




            var items = await _cacheService.handlCaching("items", async () => {


                return (await _userRepository.GetAsync(u => u.UserName == request.UserName, null!, "Hubs")).FirstOrDefault()!.Hubs.ToList();
            });

   
          


        /*    var expiryTime = DateTime.Now.AddSeconds(30);
            _cacheService.SetData<IEnumerable<Hub>>("userHubs", hubs, expiryTime);
*/
            


            return items
            .Adapt<List<HubReadModel>>();
        }


    }

}

