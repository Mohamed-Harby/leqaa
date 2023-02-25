using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
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
    
        var hubs = (await _hubRepository.GetAllAsync())

                     .Where(c => c.Id.CompareTo(request.Cursor) > 0)
                     .OrderBy(c => c.Id)
                     .Take(request.Limit)
                     .ToList()
                     .Adapt<List<HubReadModel>>();

        return hubs;
    }



}
