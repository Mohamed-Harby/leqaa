using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Users.BuyPlan;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Plans;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using BusinessLogic.Domain.Plan;
using ErrorOr;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Commands.Users.AddUserByUser
{

    public class AddUserByUserCommandHandler : IHandler<AddUserByUserCommand, ErrorOr<UserReadModel>>
    {

        private readonly IUserChannelRepository _userChannelRepository;
        private readonly IUserHubRepository _userHubRepository;
        private readonly IHubRepository _hubRepository;
        private readonly IChannelRepository _channelRepository;
        private readonly IUserRepository _userRepository;

        public AddUserByUserCommandHandler(IPlanRepository planRepository,
            IUserRepository userRepository,
            IUserChannelRepository userChannelRepository,
            IUserHubRepository userHubRepository,
            IHubRepository hubRepository,
            IChannelRepository channelRepository)
        {
            _userRepository = userRepository;
            _userChannelRepository = userChannelRepository;
            _userHubRepository = userHubRepository;
            _hubRepository = hubRepository;
            _channelRepository = channelRepository;
        }

        public async Task<ErrorOr<UserReadModel>> Handle(AddUserByUserCommand request, CancellationToken cancellationToken)
        {
            User addingUser = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault()!;

            User addedUser = (await _userRepository.GetAsync(u => u.UserName == request.addedUser)).FirstOrDefault()!;

            var hub = await _hubRepository.GetByIdAsync(request.hupId);

            if(addedUser== null|| addingUser==null)
            {
                return DomainErrors.User.NotFound;
            }

            var userHub = await _userHubRepository.GetAsync(uh => uh.UserId == addingUser.Id && uh.HubId == hub.Id);
            if (userHub == null)
            {
                return DomainErrors.User.NotFound;
            }



            var newUserHub = new UserHub
            {
                UserId = addedUser.Id,
                HubId = hub.Id
            };


            await _userHubRepository.AddAsync(newUserHub);
            await _userHubRepository.SaveAsync();
            hub.AddUser(addedUser);
            await _hubRepository.UpdateAsync(hub);
            await _hubRepository.SaveAsync(cancellationToken);

            return addedUser.Adapt<UserReadModel>();
        }
    }
}
