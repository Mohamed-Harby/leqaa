using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.CreateChannel;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using FluentValidation;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Queries.Users.ViewUserChannels
{
    public class ViewUserChannelsQueryHandler : IHandler<ViewUserChannelsQuery, ErrorOr<List<ChannelReadModel>>>
    {
        private readonly IChannelRepository _channelRepository;
        private readonly IHubRepository _hubRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserChannelRepository _userChannelRepository;
        private readonly IValidator<CreateChannelCommand> _validator;

        public ViewUserChannelsQueryHandler(
            IChannelRepository channelRepository,
            IHubRepository hubRepository,
            IUserRepository userRepository,
            IUserChannelRepository userChannelRepository,
            IValidator<CreateChannelCommand> validator)
        {
            _channelRepository = channelRepository;
            _hubRepository = hubRepository;
            _userRepository = userRepository;
            _userChannelRepository = userChannelRepository;
            _validator = validator;
        }
        public async Task<ErrorOr<List<ChannelReadModel>>> Handle(ViewUserChannelsQuery request, CancellationToken cancellationToken)
        {

            var user = (await _userRepository.GetAsync(u => u.UserName == request.userName, null!, "Channels")).FirstOrDefault();
            if (user is null)
            {
                return DomainErrors.User.NotFound;
            }

            var channels = user.Channels.ToList();
            if (channels.Count == 0)
            {
                return DomainErrors.Channel.NotFound;
            }



            return channels
            .Adapt<List<ChannelReadModel>>();




        }


    }

}
