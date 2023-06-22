using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.UpdateChannel;
using BusinessLogic.Application.Commands.Pin.PinPosts;
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

namespace BusinessLogic.Application.Queries.Pin.ViewPinned.ViewpinnedChannels;
public class ViewPinnedChannelsCommandHandler : IHandler<ViewPinnedChannelsCommand, ErrorOr<List<ChannelReadModel>>>
{
    private readonly IPostRepository _PostRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IChannelRepository _channelRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public ViewPinnedChannelsCommandHandler(
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
    public async Task<ErrorOr<List<ChannelReadModel>>> Handle(ViewPinnedChannelsCommand request, CancellationToken cancellationToken)
    {
        User? user = (await _userRepository.GetAsync(u => u.UserName == request.UserName,null, "PinnedChannels")).FirstOrDefault()!;
        if (user == null)
        {
            return DomainErrors.User.NotFound;
        }
        var PinnedChannels=user.PinnedChannels.ToList();
      
      return  PinnedChannels.Adapt<List<ChannelReadModel>>();

    }


}


