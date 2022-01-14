using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Vcmng.Manager.Cache
{
    public class RedisCacheProvider : ICacheProvider
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCacheProvider(
            IDistributedCache distributedCache
            )
        {
            _distributedCache = distributedCache;
        }

        public async Task<T> GetAsync<T>(string cacheKey, Func<Task<T>> action, int miliseconds = 60000) where T : class
        {
            var item = await _distributedCache.GetAsync(cacheKey);
            if (item != null)
            {
                var serialized = Encoding.UTF8.GetString(item);
                return JsonConvert.DeserializeObject<T>(serialized);
            }
            var response = await action();
            await _distributedCache.SetAsync(cacheKey, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response)), new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMilliseconds(miliseconds),
            });
            return response;
        }
    }
}
