using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Application.Queries.Hubs.GetHubsWithoutUserHubs;
using ErrorOr;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Queries.Users.GetFollowedUsersCount
{



    public class GetFollowedUsersQueryHandler : IHandler<GetFollowedUsersCountQuery, ErrorOr<int>>
    {
        private readonly IHubRepository _hubRepository;

        private readonly IUserHubRepository _userHubRepository;

        private readonly IUserRepository _userRepository;
        private readonly IUserUserRepository _userUserRepository;

        public GetFollowedUsersQueryHandler(IHubRepository hubRepository,
            IUserRepository userRepository,
            IUserHubRepository userHubRepository,
            IUserUserRepository userUserRepository)
        {
            _hubRepository = hubRepository;

            _userRepository = userRepository;

            _userHubRepository = userHubRepository;
            _userUserRepository = userUserRepository;
        }

        public async Task<ErrorOr<int>> Handle(GetFollowedUsersCountQuery request, CancellationToken cancellationToken)
        {
            var followedUsersCount = await _userUserRepository.GetAsync(u => u.FollowedId == request.UserId, null, "");
              if (followedUsersCount == null)
            {
                return 0;
            }
            return followedUsersCount.Count();
          
        }
    }

        
    
} 
