using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;

public class HubAnnouncementRepository : BaseRepo<HubAnnouncement>,IHubAnnouncementRepository
{


    private readonly ApplicationDbContext _context;
    public HubAnnouncementRepository(ApplicationDbContext context) : base(context)
    {

        _context = context;
    }

    
}
