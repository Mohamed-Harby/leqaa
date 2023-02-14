using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Posts;
using MediatR;

namespace BusinessLogic.Application.Queries.Hubs.GetAllHubs;
public record GetAllPostsQuery() : IQuery<List<PostReadModel>>;