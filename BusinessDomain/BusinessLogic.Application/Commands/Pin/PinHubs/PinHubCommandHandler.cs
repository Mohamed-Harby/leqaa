using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.UpdateChannel;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Pinned.PinHubs;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;

using Mapster;
using MediatR;
using System.Runtime.CompilerServices;

namespace BusinessLogic.Application.Commands.Pin.PinHubs;
public class PinHubCommandHandler : IHandler<PinHubCommand, ErrorOr<PinHubWriteModel>>
{
  

    private readonly IPostRepository _PostRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;

    public PinHubCommandHandler(
        IPostRepository postRepository,
        IHubRepository hubRepository,
        IUserRepository userRepository
      )

    {
        _PostRepository = postRepository;
        _hubRepository = hubRepository;
        _userRepository = userRepository;
 

    }

    public async Task<ErrorOr<PinHubWriteModel>> Handle(PinHubCommand request, CancellationToken cancellationToken)
    {
        User? creatorUser = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault()!;
        Hub? hub = await _hubRepository.GetByIdAsync(request.HubId);

        PinnedHub pinnedHup = new();
        pinnedHup.UserPinned = creatorUser;
        pinnedHup.Hubs.Add(hub);

        return pinnedHup.Adapt<PinHubWriteModel>();



    }


}