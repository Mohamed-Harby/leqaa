using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;

public class ChannelAnnouncementRepository : BaseRepo<ChannelAnnouncement>, IChannelAnnouncementRepository
{


    private readonly ApplicationDbContext _context;
    public ChannelAnnouncementRepository(ApplicationDbContext context) : base(context)
    {

        _context = context;
    }

    
}
