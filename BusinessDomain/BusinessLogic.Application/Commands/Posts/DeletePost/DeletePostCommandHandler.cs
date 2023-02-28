using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.CreateChannel;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;
using MediatR;

namespace BusinessLogic.Application.Commands.Posts.DeletePost;



public class DeletePostCommandHandler : IHandler<DeletePostCommand, ErrorOr<Unit>>

{
    private readonly IChannelRepository _channelRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPostRepository _postRepository;
    private readonly IUnitOfWork _unitOfWork;


    public DeletePostCommandHandler(
        IPostRepository postRepository,
        IHubRepository hubRepository,
        IUnitOfWork unitOfWork)
    {
        _hubRepository = hubRepository;
        _postRepository= postRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
       var post = await _postRepository.GetByIdAsync(request.PostId);
        if (post is null)
        {
            return DomainErrors.Channel.NotFound;
        }


        _postRepository.Remove(post);
       

        // await _channelRepository.DeleteChannelWithUser(channel, creatorUser);
        if (await _unitOfWork.Save() == 0)
        {
            return DomainErrors.Channel.InvalidChannel;
        }
        return Unit.Value;
    }

   
}
