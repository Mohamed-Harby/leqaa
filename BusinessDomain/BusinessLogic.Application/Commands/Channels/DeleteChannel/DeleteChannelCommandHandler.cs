using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.CreateChannel;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain;
using BusinessLogic.Domain.Common.Errors;
using ErrorOr;
using Mapster;
using MediatR;
using BusinessLogic.Domain.DomainSucceeded.User;


namespace BusinessLogic.Application.Commands.Channels.DeleteChannel;


public class DeletePostCommandHandler : IHandler<DeletePostCommand, ErrorOr<Unit>>

{
    private readonly IChannelRepository _channelRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;


    public DeletePostCommandHandler(

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

    public async Task<ErrorOr<Unit>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var channel = await _channelRepository.GetByIdAsync(request.ChannelId);
        if (channel is null)
        {
            return DomainErrors.Channel.NotFound;
        }


      _channelRepository.Remove(channel);


        if (await _unitOfWork.SaveAsync() == 0)
        {
            return DomainErrors.Channel.InvalidChannel;
        }
        return DomainSucceded.User.ChannelDeleted;
    }


}
