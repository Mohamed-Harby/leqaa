using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Posts;
using Mapster;

namespace BusinessLogic.Application.Queries.Hubs.GetAllHubs;
public class GetAllHubsQueryHandler : IHandler<GetAllHubsQuery, List<HubReadModel>>
{
    private readonly IHubRepository _hubRepository;


    public GetAllHubsQueryHandler(IHubRepository hubRepository)
    {
        _hubRepository = hubRepository;
    }

    public async Task<List<HubReadModel>> Handle(GetAllHubsQuery request, CancellationToken cancellationToken)
    {

        var hubs = await _hubRepository.GetAllAsync();

  
        return hubs
           .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Adapt<List<HubReadModel>>();
    }



}
