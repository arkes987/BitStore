using BitStore.Common.Interfaces.Redis;
using Microsoft.Extensions.Caching.Distributed;

namespace BitStore.Cache
{
    public class RedisCache : IRedisCache
    {
        private readonly IDistributedCache _distributedCache;
        public RedisCache(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task SaveAsync(Guid key, byte[] resource, CancellationToken cancellationToken)
        {
            await _distributedCache.SetAsync(key.ToString(), resource, cancellationToken);
        }

        public async Task<byte[]?> GetAsync(Guid key, CancellationToken cancellationToken)
        {
            return await _distributedCache.GetAsync(key.ToString(), cancellationToken);
        }
    }
}
