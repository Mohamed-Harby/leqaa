using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
using ErrorOr;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Queries.Users.GetFollowerUsersCount
{



    public class GetFollowerUsersCountHandler : IHandler<GetFollowerUsersCountQuery, ErrorOr<int>>
    {
        private readonly IHubRepository _hubRepository;

        private readonly IUserHubRepository _userHubRepository;

        private readonly IUserRepository _userRepository;
        private readonly IUserUserRepository _userUserRepository;

        public GetFollowerUsersCountHandler(IHubRepository hubRepository,
            IUserRepository userRepository,
            IUserHubRepository userHubRepository,
            IUserUserRepository userUserRepository)
        {
            _hubRepository = hubRepository;

            _userRepository = userRepository;

            _userHubRepository = userHubRepository;
            _userUserRepository = userUserRepository;
        }





        public async Task<ErrorOr<int>> Handle(GetFollowerUsersCountQuery request, CancellationToken cancellationToken)
        {
            var followedUsersCount = await _userUserRepository.GetAsync(u => u.FollowerId==request.UserId, null!, "");
            int FRcount = followedUsersCount.Count();
            if (FRcount == 0)
            {
                return 0;
            }

            return FRcount;
        }
    }
}

