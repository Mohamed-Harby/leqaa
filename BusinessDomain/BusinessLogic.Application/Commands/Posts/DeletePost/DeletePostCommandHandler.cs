using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.CreateChannel;
using BusinessLogic.Application.Commands.Channels.UpdateChannel;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using FluentValidation;
using Mapster;
using MediatR;

namespace BusinessLogic.Application.Commands.Posts.DeletePost;



public class DeletePostCommandHandler : IHandler<DeletePostCommand, ErrorOr<Unit>>

{
    private readonly IValidator<DeletePostCommand> _validator;

    private readonly IHubRepository _hubRepository;
    private readonly IPostRepository _postRepository;


    public DeletePostCommandHandler(
        IPostRepository postRepository,
        IHubRepository hubRepository,
             IValidator<DeletePostCommand> validator)

    {
        _hubRepository = hubRepository;
        _postRepository = postRepository;
        _validator = validator;

    }

    public async Task<ErrorOr<Unit>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var result = await _validator.ValidateAsync(request);
        if (!result.IsValid)
        {
            return result.Errors.ConvertAll(
                validationFailure => Error.Validation(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage)
            );
        }
        var post = await _postRepository.GetByIdAsync(request.PostId);
        if (post is null)
        {
            return DomainErrors.Channel.NotFound;
        }


        _postRepository.Remove(post);


        // await _channelRepository.DeleteChannelWithUser(channel, creatorUser);
        if (await _postRepository.SaveAsync(cancellationToken) == 0)
        {
            return DomainErrors.Channel.InvalidChannel;
        }
        return Unit.Value;
    }


}
