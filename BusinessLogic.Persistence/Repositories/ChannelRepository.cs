using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories
{
    public class ChannelRepository : BaseRepo<Channel>, IChannelRepository
    {
        public ChannelRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}