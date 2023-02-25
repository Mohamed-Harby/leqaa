using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BusinessLogic.Domain;
using ErrorOr;

namespace CommonGenericClasses
{

#nullable disable
    public abstract class BaseUnitOfWork<TEntity> : IBaseUnitOfWork<TEntity> where TEntity : BaseEntity
    {
        protected readonly IBaseRepo<TEntity> _repo;

        public BaseUnitOfWork(IBaseRepo<TEntity> repo)
        {
            _repo = repo;
        }
        public virtual async Task<IQueryable<TEntity>> ReadAllAsync()
        {
            return await _repo.GetAllAsync();
        }
        public virtual async Task<ErrorOr<TEntity>> CreateAsync(TEntity entity)
        {
            return await _repo.AddAsync(entity);
        }
        public virtual async Task<TEntity> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repo.RemoveAsync(predicate);
        }
        public virtual async Task<IEnumerable<TEntity>> DeleteRangeAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repo.RemoveRangeAsync(predicate);
        }
        public virtual async Task<TEntity> ReadByIdAsync(object id)
        {
            return await _repo.GetByIdAsync(id);
        }
        public virtual async Task<TEntity> DeleteByIdAsync(object id)
        {
            return await _repo.RemoveByIdAsync(id);
        }
        public virtual async Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate = null,
                                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                            string include = "")
        {
            return await _repo.GetAsync(predicate, orderBy, include);
        }
        public async virtual Task<TEntity> Update(TEntity entity)
        {
            return await _repo.UpdateAsync(entity);
        }

        public virtual async Task<string> SaveAsync(CancellationToken cancellationToken = default)
        {

            await _repo.SaveAsync(cancellationToken);
            return "Done";

        }


    }
}