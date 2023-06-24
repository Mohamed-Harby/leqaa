using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;
using System.Reflection.Metadata;

namespace BusinessLogic.Application.Commands.Pin.PinPosts;

public record PinPostCommand(
   string UserName,
   Guid PostId
) : IUserNameInCommand<ErrorOr<PostReadModel>>;
