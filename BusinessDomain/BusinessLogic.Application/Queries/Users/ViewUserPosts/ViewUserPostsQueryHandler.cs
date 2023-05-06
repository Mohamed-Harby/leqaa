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
        private readonly IUserHubRepository _userChannelRepository;
        private readonly IPostRepository _postRepository;
        private readonly ICacheService _cacheService;
      

        public ViewUserPostsQueryHandler(
            IChannelRepository channelRepository,
            IHubRepository hubRepository,
            IUserRepository userRepository,
            IPostRepository postRepository,
            IUserHubRepository userChannelRepository,

            ICacheService cacheService)
        {
            _channelRepository = channelRepository;
            _hubRepository = hubRepository;
            _userRepository = userRepository;
            _userChannelRepository = userChannelRepository;
            _postRepository = postRepository;
            _cacheService = cacheService;
        }
        public async Task<ErrorOr<List<PostReadModel>>> Handle(ViewUserPostsQuery request, CancellationToken cancellationToken)
        {



            var CachedData = await _cacheService.GetAsync<IEnumerable<Post>>("userposts");

            if (CachedData != null && CachedData.Count() > 0)
            {
                return CachedData.Adapt<List<PostReadModel>>();
            }

            var user = (await _userRepository.GetAsync(u => u.UserName == request.UserName, null!, "")).FirstOrDefault()!;
           var posts=await _postRepository.GetAsync(p=>p.UserId==user.Id,null,"");

        

         var expiryTime = DateTime.Now.AddSeconds(30);
            _cacheService.SetData<IEnumerable<Post>>("userposts", posts, expiryTime);




            return posts
            .Adapt<List<PostReadModel>>();




        }


    }

}
