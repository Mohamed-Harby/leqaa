using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Application.Queries.Users.ViewFollowed;
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
    public class ViewFollowedQueryHandler : IHandler<ViewFollowedQuery, ErrorOr<List<UserReadModel>>>
    {

        private readonly IUserRepository _userRepository;
        private readonly IUserUserRepository _userUserRepository;
        private readonly ICacheService _cacheService;
        public ViewFollowedQueryHandler(IUserRepository userRepository, IUserUserRepository userUserRepository, ICacheService cacheService)
        {
            _userRepository = userRepository;
            _userUserRepository = userUserRepository;
            _cacheService = cacheService;
        }
        public async Task<ErrorOr<List<UserReadModel>>> Handle(ViewFollowedQuery request, CancellationToken cancellationToken)
        {
            /*   IQueryable<User> followedUsers;*/




            var CachedData = await _cacheService.GetAsync<IEnumerable<User>>("viewfollowed");

            if (CachedData != null && CachedData.Count() > 0)
            {
                return CachedData.Adapt<List<UserReadModel>>();
            }



            var followedUsersIDs = (await _userUserRepository.GetAsync(u => u.FollowerId == request.UserId))
           .Select(f => f.FollowedId)
           .ToList();

            var followedUsers = (await _userRepository.GetAllAsync())
         .Where(u => followedUsersIDs.Contains(u.Id))
           .ToList();



            var expiryTime = DateTime.Now.AddSeconds(30);
            _cacheService.SetData<IEnumerable<User>>("viewfollowed", followedUsers, expiryTime);







            var Users = followedUsers.Adapt<List<UserReadModel>>();


            return Users;







       
        }
    }
}
