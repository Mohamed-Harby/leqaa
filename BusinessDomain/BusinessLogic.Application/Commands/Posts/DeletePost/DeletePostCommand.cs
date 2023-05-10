using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Application.Commands.Posts.DeletePost;
public record DeletePostCommand(
 Guid PostId
) : ICommand<ErrorOr<Unit>>;