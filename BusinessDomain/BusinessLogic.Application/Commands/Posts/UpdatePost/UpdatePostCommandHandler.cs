using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;
using MediatR;
namespace BusinessLogic.Application.Commands.Posts.UpdatePost;

public class UpdatePostCommandHandler : IHandler<UpdatePostCommand, ErrorOr<PostReadModel>>
{
    private readonly IPostRepository _postRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePostCommandHandler(
        IPostRepository postRepository,
        IHubRepository hubRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _postRepository = postRepository;
        _hubRepository = hubRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<PostReadModel>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var postToUpdate = await _postRepository.GetByIdAsync(request.GuidpostId);

        if (postToUpdate is null)
        {
            return DomainErrors.Post.NotFound;
        }
        postToUpdate.Id = request.GuidpostId;
        postToUpdate.Title = request.Title;
        postToUpdate.Content= request.Content;
        postToUpdate.Image = request.Image;

        if (await _postRepository.SaveAsync(cancellationToken) == 0)
        {
            return DomainErrors.Post.InvalidPost;
        }

        return postToUpdate.Adapt<PostReadModel>();
  
        
  







    }
}
