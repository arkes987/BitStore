using BitStore.Common.Interfaces.Redis;
using BitStore.Common.Interfaces.Services;

namespace BitStore.Engine.Services
{
    internal class ObjectService : IObjectService
    {
        private readonly IRedisCache _cache;
        public ObjectService(IRedisCache redisCache)
        {
            _cache = redisCache;
        }

        public Task SaveFile(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async Task<Stream> IObjectService.GetFile(Guid objectId, CancellationToken cancellationToken)
        {
            var file = await _cache.GetAsync(objectId, cancellationToken);

            if(file != null)
            {
                return new MemoryStream(file);
            }
            else
            {
                throw new NotImplementedException();
                // get it from disk
            }

            //publish event to bus that file has been accessed
        }
    }
}
