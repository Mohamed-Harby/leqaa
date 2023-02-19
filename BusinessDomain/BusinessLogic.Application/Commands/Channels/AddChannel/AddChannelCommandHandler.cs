using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Commands.Channels.AddChannel;
public class AddRoomCommandHandler : IHandler<AddChannelCommand, ErrorOr<Channel>>
{
    private readonly IChannelRepository _channelRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddRoomCommandHandler(
        IChannelRepository channelRepository,
        IHubRepository hubRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _channelRepository = channelRepository;
        _hubRepository = hubRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Channel>> Handle(AddChannelCommand request, CancellationToken cancellationToken)
    {
        User creatorUser = (await _userRepository.GetAsync(u => u.UserName == request.Username)).FirstOrDefault()!;
        if (creatorUser is null)
        {
            return DomainErrors.User.NotFound;
        }
        Hub hub = await _hubRepository.GetByIdAsync(request.hubId);
        if (hub is null)
        {
            return DomainErrors.Hub.NotFound;
        }
        var channel = request.Adapt<Channel>();
        await _channelRepository.AddChannelWithUser(channel, creatorUser);
        if (await _unitOfWork.Save() == 0)
        {
            return DomainErrors.Channel.InvalidChannel;
        }
        return channel;
    }
}
