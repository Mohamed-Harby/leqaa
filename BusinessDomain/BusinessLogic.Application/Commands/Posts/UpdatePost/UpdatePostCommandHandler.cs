using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.UpdateChannel;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using FluentValidation;
using Mapster;
using MediatR;
namespace BusinessLogic.Application.Commands.Posts.UpdatePost;

public class UpdatePostCommandHandler : IHandler<UpdatePostCommand, ErrorOr<PostUpdateModel>>
{
    private readonly IValidator<UpdatePostCommand> _validator;

    private readonly IPostRepository _postRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;


    public UpdatePostCommandHandler(
        IPostRepository postRepository,
        IHubRepository hubRepository,
        IUserRepository userRepository,
              IValidator<UpdatePostCommand> validator)

    {
        _postRepository = postRepository;
        _hubRepository = hubRepository;
        _userRepository = userRepository;
        _validator = validator;

    }


    public async Task<ErrorOr<PostUpdateModel>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.postId);

        if (request.Title != null)
        {
            post.Title = request.Title;
        }
        if (request.Image != null)
        {
            post.Image = request.Image;
        }
        if (request.Content != null)
        {
            post.Content = request.Content;
        }
        await _postRepository.UpdateAsync(post);
        if (await _postRepository.SaveAsync(cancellationToken) == 0)
        {
            return DomainErrors.Channel.InvalidChannel;
        }

        return post.Adapt<PostUpdateModel>();

    }



}

