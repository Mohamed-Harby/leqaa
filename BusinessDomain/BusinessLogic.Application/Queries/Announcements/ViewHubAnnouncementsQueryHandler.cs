using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Annoucements.HubAnnoucements;
using Mapster;

namespace BusinessLogic.Application.Queries.Announcements;
public class ViewHubAnnouncementsQueryHandler : IHandler<ViewHubAnnouncementsQuery, List<HubAnnouncementReadModel>>
{
    private readonly IHubAnnouncementRepository _hubAnnouncementRepository;

    public ViewHubAnnouncementsQueryHandler(IHubAnnouncementRepository hubAnnouncementRepository)
    {
        _hubAnnouncementRepository = hubAnnouncementRepository;
    }

    public async Task<List<HubAnnouncementReadModel>> Handle(ViewHubAnnouncementsQuery request, CancellationToken cancellationToken)
    {
        var result = (await _hubAnnouncementRepository.GetAllAsync())
        .Skip((request.PageNumber - 1) * request.PageSize)
        .Take(request.PageNumber);
        return result.Adapt<List<HubAnnouncementReadModel>>();
    }
}
