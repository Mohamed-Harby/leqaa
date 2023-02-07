using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusinessLogic.Domain;
using ErrorOr;

namespace CommonGenericClasses
{
#nullable disable
    public interface IBaseRepo<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        void Dispose();
        Task<TEntity> Edit(TEntity entity);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string include = "");
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(object id);
        TEntity Remove(TEntity entity);
        Task<TEntity> RemoveAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> RemoveByIdAsync(object id);
        Task<IEnumerable<TEntity>> RemoveRangeAsync(Expression<Func<TEntity, bool>> predicate);
        Task Save();
    }
}