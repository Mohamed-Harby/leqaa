using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Application.Queries.Hubs.GetAllHubs;
using BusinessLogic.Domain;
using Mapster;

namespace BusinessLogic.Application.Queries.Posts.GetAllPosts;
public class GetAllPostsQueryHandler : IHandler<GetAllPostsQuery, List<PostReadModel>>
{
    private readonly IPostRepository _PostsRepository;
    public readonly ICacheService _cacheService;

    public GetAllPostsQueryHandler(IPostRepository PostsRepository, ICacheService cacheService)
    {
        _PostsRepository = PostsRepository;
        _cacheService = cacheService;
    }

    public async Task<List<PostReadModel>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        var CachedData = await _cacheService.GetAsync<IEnumerable<Post>>("posts");

        if (CachedData != null && CachedData.Count() > 0)
        {
            return CachedData.Adapt<List<PostReadModel>>();
        }

        var posts = await _PostsRepository.GetAllAsync();

        var expiryTime = DateTime.Now.AddSeconds(30);
        _cacheService.SetData<IEnumerable<Post>>("posts", posts, expiryTime);

        var skip = (request.PageNumber - 1) * request.PageSize;
        return (await _PostsRepository.GetAllAsync())
            .Skip(skip)
            .Take(request.PageSize)
             .ToList()
            .Adapt<List<PostReadModel>>();
    }


}
