using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Interfaces
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key);
         bool SetData<T>(string key, T data, DateTimeOffset expiration);
        Task<T> handlCaching<T>(string key, Func<T>? query);
       object RemoveData(string key);
    }
}
