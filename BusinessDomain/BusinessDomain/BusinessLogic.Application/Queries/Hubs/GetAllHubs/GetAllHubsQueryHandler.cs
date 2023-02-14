using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
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
        return (await _hubRepository.GetAllAsync())
            .ToList()
            .Adapt<List<HubReadModel>>();
    }

   
}
