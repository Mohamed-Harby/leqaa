using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Users.LeaveChannel;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain.SharedEnums;
using BusinessLogic.Domain.Common.Errors;
using BusinessLogic.Domain.DomainSucceeded.User;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Commands.Pin.DeletePin.DeletePinnedChannel
{
    public class DeletePinnedChannelCommandHandler : IHandler<DeletePinnedChannelCommand, ErrorOr<ChannelReadModel>>
    {

        private readonly IUserPinnedChannelRepository _userPinnedChannelRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHubRepository _hubRepository;
        private readonly IUserChannelRepository _userChannelRepository;
        private readonly IChannelRepository _channelRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeletePinnedChannelCommandHandler(


            IUserPinnedChannelRepository userPinnedChannelRepository,
            IUserRepository userRepository,
            IHubRepository hubRepository,
            IUserChannelRepository userChannelRepository,

            IChannelRepository channelRepository,
            IUnitOfWork unitOfWork)
        {

            _userPinnedChannelRepository = userPinnedChannelRepository;
            _userRepository = userRepository;
            _hubRepository = hubRepository;
            _userChannelRepository = userChannelRepository;

            _channelRepository = channelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<ChannelReadModel>> Handle(DeletePinnedChannelCommand request, CancellationToken cancellationToken)
        {
            var user = (await _userRepository.GetAsync(u => u.UserName == request.userName)).FirstOrDefault()!;
            var channel = await _channelRepository.GetByIdAsync(request.ChannelId);

            if (channel is null)
            {
                return DomainErrors.Channel.NotFound;
            }
            var userPinnedChannel = (await _userPinnedChannelRepository.GetAsync(uh => uh.UserPinnedId== user.Id && uh.PinnedChannelId == channel.Id
            )).FirstOrDefault()!;
            if (userPinnedChannel is null)
            {
                return DomainErrors.UserChannel.NotJoined;
            }
           
            channel.PinningUsers.Remove(user);
            if (await _unitOfWork. SaveAsync(cancellationToken) == 0)
            {
                return DomainErrors.Channel.InvalidChannel;
            }
            return DomainSucceded.User.ChannelUnPinned;
        }
    }
}
    

