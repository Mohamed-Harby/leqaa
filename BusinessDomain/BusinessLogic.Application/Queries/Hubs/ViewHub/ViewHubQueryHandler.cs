using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Domain.Common.Errors;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Queries.Hubs.ViewHub;
public class ViewHubQueryHandler : IHandler<ViewHubQuery, ErrorOr<HubReadModel>>
{
    private readonly IHubRepository _hubRepository;

    public ViewHubQueryHandler(IHubRepository hubRepository)
    {
        _hubRepository = hubRepository;
    }

    public async Task<ErrorOr<HubReadModel>> Handle(ViewHubQuery request, CancellationToken cancellationToken)
    {
        var hub = (await _hubRepository.GetAsync(h => h.Id == request.Id, null!, "")).FirstOrDefault()!;
        if (hub is null)
        {
            return DomainErrors.Hub.NotFound;
        }
        return hub.Adapt<HubReadModel>();
    }
}
