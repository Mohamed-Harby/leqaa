using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CommonGenericClasses
{
#nullable disable
    public interface IBaseUnitOfWork<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> DeleteByIdAsync(object id);
        Task<IEnumerable<TEntity>> DeleteRangeAsync(Expression<Func<TEntity, bool>> predicate);
        void Dispose();
        Task<List<TEntity>> ReadAllAsync();
        Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string include = "");
        Task<TEntity> ReadByIdAsync(object id);
        Task<string> SaveAsync();
        Task<TEntity> Update(TEntity entity);
    }
}