using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.UpdateChannel;
using BusinessLogic.Application.Commands.Pin.PinChannels;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;

using Mapster;
using MediatR;
using System.Runtime.CompilerServices;

namespace BusinessLogic.Application.Commands.Pin.PinChannel;
public class PinChannelCommandHandler : IHandler<PinChannelCommand, ErrorOr<ChannelReadModel>>
{
  

    private readonly IPostRepository _PostRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IChannelRepository _channelRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public PinChannelCommandHandler(
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

    public async Task<ErrorOr<ChannelReadModel>> Handle(PinChannelCommand request, CancellationToken cancellationToken)
    {
        User? creatorUser = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault()!;
        Channel? channel= await _channelRepository.GetByIdAsync(request.ChannelId);


        var PinningUser = await _userRepository.GetAsync(u => u.UserName == request.UserName, null, "PinnedChannels")!;
        User? getuser = PinningUser.FirstOrDefault()!;
        var PinnedChannels = getuser.PinnedChannels;

        foreach (var PinnedChannel in PinnedChannels)
        {
            if (PinnedChannel.Id == request.ChannelId)
            {
                return DomainErrors.Channel.AlreadyExest;
            }

        }

           
        creatorUser.PinnedChannels.Add(channel);
        await _unitOfWork.PinChannelAsync(channel, creatorUser);
        if (await _unitOfWork.SaveAsync() == 0)
        {
            return DomainErrors.Channel.InvalidChannel;
        }

        return channel.Adapt<ChannelReadModel>();

    }


}