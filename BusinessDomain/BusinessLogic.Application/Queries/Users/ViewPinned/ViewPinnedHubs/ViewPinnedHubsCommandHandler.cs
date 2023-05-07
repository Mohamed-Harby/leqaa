using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.UpdateChannel;
using BusinessLogic.Application.Commands.Pin.PinPosts;
using BusinessLogic.Application.Commands.Pin.ViewPinned.ViewpinnedHubs;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using BusinessLogic.Domain.Common.Errors;
using ErrorOr;

using Mapster;
using MediatR;
using System.Runtime.CompilerServices;

namespace BusinessLogic.Application.Commands.Pin.ViewPinned.ViewpinnedHubs;
public class ViewPinnedHubsCommandHandler : IHandler<ViewPinnedHubsCommand, ErrorOr<List<HubReadModel>>>
{
    private readonly IPostRepository _PostRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IChannelRepository _channelRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public ViewPinnedHubsCommandHandler(
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
    public async Task<ErrorOr<List<HubReadModel>>> Handle(ViewPinnedHubsCommand request, CancellationToken cancellationToken)
    {
        User? user = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault()!;
        if (user == null)
        {
            return DomainErrors.User.NotFound;
        }
        var PinnedHubs=user.PinnedHubs.ToList();
      
      return PinnedHubs.Adapt<List<HubReadModel>>();

    }


}


