using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Domain;
using ErrorOr;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Queries.Users.ViewFollowers
{
    public class ViewFollowersQueryHandler : IHandler<ViewFollowersQuery, ErrorOr<List<UserReadModel>>>
    {

        private readonly IUserRepository _userRepository;
        private readonly IUserUserRepository _userUserRepository;
        private readonly ICacheService _cacheService;
        public ViewFollowersQueryHandler(IUserRepository userRepository, IUserUserRepository userUserRepository, ICacheService cacheService)
        {
            _userRepository = userRepository;
            _userUserRepository = userUserRepository;
            _cacheService = cacheService;
        }
        public async Task<ErrorOr<List<UserReadModel>>> Handle(ViewFollowersQuery request, CancellationToken cancellationToken)
        {
            /*   IQueryable<User> followedUsers;*/



     

            var followerUsersIDs = (await _userUserRepository.GetAsync(u => u.FollowedId == request.UserId))
         .Select(f => f.FollowerId)
         .ToList();
            var followedUsers = (await _userRepository.GetAllAsync())
           .Where(u => followerUsersIDs.Contains(u.Id))
           .ToList();



           






            var Users = followedUsers.Adapt<List<UserReadModel>>();


            return Users;
        }
    }
}
