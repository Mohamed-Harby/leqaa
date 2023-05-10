using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.UpdateChannel;
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

namespace BusinessLogic.Application.Commands.Pin.PinHubs;
public class PinHubCommandHandler : IHandler<PinHubCommand, ErrorOr<HubReadModel>>
{

    private readonly IPostRepository _PostRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IChannelRepository _channelRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public PinHubCommandHandler(
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
    public async Task<ErrorOr<HubReadModel>> Handle(PinHubCommand request, CancellationToken cancellationToken)
    {
        User? creatorUser = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault()!;
        Hub? hub = await _hubRepository.GetByIdAsync(request.HubId);

        var PinningUser = await _userRepository.GetAsync(u => u.UserName == request.UserName, null, "PinnedHubs")!;
        User? getuser= PinningUser.FirstOrDefault()!;
        var PinnedHubs = getuser.PinnedHubs;

        foreach(var userHup in PinnedHubs)
        {
            if(userHup.Id==request.HubId)
            {
                return DomainErrors.Hub.AlreadyExest;
            }

        }
        creatorUser.PinnedHubs.Add(hub);

        await _unitOfWork.PinHubAsync(hub, creatorUser);
        if (await _unitOfWork.SaveAsync() == 0)
        {
        return DomainErrors.Hub.InvalidHub;

        }

        return hub.Adapt<HubReadModel>();


    }


}