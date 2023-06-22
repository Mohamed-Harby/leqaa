using BusinessLogic.Application.Commands.Users.AddUserByUser;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Domain;
using BusinessLogic.Domain.Common.Errors;
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
            var addingUser = (await _userRepository.GetAsync(n => n.UserName == request.UserName, null, "")).FirstOrDefault();
            var hub = await _hubRepository.GetByIdAsync(request.HubId);

            if (addingUser == null || hub == null)
            {
                return DomainErrors.User.NotFound;
            }

            var addedUsers = new List<User>();
            foreach (var addedUserName in request.AddedUserNames)
            {
                var addedUser = (await _userRepository.GetAsync(n => n.UserName == addedUserName, null, "")).FirstOrDefault();
                if (addedUser == null)
                {
                    return DomainErrors.User.NotFound;
                }

                var existingUserHub = (await _userHubRepository.GetAsync(uh => uh.UserId == addedUser.Id && uh.HubId == hub.Id, null, "")).FirstOrDefault()!;
                if (existingUserHub ==null)
                {


                    var newUserHub = new UserHub
                    {
                        UserId = addedUser.Id,
                        HubId = hub.Id
                    };

                    addedUser.Hubs.Add(hub);

                    await _userHubRepository.AddAsync(newUserHub);
                    addedUsers.Add(addedUser);


                    await _userHubRepository.SaveAsync();
                }
                else
                {
                    // UserHub entry already exists, skip adding the user
                    continue;
                }

              
            }

            await _userHubRepository.SaveAsync();
            await _userRepository.UpdateAsync(addingUser);
            await _userRepository.SaveAsync(cancellationToken);

            return addedUsers.Adapt<List<UserReadModel>>();
        }
    }
}
