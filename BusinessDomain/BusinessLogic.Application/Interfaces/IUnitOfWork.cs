using BusinessLogic.Application.Interfaces;

namespace BusinessLogic.Application.Interfaces
{
    public interface IUnitOfWork
    {

        Task<int> Save();
    }
}