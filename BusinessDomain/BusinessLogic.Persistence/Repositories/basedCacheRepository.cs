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
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CommonGenericClasses
{
    public class BaseCachedRepo<TEntity> : IBaseRepo<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext _db;
        private readonly DbSet<TEntity> _table;
        private readonly Dictionary<object, TEntity> _cache;
        private readonly IDistributedCache _distributedCache;

        public BaseCachedRepo(DbContext db, IDistributedCache distributedCache)
        {
            this._db = db;
            this._table = db.Set<TEntity>();
            _cache = new Dictionary<object, TEntity>();
            _distributedCache = distributedCache;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
            await SaveAsync();
            return entity;
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            var cacheKey = $"cache_{typeof(TEntity).Name}_{id}";
            var cacheData = await _distributedCache.GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cacheData))
            {
                return JsonConvert.DeserializeObject<TEntity>(cacheData);
            }

            if (_cache.TryGetValue(id, out TEntity cachedEntity))
            {
                return cachedEntity;
            }

            var entity = await _table.FindAsync(id);
            if (entity != null)
            {
                _cache.Add(entity.Id, entity);

                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                await _distributedCache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(entity, settings), new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30) });
            }

            return entity;
        }

        public async Task<IEnumerable<TEntity>> RemoveRangeAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> entities = (await GetAsync(predicate)).ToList();
            _table.RemoveRange(entities);
            await SaveAsync();
            return entities;
        }

        public async Task<TEntity> RemoveAsync(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity entityToRemove = (await GetAsync(predicate)).FirstOrDefault();
            if (entityToRemove != null)
            {
                _table.Remove(entityToRemove);
                await SaveAsync();
            }
            return entityToRemove;
        }

        public async Task<TEntity> RemoveByIdAsync(object id)
        {
            TEntity entityToRemove = await GetByIdAsync(id);
            if (entityToRemove != null)
            {
                _table.Remove(entityToRemove);
                await SaveAsync();
            }
            return entityToRemove;
        }
        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            _table.Update(entity);
            return Task.FromResult(entity);
        }

        public async Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string include = "")
        {
            var cacheKey = $"cache_{typeof(TEntity).Name}_{predicate}_{orderBy}_{include}";
            var cacheData = await _distributedCache.GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cacheData))
            {
                var entities = JsonConvert.DeserializeObject<List<TEntity>>(cacheData);
                return entities.AsQueryable();
            }

            IQueryable<TEntity> query = _table;
            if (predicate != null)
                query = _table.Where<TEntity>(predicate);

            if (orderBy != null)
                query = orderBy(query);

            string[] includes = include.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (string property in includes)
            {
                query = query.Include(property);
            }
            var entitiesList = await query.ToListAsync();

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            await _distributedCache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(entitiesList, settings), new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30) });

            return entitiesList.AsQueryable();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = _table;
            if (predicate != null)
                query = _table.Where<TEntity>(predicate);

            return await query.CountAsync();
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _db.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (DbUpdateException ex)
            {
                //Logging.Error(ex, $"DbUpdateException on saving changes. Reason: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                //Logging.Error(ex, $"Exception on saving changes. Reason: {ex.Message}");
                return false;
            }
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(_table);
        }


        public Task<IQueryable<TEntity>> GetByUserName(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public TEntity Remove(TEntity entity)
        {
            _table.Remove(entity);
            return entity;
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            return await _db.SaveChangesAsync(cancellationToken);
        }
    }
}

