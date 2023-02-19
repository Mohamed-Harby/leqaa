using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;
using MediatR;

namespace BusinessLogic.Application.Commands.Channels.UpdateChannel;
public class UpdateChannelCommandHandler : IHandler<UpdateChannelCommand, ErrorOr<Channel>>
{
    private readonly IChannelRepository _channelRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateChannelCommandHandler(
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

    public async Task<ErrorOr<Channel>> Handle(UpdateChannelCommand request, CancellationToken cancellationToken)
    {
        User creatorUser = (await _userRepository.GetAsync(u => u.UserName == request.Username)).FirstOrDefault()!;
        if (creatorUser is null)
        {
            return DomainErrors.User.NotFound;
        }
        Hub hub = await _hubRepository.GetByIdAsync(request.HubId);
        if (hub is null)
        {
            return DomainErrors.Hub.NotFound;
        }
        var channel = request.Adapt<Channel>();
        await _channelRepository.UpdateChannelWithUser(channel, creatorUser);
        if (await _unitOfWork.Save() == 0)
        {
            return DomainErrors.Channel.InvalidChannel;
        }
        return channel;
    }
}
