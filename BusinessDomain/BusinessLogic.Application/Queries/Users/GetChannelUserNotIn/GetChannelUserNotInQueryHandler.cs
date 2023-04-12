using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Application.Queries.Hubs.GetHubsWithoutUserHubs;
using BusinessLogic.Domain;
using ErrorOr;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Queries.Users.GetChannelUserNotIn
{
    public class GetChannelUserNotInQueryHandler : IHandler<GetChannelUserNotInQuery, ErrorOr<List<ChannelReadModel>>>
    {

        private readonly IChannelRepository _channelRepository;
        private readonly IUserChannelRepository _userChannelRepository;
        private readonly IUserRepository _userRepository;

        public GetChannelUserNotInQueryHandler(IChannelRepository channelRepository,
            IUserChannelRepository userChannelRepository,
            IUserRepository userRepository
            )
        {
            _channelRepository = channelRepository;
            _userChannelRepository = userChannelRepository;
            _userRepository = userRepository;

        }
        public async Task<ErrorOr<List<ChannelReadModel>>> Handle(GetChannelUserNotInQuery request, CancellationToken cancellationToken)
        {
            User user= (await _userRepository.GetAsync(u=>u.UserName==request.userName,null,"")).FirstOrDefault()!;
            var userChannels = await _userChannelRepository.GetAsync(uc => uc.UserId ==user.Id);

            var joinedChannelIds = userChannels.Select(uc => uc.ChannelId);

            var channels = await _channelRepository.GetAsync(c => !joinedChannelIds.Contains(c.Id));

            return channels.Adapt<List<ChannelReadModel>>();
        }
    }
}
