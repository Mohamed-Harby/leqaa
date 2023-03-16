using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Commands.Users.JoinChannel;
public class JoinChannelCommandHandler : IHandler<JoinChannelCommand, ErrorOr<ChannelReadModel>>
{
    private readonly IUserRepository _userRepository;
    private readonly IChannelRepository _channelRepository;
    private readonly IUserChannelRepository _userChannelRepository;
    public JoinChannelCommandHandler(
        IUserRepository userRepository,
        IChannelRepository channelRepository,
        IUserChannelRepository userHubRepository)
    {
        _userRepository = userRepository;
        _channelRepository = channelRepository;
        _userChannelRepository = userHubRepository;
    }

    public async Task<ErrorOr<ChannelReadModel>> Handle(JoinChannelCommand request, CancellationToken cancellationToken)
    {
        var user = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault()!;
        var channel = await _channelRepository.GetByIdAsync(request.ChannelId);
        if (channel is null)
        {
            return DomainErrors.Channel.NotFound;
        }
        var userchannel = (await _userChannelRepository.GetAsync(uc => uc.UserId == user.Id && uc.ChannelId == channel.Id)).FirstOrDefault();
        if (userchannel is not null)
        {
            return DomainErrors.UserChannel.AlreadyJoinedChannel;
        }
        channel.AddUser(user);
        if (await _channelRepository.SaveAsync(cancellationToken) == 0)
        {
            return DomainErrors.Channel.CannotJoinChannel;
        }
        return channel.Adapt<ChannelReadModel>();

    }
}
