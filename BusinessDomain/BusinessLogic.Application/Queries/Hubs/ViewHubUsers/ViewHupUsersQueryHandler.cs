using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Application.Queries.Hubs.GetAllHubs;
using BusinessLogic.Application.Queries.Hubs.GetHubsWithoutUserHubs;
using BusinessLogic.Domain;
using ErrorOr;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Queries.Hubs.viewHubUsers
{
    public class ViewHupUsersQueryHandler : IHandler<ViewHupUsersQuery, ErrorOr<List<UserReadModel>>>
    {
        private readonly IHubRepository _hubRepository;

        private readonly IUserHubRepository _userHubRepository;

        private readonly IUserRepository _userRepository;

        public ViewHupUsersQueryHandler(IHubRepository hubRepository, IUserRepository userRepository, IUserHubRepository userHubRepository)
        {
            _hubRepository = hubRepository;

            _userRepository = userRepository;

            _userHubRepository = userHubRepository;
        }




        public async Task<ErrorOr<List<UserReadModel>>> Handle(ViewHupUsersQuery request, CancellationToken cancellationToken)
        {

            List<User> users = new();
            var hubs = (await _hubRepository.GetAsync(c => c.Id == request.hubid, null, "Users")).FirstOrDefault()!;


            /*   foreach(var userHub in userHubs)
               {
                   var userId = userHub.UserId;
                   User user= await _userRepository.GetByIdAsync(userId);
                   users.Add(user);
               }*/
            return hubs.Users.Adapt<List<UserReadModel>>();




        }
    }

}