using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.CreateChannel;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Application.Queries.Users.ViewUserHubs;
using BusinessLogic.Application.Queries.Users.ViewUserPosts;
using BusinessLogic.Domain;
using BusinessLogic.Domain.Common.Errors;
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
        private readonly IUserHubRepository _userChannelRepository;
        private readonly IPostRepository _postRepository;

      

        public ViewUserPostsQueryHandler(
            IChannelRepository channelRepository,
            IHubRepository hubRepository,
            IUserRepository userRepository,
            IPostRepository postRepository,
            IUserHubRepository userChannelRepository

           )
        {
            _channelRepository = channelRepository;
            _hubRepository = hubRepository;
            _userRepository = userRepository;
            _userChannelRepository = userChannelRepository;
            _postRepository = postRepository;
           
        }
        public async Task<ErrorOr<List<PostReadModel>>> Handle(ViewUserPostsQuery request, CancellationToken cancellationToken)
        {



           

            var user = (await _userRepository.GetAsync(u => u.UserName == request.UserName, null!, "")).FirstOrDefault()!;
           var posts=await _postRepository.GetAsync(p=>p.UserId==user.Id,null,"");

        



            return posts
            .Adapt<List<PostReadModel>>();




        }


    }

}
