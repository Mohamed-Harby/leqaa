using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain.Plan;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Persistence.Repositories;
public class PlanRepository : BaseRepo<Plan>, IPlanRepository
{
    public PlanRepository(ApplicationDbContext db) : base(db)
    {
    }
}
