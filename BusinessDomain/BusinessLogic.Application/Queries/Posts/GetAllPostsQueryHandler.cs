using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Application.Queries.Hubs.GetAllHubs;
using Mapster;

namespace BusinessLogic.Application.Queries.Posts.GetAllPosts;
public class GetAllPostsQueryHandler : IHandler<GetAllPostsQuery, List<PostReadModel>>
{
    private readonly IPostRepository _PostsRepository;

    public GetAllPostsQueryHandler(IPostRepository PostsRepository)
    {
        _PostsRepository = PostsRepository;
    }

    public async Task<List<PostReadModel>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {


        var skip = (request.PageNumber - 1) * request.PageSize;
        return (await _PostsRepository.GetAllAsync())
            .Skip(skip)
            .Take(request.PageSize)
             .ToList()
            .Adapt<List<PostReadModel>>();
    }


}
