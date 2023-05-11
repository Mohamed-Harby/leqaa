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
using BusinessLogic.Application.Commands.Pin.DeletePin.DeletePinnedHub;
using BusinessLogic.Application.Models.Hubs;
using MediatR;
using BusinessLogic.Application.Commands.Pin.DeletePin.DeletePinnedPost;
using BusinessLogic.Application.Models.Posts;

namespace BusinessLogic.Application.Commands.Pin.DeletePin.DeletePinnedHub
{
    public class DeletePinnedPostCommandHandler : IHandler<DeletePinnedPostCommand, ErrorOr<PostRecentReadModel>>
    {

        private readonly IUserPinnedHubRepository _userPinnedHubRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHubRepository _hubRepository;
        private readonly IUserChannelRepository _userChannelRepository;
        private readonly IChannelRepository _channelRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePinnedPostCommandHandler(

            IUserPinnedHubRepository userPinnedHubRepository,
            IHubRepository hubRepository,
            IUserChannelRepository userChannelRepository,
            IUserRepository userRepository,
            IChannelRepository channelRepository,
            IPostRepository postRepository,
            IUnitOfWork unitOfWork
                )
        {


            _userPinnedHubRepository = userPinnedHubRepository;


            _userRepository = userRepository;
            _hubRepository = hubRepository;
            _userChannelRepository = userChannelRepository;

            _channelRepository = channelRepository;
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;


        }

        public async Task<ErrorOr<PostRecentReadModel>> Handle(DeletePinnedPostCommand request, CancellationToken cancellationToken)
        {
            var user = (await _userRepository.GetAsync(u => u.UserName == request.userName)).FirstOrDefault()!;
            var post = await _postRepository.GetByIdAsync(request.PostId);

            if (post is null)
            {
                return DomainErrors.Post.NotFound;
            }
            var userPinnedHub = (await _userPinnedHubRepository.GetAsync(uh => uh.UserPinnedid == user.Id && uh.PinnedHubId == post.Id
            )).FirstOrDefault()!;
            if (userPinnedHub is null)
            {
                return DomainErrors.UserPost.NotJoined;
            }

            post.PostPinningUsers.Remove(user);
            if (await _unitOfWork.SaveAsync(cancellationToken) == 0)
            {
                return DomainErrors.Post.InvalidPost;
            }
            return DomainSucceded.User.ChannelUnPinned;
        }


    }
}


