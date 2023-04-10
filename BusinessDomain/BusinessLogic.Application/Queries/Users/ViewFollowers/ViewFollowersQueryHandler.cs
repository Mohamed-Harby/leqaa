using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
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
        public ViewFollowersQueryHandler(IUserRepository userRepository, IUserUserRepository userUserRepository)
        {
            _userRepository = userRepository;
            _userUserRepository = userUserRepository;
        }
        public async Task<ErrorOr<List<UserReadModel>>> Handle(ViewFollowersQuery request, CancellationToken cancellationToken)
        {
         /*   IQueryable<User> followedUsers;*/
            var followerUsersIDs = (await _userUserRepository.GetAsync(u=>u.FollowedId == request.UserId))
           .Select(f => f.FollowerId)
           .ToList();

            var followedUsers =(await  _userRepository.GetAllAsync())
         .Where(u => followerUsersIDs.Contains(u.Id))
           .ToList()
        .Adapt<List<UserReadModel>>();


            return followedUsers;
        }
    }
}
