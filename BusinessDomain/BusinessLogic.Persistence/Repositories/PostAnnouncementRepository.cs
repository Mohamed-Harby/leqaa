using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;

public class PostAnnouncementRepository : BaseRepo<PostAnnoucement>, IPostAnnouncementRepository
{


    private readonly ApplicationDbContext _context;
    public PostAnnouncementRepository(ApplicationDbContext context) : base(context)
    {

        _context = context;
    }


    
}
