using BusinessLogic.Persistence.Repositories;

namespace BusinessLogic.Application.Interfaces
{
    public interface IUnitOfWork
    {

        Task<int> Save();
    }
}