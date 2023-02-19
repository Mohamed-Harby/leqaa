using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;
using MediatR;

namespace BusinessLogic.Application.Commands.Channels.DeleteChannel;


public class DeleteChannelCommandHandler : IHandler<DeleteChannelCommand, ErrorOr<Channel>>

{
    private readonly IChannelRepository _channelRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;


    public DeleteChannelCommandHandler(

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

    public async Task<ErrorOr<Channel>> Handle(DeleteChannelCommand request, CancellationToken cancellationToken)
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
        // await _channelRepository.DeleteChannelWithUser(channel, creatorUser);
        if (await _unitOfWork.Save() == 0)
        {
            return DomainErrors.Channel.InvalidChannel;
        }
        return channel;
    }
}
