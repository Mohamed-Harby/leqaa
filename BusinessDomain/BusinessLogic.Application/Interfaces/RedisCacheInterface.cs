

namespace BusinessLogic.Application.Interfaces
{
    public interface  RedisCacheInterface
    {
        Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
            where T : class;


        Task SetAsync<T>(string key, T value,CancellationToken cancellationToken = default)
            where T : class;

        Task RemoveAsync (string key, CancellationToken cancellationToken = default);
        Task RemovePrefixAsync (string prefickey, CancellationToken cancellationToken = default);
         Task<T> GetAsync<T>(string key ,Func<T> func,CancellationToken cancellationToken = default)
                    where T : class;
    
    
    }
}
