using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.Extensions.Caching.Distributed;

namespace BusinessLogic.Persistence.Repositories
{
    public class CachedHubRepository : BaseCachedRepo<Hub>, IHubRepository
    {
        private readonly ApplicationDbContext _context;

        public CachedHubRepository(ApplicationDbContext context, IDistributedCache distributedCache) : base(context, distributedCache)
        {
            _context = context;
        }
    }
}
