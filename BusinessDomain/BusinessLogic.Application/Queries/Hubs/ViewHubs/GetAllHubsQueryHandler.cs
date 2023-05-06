using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Queries.Hubs.GetAllHubs;
public class GetAllHubsQueryHandler : IHandler<GetAllHubsQuery, ErrorOr<List<HubReadModel>>>
{
    private readonly IHubRepository _hubRepository;
    private readonly ICacheService _cacheService;


    public GetAllHubsQueryHandler(IHubRepository hubRepository,
        ICacheService cacheService
        )
    {
        _hubRepository = hubRepository;
        _cacheService = cacheService;

    }

    public async Task<ErrorOr<List<HubReadModel>>> Handle (GetAllHubsQuery request, CancellationToken cancellationToken)
    {


        var CachedData = await _cacheService.GetAsync<IEnumerable<Hub>>("hubs");

        if(CachedData!= null && CachedData.Count()>0) { 
        return CachedData.Adapt<List<HubReadModel>>();
        }

        var hubs = await _hubRepository.GetAllAsync();

        var expiryTime = DateTime.Now.AddSeconds(30);
        _cacheService.SetData<IEnumerable<Hub>>("hubs", hubs, expiryTime);



        return hubs.Take(request.PageSize)
        .Skip((request.PageNumber - 1) * request.PageSize).ToList()

            .Adapt<List<HubReadModel>>();
       
    }



}
