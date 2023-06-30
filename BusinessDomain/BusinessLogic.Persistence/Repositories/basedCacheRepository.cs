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
using BusinessLogic.Domain.Common;
using System.Text;
using System.Security.Cryptography;

namespace CommonGenericClasses
{
    public class BaseCachedRepo<TEntity> : BaseRepo<TEntity>, IBaseRepo<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext _db;
        protected readonly DbSet<TEntity> _table;
        private readonly Dictionary<object, TEntity> _cache;
        private readonly IDistributedCache _distributedCache;
        public BaseCachedRepo(DbContext db, IDistributedCache distributedCache) : base(db)
        {
            _distributedCache = distributedCache;
            this._db = db;
            this._table = db.Set<TEntity>();
            _cache = new Dictionary<object, TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            var cacheKey = $"cache_{typeof(TEntity).Name}_{id}";
            var cacheData = await _distributedCache.GetStringAsync(cacheKey)!;

            if (!string.IsNullOrEmpty(cacheData))
            {
                return JsonConvert.DeserializeObject<TEntity>(cacheData)!;
            }

            if (_cache.TryGetValue(id, out TEntity? cachedEntity ))
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

                await _distributedCache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(entity, settings), new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(200) });
            }

            return entity!;
        }
        /*    cache_User_-1237237105*/

        public async Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string include = "")
        {
            var cacheKey = GetCacheKey(predicate, orderBy, include);
            var cacheData = await _distributedCache.GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cacheData))
            {
                var entities = JsonConvert.DeserializeObject<List<TEntity>>(cacheData);
                return entities.AsQueryable();
            }

            IQueryable<TEntity> query = _table;
            if (predicate != null)
                query = _table.Where(predicate);

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

            await _distributedCache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(entitiesList, settings), new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(200) });

            return entitiesList.AsQueryable();
        }

        private string GetCacheKey(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string include)
        {
            var cacheKey = new StringBuilder();
            cacheKey.Append($"cache_{typeof(TEntity).Name}_");

            if (predicate != null)
            {
                var predicateHashCode = ComputeHashCode(predicate);
                cacheKey.Append(predicateHashCode);
            }

            if (orderBy != null)
            {
                var orderByHashCode = ComputeHashCode(orderBy);
                cacheKey.Append(orderByHashCode);
            }

            if (!string.IsNullOrEmpty(include))
            {
                var includeHashCode = ComputeHashCode(include);
                cacheKey.Append(includeHashCode);
            }

            return cacheKey.ToString();
        }

        private int ComputeHashCode(object obj)
        {
            using (var sha256 = SHA256.Create())
            {
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                var objJson = JsonConvert.SerializeObject(obj, settings);
                var objBytes = Encoding.UTF8.GetBytes(objJson);
                var hashBytes = sha256.ComputeHash(objBytes);
                var hashCode = BitConverter.ToInt32(hashBytes, 0);
                return hashCode;
            }
        }


        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            var cacheKey = $"cache_{typeof(TEntity).Name}_all";
            var cacheData = await _distributedCache.GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cacheData))
            {
                var entities = JsonConvert.DeserializeObject<List<TEntity>>(cacheData);
                return entities!.AsQueryable();
            }

            IQueryable<TEntity> query = _table;

            var entitiesList = await query.ToListAsync();

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            await _distributedCache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(entitiesList, settings), new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(200) });

            return entitiesList.AsQueryable();
        }


    }
}

