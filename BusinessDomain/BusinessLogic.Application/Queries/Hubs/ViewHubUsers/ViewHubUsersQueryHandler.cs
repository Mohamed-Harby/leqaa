using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Application.Queries.Hubs.GetAllHubs;
using BusinessLogic.Application.Queries.Hubs.GetHubsWithoutUserHubs;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Queries.Hubs.viewHubUsers
{
    public class ViewHubUsersQueryHandler : IHandler<ViewHubUsersQuery, ErrorOr<List<UserRecentReadModel>>>
    {
        private readonly IHubRepository _hubRepository;

        private readonly IUserHubRepository _userHubRepository;

        private readonly IUserRepository _userRepository;

        public ViewHubUsersQueryHandler(IHubRepository hubRepository, IUserRepository userRepository, IUserHubRepository userHubRepository)
        {
            _hubRepository = hubRepository;

            _userRepository = userRepository;

            _userHubRepository = userHubRepository;
        }




        public async Task<ErrorOr<List<UserRecentReadModel>>> Handle(ViewHubUsersQuery request, CancellationToken cancellationToken)
        {


            var hubs = (await _hubRepository.GetAsync(c => c.Id == request.hubid, null, "JoinedUsers"))
                .FirstOrDefault()!;
            
   
            
         
            return hubs.JoinedUsers.Adapt<List<UserRecentReadModel>>();




        }
    }

}