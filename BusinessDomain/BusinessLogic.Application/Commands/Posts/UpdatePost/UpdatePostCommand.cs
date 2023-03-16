using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Application.Commands.Posts.UpdatePost;
public record UpdatePostCommand(
    Guid postId,
     string Title,
    byte[]? Image,
   string Content
) : ICommand<ErrorOr<PostUpdateModel>>;