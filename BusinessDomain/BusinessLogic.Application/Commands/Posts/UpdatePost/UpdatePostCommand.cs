using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Application.Commands.Posts.UpdatePost;
public record UpdatePostCommand(
    Guid GuidpostId,
     string Title,
    byte[]? Image,
   string Content,
    string Username
) : ICommand<ErrorOr<PostReadModel>>;