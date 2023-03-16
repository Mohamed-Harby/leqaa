using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.UpdateChannel;
using BusinessLogic.Application.Commands.Pin.PinPosts;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;

using Mapster;
using MediatR;
using System.Runtime.CompilerServices;

namespace BusinessLogic.Application.Commands.Pin.PinHubs;
public class PinPostCommandHandler : IHandler<PinPostCommand, ErrorOr<PostReadModel>>
{
    private readonly IPostRepository _PostRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IChannelRepository _channelRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public PinPostCommandHandler(
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
    public async Task<ErrorOr<PostReadModel>> Handle(PinPostCommand request, CancellationToken cancellationToken)
    {
        User? creatorUser = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault()!;
        Post?post = await _PostRepository.GetByIdAsync(request.PostId);

        var PinningUser = await _userRepository.GetAsync(u => u.UserName == request.UserName, null, "PinnedPosts")!;
        User? getuser = PinningUser.FirstOrDefault()!;
        var PinnedPosts = getuser.PinnedPosts;

        foreach (var PinnedPost in PinnedPosts)
        {
            if (PinnedPost.Id == request.PostId)
            {
                return DomainErrors.Post.AllreadyExistsToPin;
            }

        }


        creatorUser.PinnedPosts.Add(post);
            await _unitOfWork.PinPostAsync(post, creatorUser);

            if (await _unitOfWork.SaveAsync() == 0)
            {


                return DomainErrors.Post.InvalidPost;
            }
            return post.Adapt<PostReadModel>();


        }

     
    }


