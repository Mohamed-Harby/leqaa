using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.CreateChannel;
using BusinessLogic.Application.Extensions;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using BusinessLogic.Domain.SharedEnums;
using ErrorOr;
using FluentValidation;
using Mapster;


namespace BusinessLogic.Application.Commands.Channels.AddChannel;
public class DeployHubAnnoucementCommandHandler : IHandler<CreateChannelCommand, ErrorOr<ChannelReadModel>>
{
    private readonly IChannelRepository _channelRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeployHubAnnoucementCommandHandler(
        IChannelRepository channelRepository,
        IHubRepository hubRepository,
        IUserRepository userRepository,
        IUserChannelRepository userChannelRepository,
        IUnitOfWork unitOfWork)
    {
        _channelRepository = channelRepository;
        _hubRepository = hubRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<ChannelReadModel>> Handle(CreateChannelCommand request, CancellationToken cancellationToken)
    {
        User? creatorUser = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault()!;
        Guid hubId = request.HubId ?? Constants.DefaultId;

        request = request with { HubId = hubId };

        Hub hub = await _hubRepository.GetByIdAsync(hubId);
        if (hub is null)
        {
            return DomainErrors.Hub.NotFound;
        }
        var channel = request.Adapt<Channel>();

        await _unitOfWork.CreateChannelAsync(channel, creatorUser);

        if (await _userRepository.SaveAsync(cancellationToken) == 0)
        {
            return DomainErrors.Channel.InvalidChannel;
        }
        return channel.Adapt<ChannelReadModel>();
    }
}
