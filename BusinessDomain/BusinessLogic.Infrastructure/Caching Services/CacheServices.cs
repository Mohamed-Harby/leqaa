using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using BusinessLogic.Infrastructure.Caching_Services;
using StackExchange.Redis;
using BusinessLogic.Application.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BusinessLogic.Infrastructure.Caching_Services
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase _cache;

        public CacheService()
        {
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            _cache = redis.GetDatabase();
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var cachedData = await _cache.StringGetAsync(key)!;
            if (!cachedData.IsNullOrEmpty)
            {
                return JsonConvert.DeserializeObject<T>(cachedData!)!;
            }

            return default!;
        }

        public bool SetData<T>(string key, T data, DateTimeOffset expiration)
        {
            var expiryTime = expiration.DateTime.Subtract(DateTime.Now);

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };




            var s = _cache.StringSet(key, JsonConvert.SerializeObject(data, settings), expiryTime);

            return s;
        }
       
        public object RemoveData(string key)
        {
            var exist = _cache.KeyExistsAsync(key);
            if (exist == null)
            {
                return _cache.KeyDelete(key);
            }
            _cache.KeyDeleteAsync(key);


            return false;
        }
    }
}
