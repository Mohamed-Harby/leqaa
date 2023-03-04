using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.CreateChannel;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Application.Queries.Users.ViewUserHubs;
using BusinessLogic.Application.Queries.Users.ViewUserPosts;
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

namespace BusinessLogic.Application.Queries.Users.ViewUserPosts
{
    public class ViewUserPostsQueryHandler : IHandler<ViewUserPostsQuery, ErrorOr<List<PostReadModel>>>
    {
        private readonly IChannelRepository _channelRepository;
        private readonly IHubRepository _hubRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserChannelRepository _userChannelRepository;

        public ViewUserPostsQueryHandler(
            IChannelRepository channelRepository,
            IHubRepository hubRepository,
            IUserRepository userRepository,
            IUserChannelRepository userChannelRepository)
        {
            _channelRepository = channelRepository;
            _hubRepository = hubRepository;
            _userRepository = userRepository;
            _userChannelRepository = userChannelRepository;
        }
        public async Task<ErrorOr<List<PostReadModel>>> Handle(ViewUserPostsQuery request, CancellationToken cancellationToken)
        {

            var user = (await _userRepository.GetAsync(u => u.UserName == request.userName, null!, "Posts")).FirstOrDefault();
            if (user is null)
            {
                return DomainErrors.User.NotFound;
            }

            var posts = user.Posts.ToList();




            if (posts.Count == 0)
            {
                return DomainErrors.Post.NotFound;
            }



            return posts
            .Adapt<List<PostReadModel>>();




        }


    }

}
