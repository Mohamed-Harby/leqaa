using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;
public class PlanRepository : BaseRepo<Plan>, IPlanRepository
{
    public PlanRepository(ApplicationDbContext db) : base(db)
    {
    }
}
