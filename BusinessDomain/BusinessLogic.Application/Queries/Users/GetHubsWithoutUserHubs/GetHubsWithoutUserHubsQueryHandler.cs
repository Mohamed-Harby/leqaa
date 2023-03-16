using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Application.Queries.Hubs.GetAllHubs;
using BusinessLogic.Domain;
using ErrorOr;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Queries.Hubs.GetHubsWithoutUserHubs
{
    public class GetHubsWithoutUserHubsHandler : IHandler<GetHubsWithoutUserHubsQuery, ErrorOr<List<HubReadModel>>>
    {
        private readonly IHubRepository _hubRepository;

        private readonly IUserHubRepository _userHubRepository;

        private readonly IUserRepository _userRepository;


        public GetHubsWithoutUserHubsHandler(IHubRepository hubRepository, IUserRepository userRepository, IUserHubRepository userHubRepository)
        {
            _hubRepository = hubRepository;

            _userRepository = userRepository;

            _userHubRepository = userHubRepository;
        }




        public async Task<ErrorOr<List<HubReadModel>>> Handle(GetHubsWithoutUserHubsQuery request, CancellationToken cancellationToken)
        {
            List<Hub> Hubs = new();


            User? user = (await _userRepository.GetAsync(c => c.UserName == request.UserName)).FirstOrDefault()!;

            var UserHubsNotContainUser = (await _userHubRepository.GetAsync(u => u.UserId != user.Id)).ToList();

            foreach (var userhub in UserHubsNotContainUser)
            {
                var hub = (await _hubRepository.GetByIdAsync(userhub.HubId));
                Hubs.Add(hub);

            }


            var result = Hubs.Adapt<List<HubReadModel>>();



            return result;

        }
    }

}