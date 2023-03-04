using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Application.Commands.Posts.AddPost;
public record AddPostCommand(
    string Name,
    string? Description,
    Guid HubId,
    Guid ChannelId,
    string Username
) : ICommand<ErrorOr<Post>>;