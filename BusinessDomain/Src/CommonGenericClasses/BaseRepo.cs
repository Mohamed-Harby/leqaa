using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BusinessLogic.Domain;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
#nullable disable
namespace CommonGenericClasses
{


    public abstract class BaseRepo<TEntity> : IBaseRepo<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext db;
        protected readonly DbSet<TEntity> table;
        public BaseRepo(DbContext db)
        {
            this.db = db;
            this.table = db.Set<TEntity>();

        }
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await table.AddAsync(entity);

            return entity;
        }
        public virtual TEntity Remove(TEntity entity)
        {
            table.Remove(entity);
            return entity;
        }
        public virtual async Task<IEnumerable<TEntity>> RemoveRangeAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> entities = (await GetAsync(predicate));
            table.RemoveRange(entities);
            return entities;
        }
        public virtual async Task<TEntity> RemoveAsync(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity entityToRemove = (await GetAsync(predicate)).FirstOrDefault();
            table.Remove(entityToRemove);
            return entityToRemove;
        }
        public virtual Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
                                                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                                    string include = ""
                                                                    )
        {
            IQueryable<TEntity> query = table;
            if (predicate != null)
                query = table.Where<TEntity>(predicate);

            if (orderBy != null)
                query = orderBy(query);

            string[] includes = include.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (string property in includes)
            {
                query = query.Include(property).AsSplitQuery();
            }

            return Task.FromResult(query);
        }
        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await table.FindAsync(id);
        }

        public virtual Task<IQueryable<TEntity>> GetByUserName(Expression<Func<TEntity, bool>> predicate = null)
        {


            IQueryable<TEntity> query = table;
            if (predicate != null)
                query = table.Where<TEntity>(predicate);
            return Task.FromResult(query);

        }
        public virtual async Task<TEntity> RemoveByIdAsync(object id)
        {
            TEntity entityToRemove = await GetByIdAsync(id);
            table.Remove(entityToRemove);
            return entityToRemove;
        }
        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            table.Update(entity);
            return Task.FromResult(entity);
        }
        public virtual Task<IQueryable<TEntity>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<TEntity>>(table);
        }
        public virtual async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            return await db.SaveChangesAsync(cancellationToken);
        }
    }
}