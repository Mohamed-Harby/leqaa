using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.CreateChannel;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Commands.Channels.AddChannel;
public class CreateChannelCommandHandler : IHandler<CreateChannelCommand, ErrorOr<Channel>>
{
    private readonly IChannelRepository _channelRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;

    public CreateChannelCommandHandler(
        IChannelRepository channelRepository,
        IHubRepository hubRepository,
        IUserRepository userRepository
        )
    {
        _channelRepository = channelRepository;
        _hubRepository = hubRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Channel>> Handle(CreateChannelCommand request, CancellationToken cancellationToken)
    {
        User creatorUser = (await _userRepository.GetAsync(u => u.UserName == request.Username)).FirstOrDefault()!;
        if (creatorUser is null)
        {
            return DomainErrors.User.NotFound;
        }
        string hubId = request.hubId ?? Constants.DefaultId.ToString();
        Hub hub = await _hubRepository.GetByIdAsync(request.hubId);
        if (hub is null)
        {
            return DomainErrors.Hub.NotFound;
        }
        var channel = request.Adapt<Channel>();
        await _channelRepository.AddChannelWithUser(channel, creatorUser);
        if (await _channelRepository.SaveAsync(cancellationToken) == 0)
        {
            return DomainErrors.Channel.InvalidChannel;
        }
        return channel;
    }
}
