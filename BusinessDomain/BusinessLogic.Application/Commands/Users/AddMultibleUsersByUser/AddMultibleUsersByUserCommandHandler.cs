using BusinessLogic.Application.Commands.Users.AddUserByUser;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Commands.Users.AddMultibleUsersByUser
{
    public class AddMultibleUsersByUserCommandHandler : IRequestHandler<AddMultibleUsersByUserCommand, ErrorOr<List<UserReadModel>>>
    {
        private readonly IUserHubRepository _userChannelRepository;
        private readonly IUserHubRepository _userHubRepository;
        private readonly IHubRepository _hubRepository;
        private readonly IUserRepository _userRepository;

        public AddMultibleUsersByUserCommandHandler(IUserRepository userRepository,
            IUserHubRepository userChannelRepository,
            IUserHubRepository userHubRepository,
            IHubRepository hubRepository)
        {
            _userRepository = userRepository;
            _userChannelRepository = userChannelRepository;
            _userHubRepository = userHubRepository;
            _hubRepository = hubRepository;
        }

        public async Task<ErrorOr<List<UserReadModel>>> Handle(AddMultibleUsersByUserCommand request, CancellationToken cancellationToken)

        {
            var addingUser = (await _userRepository.GetAsync(u => u.UserName == request.UserName, null, "")).FirstOrDefault()!;
            var hub = await _hubRepository.GetByIdAsync(request.HubId);

            if (addingUser == null || hub == null)
            {
                return DomainErrors.User.NotFound;
            }

            UserHub userHub = (await _userHubRepository.GetAsync(uh => uh.UserId == addingUser.Id && uh.HubId == hub.Id, null, "")).FirstOrDefault()!;
            if (userHub == null)
            {
                return DomainErrors.User.NotFound;
            }

            var addedUsers = new List<User>();
            foreach (var addedUserName in request.AddedUserNames)
            {
                User addedUser = (await _userRepository.GetAsync(u => u.UserName == addedUserName,null,"")).FirstOrDefault()!;
                if (addedUser == null)
                {
                    return DomainErrors.User.NotFound;
                }

                var newUserHub = new UserHub
                {
                    UserId = addedUser.Id,
                    HubId = hub.Id
                };

                await _userHubRepository.AddAsync(newUserHub);
                addedUsers.Add(addedUser);
            }

            await _userHubRepository.SaveAsync();
            foreach (var user in addedUsers)
            {
                user.Hubs.Add(hub);
            }
            
            await _hubRepository.UpdateAsync(hub);
            await _hubRepository.SaveAsync(cancellationToken);

            return addedUsers.Adapt<List<UserReadModel>>();
        }

       
    }
}
