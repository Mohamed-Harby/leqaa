using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using BusinessLogic.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Persistence.UnitsOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)

    {

        _context = context;

    }




    public async Task<int> Save()
    {
        //returns how many rows were affected
        return await _context.SaveChangesAsync();
    }

    public async void Dispose()
    {
        await _context.DisposeAsync();
    }


















}