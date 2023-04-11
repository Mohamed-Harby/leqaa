using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Users.LeaveChannel;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain.SharedEnums;
using BusinessLogic.Domain.DomainErrors;
using BusinessLogic.Domain.DomainSucceeded.User;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Application.Commands.Pin.DeletePin.DeletePinnedHub;
using BusinessLogic.Application.Models.Hubs;
using MediatR;

namespace BusinessLogic.Application.Commands.Pin.DeletePin.DeletePinnedHub
{
    public class DeletePinnedHubCommandHandler : IHandler<DeletePinnedHubCommand, ErrorOr<HubReadModel>>
    {

        private readonly IUserPinnedHubRepository _userPinnedHubRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHubRepository _hubRepository;
        private readonly IUserChannelRepository _userChannelRepository;
        private readonly IChannelRepository _channelRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeletePinnedHubCommandHandler(
            IUserPinnedHubRepository userPinnedHubRepository,
            IHubRepository hubRepository,
            IUserChannelRepository userChannelRepository,
            IUserRepository userRepository,
            IChannelRepository channelRepository,
            IUnitOfWork unitOfWork)
        {

            _userPinnedHubRepository = userPinnedHubRepository;


            _userRepository = userRepository;
            _hubRepository = hubRepository;
            _userChannelRepository = userChannelRepository;

            _channelRepository = channelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<HubReadModel>> Handle(DeletePinnedHubCommand request, CancellationToken cancellationToken)
        {
            var user = (await _userRepository.GetAsync(u => u.UserName == request.userName)).FirstOrDefault()!;
            var hub = await _hubRepository.GetByIdAsync(request.HubId);

            if (hub is null)
            {
                return DomainErrors.Hub.NotFound;
            }
            var userPinnedHub = (await _userPinnedHubRepository.GetAsync(uh => uh.UserPinnedid== user.Id && uh.PinnedHubId == hub.Id
            )).FirstOrDefault()!;
            if (userPinnedHub is null)
            {
                return DomainErrors.UserHub.NotJoined;
            }
           
            hub.PinningUsers.Remove(user);
            if (await _unitOfWork. SaveAsync(cancellationToken) == 0)
            {
                return DomainErrors.Hub.InvalidHub;
            }
            return DomainSucceded.User.ChannelUnPinned;
        }

       
    }
}
    

