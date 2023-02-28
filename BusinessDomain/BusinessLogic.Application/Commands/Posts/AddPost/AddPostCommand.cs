using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;
using System.Reflection.Metadata;

namespace BusinessLogic.Application.Commands.Posts.AddaPost;

public record AddPostCommand(
    string Title,
    byte[]? Image,
   string Content,
    string Username
) : ICommand<ErrorOr<PostReadModel>>;