using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Pin.ViewPinned.ViewpinnedChannels;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain.Common.Errors;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using BusinessLogic.Application.Commands.Pin.ViewPinned.ViewpinnedPosts;

namespace BusinessLogic.Application.Commands.Pin.ViewPinned.ViewPinnedPosts;

public class ViewPinnedPostsCommandHandler : IHandler<ViewPinnedPostsCommand, ErrorOr<List<PostReadModel>>>
{
    private readonly IPostRepository _PostRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IChannelRepository _channelRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public ViewPinnedPostsCommandHandler(
        IPostRepository postRepository,
        IHubRepository hubRepository,
        IChannelRepository channelRepository,
        IUnitOfWork unitOfWork,
        IUserRepository userRepository
      )

    {
        _PostRepository = postRepository;
        _hubRepository = hubRepository;
        _channelRepository = channelRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;


    }
    public async Task<ErrorOr<List<PostReadModel>>> Handle(ViewPinnedPostsCommand request, CancellationToken cancellationToken)
    {
        User? user = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault()!;
        if (user == null)
        {
            return DomainErrors.User.NotFound;
        }
        var PinnedPosts= user.PinnedPosts.ToList();

        return PinnedPosts.Adapt<List<PostReadModel>>();

    }


}



