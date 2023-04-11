﻿using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;
using System.Reflection.Metadata;

namespace BusinessLogic.Application.Commands.Pin.ViewPinned.ViewpinnedPosts;

public record ViewPinnedPostsCommand(
   string UserName

) : IUserNameInCommand<ErrorOr<List<PostReadModel>>>;
