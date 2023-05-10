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



    public GetAllHubsQueryHandler(IHubRepository hubRepository
        )
    {
        _hubRepository = hubRepository;
     

    }

    public async Task<ErrorOr<List<HubReadModel>>> Handle (GetAllHubsQuery request, CancellationToken cancellationToken)
    {



        var hubs = await _hubRepository.GetAllAsync();





        return hubs.Take(request.PageSize)
        .Skip((request.PageNumber - 1) * request.PageSize).ToList()

            .Adapt<List<HubReadModel>>();
       
    }



}
