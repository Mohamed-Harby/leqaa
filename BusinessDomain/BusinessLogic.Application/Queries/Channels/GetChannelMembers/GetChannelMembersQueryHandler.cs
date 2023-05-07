using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Domain.Common.Errors;
using ErrorOr;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Queries.Channels.GetChannelMembers
{
    public class GetChannelMembersQueryHandler:IHandler<GetChannelMembersQuery,ErrorOr<List<UserReadModel>>>
    {

        private readonly IChannelRepository _channelRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserChannelRepository _userChannelRepository;
  
        public GetChannelMembersQueryHandler(IChannelRepository channelRepository,
            IUserRepository userRepository,
            IUserChannelRepository userChannelRepository
            
            )
        {
            _channelRepository = channelRepository;
            _userRepository = userRepository;
            _userChannelRepository = userChannelRepository;
        }

        public async Task<ErrorOr<List<UserReadModel>>> Handle(GetChannelMembersQuery request, CancellationToken cancellationToken)
        {
            var channel=await _channelRepository.GetByIdAsync( request.ChannelId );
            if ( channel == null )
            {
                return DomainErrors.Channel.NotFound;
            }

            var ChannelMembersIds= (await _userChannelRepository.GetAsync(uc=>uc.ChannelId== request.ChannelId ))
                .Select(uId=>uId.UserId).ToList();

            var ChannelMembers = (await _userRepository.GetAllAsync())
         .Where(u => ChannelMembersIds.Contains(u.Id))
           .ToList();

            if (ChannelMembers.Any() )
            {
                return ChannelMembers.Adapt<List<UserReadModel>>(); 
            }
            return DomainErrors.Channel.NotFound;
        }
    }
}
