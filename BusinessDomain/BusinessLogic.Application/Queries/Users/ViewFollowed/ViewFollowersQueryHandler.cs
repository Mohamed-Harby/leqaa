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
        public ViewFollowedQueryHandler(IUserRepository userRepository, IUserUserRepository userUserRepository)
        {
            _userRepository = userRepository;
            _userUserRepository = userUserRepository;
     
        }
        public async Task<ErrorOr<List<UserReadModel>>> Handle(ViewFollowedQuery request, CancellationToken cancellationToken)
        {
            /*   IQueryable<User> followedUsers;*/




    


            var followedUsersIDs = (await _userUserRepository.GetAsync(u => u.FollowerId == request.UserId))
           .Select(f => f.FollowedId)
           .ToList();

            var followedUsers = (await _userRepository.GetAllAsync())
         .Where(u => followedUsersIDs.Contains(u.Id))
           .ToList();



       






            var Users = followedUsers.Adapt<List<UserReadModel>>();


            return Users;







       
        }
    }
}
