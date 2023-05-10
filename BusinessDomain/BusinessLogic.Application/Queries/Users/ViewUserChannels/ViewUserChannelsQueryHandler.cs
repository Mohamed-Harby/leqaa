﻿using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.CreateChannel;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using BusinessLogic.Domain.Common.Errors;
using ErrorOr;
using FluentValidation;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BusinessLogic.Application.Queries.Users.ViewUserChannels
{
    public class ViewUserChannelsQueryHandler : IHandler<ViewUserChannelsQuery, ErrorOr<List<ChannelReadModel>>>
    {
        private readonly IChannelRepository _channelRepository;
        private readonly IHubRepository _hubRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserHubRepository _userChannelRepository;
       
        public ViewUserChannelsQueryHandler(
            IChannelRepository channelRepository,
            IHubRepository hubRepository,
            IUserRepository userRepository,
            IUserHubRepository userChannelRepository,
            IValidator<CreateChannelCommand> validator
        )
        {
            _channelRepository = channelRepository;
            _hubRepository = hubRepository;
            _userRepository = userRepository;
            _userChannelRepository = userChannelRepository;
           
        }
        public async Task<ErrorOr<List<ChannelReadModel>>> Handle(ViewUserChannelsQuery request, CancellationToken cancellationToken)
        {


      

            var user = await _userRepository.GetUserWithChannelsIncludingAnnouncements(request.UserName);
            var channels = user!.Channels.ToList();



            


         

          

            return channels
        .Adapt<List<ChannelReadModel>>();




        }


    }

}
