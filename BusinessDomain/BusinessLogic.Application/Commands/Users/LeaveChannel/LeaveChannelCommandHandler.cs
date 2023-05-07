﻿using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Users.JoinHub;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Hubs;
using ErrorOr;
using BusinessLogic.Domain.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using System.Diagnostics.Metrics;
using System.Reflection;
using BusinessLogic.Domain.SharedEnums;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainSucceeded.User;
using BusinessLogic.Application.Models.Channels;

namespace BusinessLogic.Application.Commands.Users.LeaveChannel
{

    public class LeaveChannelCommandHandler : IHandler<LeaveChannelCommand, ErrorOr<ChannelReadModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHubRepository _hubRepository;
        private readonly IUserChannelRepository _userChannelRepository;
        private readonly IChannelRepository _channelRepository;
        public LeaveChannelCommandHandler(
            IUserRepository userRepository,
            IHubRepository hubRepository,
            IUserChannelRepository userChannelRepository,

            IChannelRepository channelRepository)
        {
            _userRepository = userRepository;
            _hubRepository = hubRepository;
            _userChannelRepository = userChannelRepository;

            _channelRepository = channelRepository;

        }

        public async Task<ErrorOr<ChannelReadModel>> Handle(LeaveChannelCommand request, CancellationToken cancellationToken)
        {
            var user = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault()!;
            var channel = await _channelRepository.GetByIdAsync(request.ChannelId);

            if (channel is null)
            {
                return DomainErrors.Channel.NotFound;
            }
            var userChannel = (await _userChannelRepository.GetAsync(uh => uh.UserId == user.Id && uh.ChannelId == channel.Id
            )).FirstOrDefault()!;
            if (userChannel is null)
            {
                return DomainErrors.UserChannel.NotJoined;
            }
     
            channel.JoinedUsers.Remove(user);


            if ((await _userChannelRepository.GetAsync(uc => uc.ChannelId == channel.Id, null, "")) 
                .Count()==1) {
                _channelRepository.Remove(channel);
                await _channelRepository.SaveAsync(cancellationToken);
                return DomainSucceded.User.channelLeftAndDeleted;

            }
            await _channelRepository.SaveAsync(cancellationToken);
            return DomainSucceded.User.ChannelLeft;
        }
    }
}