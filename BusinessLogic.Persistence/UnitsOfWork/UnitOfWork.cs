using BusinessLogic.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Persistence.UnitsOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Save()
    {
        //returns how many rows were affected
        return await _context.SaveChangesAsync();
    }
}