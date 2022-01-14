using System;
using System.Threading.Tasks;

namespace Vcmng.Manager.Cache
{
    public interface ICacheProvider
    {
        Task<T> GetAsync<T>(string cacheKey, Func<Task<T>> action, int miliseconds = 60000) where T : class;
    }
}
