using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Annoucements.HubAnnoucements;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Queries.Announcements.ViewHubAnnouncements;
public class ViewHubAnnouncementsQueryHandler : IHandler<ViewHubAnnouncementsQuery, ErrorOr<List<HubAnnouncementReadModel>>>
{
    private readonly IHubAnnouncementRepository _hubAnnouncementRepository;

    public ViewHubAnnouncementsQueryHandler(IHubAnnouncementRepository hubAnnouncementRepository)
    {
        _hubAnnouncementRepository = hubAnnouncementRepository;
    }

    public async Task <ErrorOr<List<HubAnnouncementReadModel>>> Handle(ViewHubAnnouncementsQuery request, CancellationToken cancellationToken)
    {
        var result = await _hubAnnouncementRepository.GetAsync(ha => ha.HubId == request.HubId, null, "");
       result.Skip((request.PageNumber - 1) * request.PageSize)
        .Take(request.PageNumber);
        return result.Adapt<List<HubAnnouncementReadModel>>();
    }
}
