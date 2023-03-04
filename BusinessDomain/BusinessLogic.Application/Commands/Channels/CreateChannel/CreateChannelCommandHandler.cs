using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.CreateChannel;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using BusinessLogic.Domain.SharedEnums;
using ErrorOr;
using FluentValidation;
using Mapster;

namespace BusinessLogic.Application.Commands.Channels.AddChannel;
public class CreateChannelCommandHandler : IHandler<CreateChannelCommand, ErrorOr<ChannelReadModel>>
{
    private readonly IChannelRepository _channelRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUserChannelRepository _userChannelRepository;
    private readonly IValidator<CreateChannelCommand> _validator;

    public CreateChannelCommandHandler(
        IChannelRepository channelRepository,
        IHubRepository hubRepository,
        IUserRepository userRepository,
        IUserChannelRepository userChannelRepository,
        IValidator<CreateChannelCommand> validator)
    {
        _channelRepository = channelRepository;
        _hubRepository = hubRepository;
        _userRepository = userRepository;
        _userChannelRepository = userChannelRepository;
        _validator = validator;
    }

    public async Task<ErrorOr<ChannelReadModel>> Handle(CreateChannelCommand request, CancellationToken cancellationToken)
    {
        var result = _validator.Validate(request);
        if (!result.IsValid)
        {
            return result.Errors.ConvertAll(
                validationFailures =>
                Error.Validation(
                    validationFailures.PropertyName,
                    validationFailures.ErrorMessage));
        }

        User? creatorUser = (await _userRepository.GetAsync(u => u.UserName == request.Username)).FirstOrDefault();
        if (creatorUser is null)
        {
            return DomainErrors.User.NotFound;
        }
        Guid hubId = request.HubId ?? Constants.DefaultId;

        request = request with { HubId = hubId };

        Hub hub = await _hubRepository.GetByIdAsync(hubId);
        if (hub is null)
        {
            return DomainErrors.Hub.NotFound;
        }
        var channel = request.Adapt<Channel>();
        var userChannel = new UserChannel
        {
            Channel = channel,
            User = creatorUser,
            Role = GroupRole.Founder
        };
        await _userChannelRepository.UpdateAsync(userChannel);
        creatorUser.Channels.Add(channel);
        if (await _userRepository.SaveAsync(cancellationToken) == 0)
        {
            return DomainErrors.Channel.InvalidChannel;
        }
        return channel.Adapt<ChannelReadModel>();
    }
}
