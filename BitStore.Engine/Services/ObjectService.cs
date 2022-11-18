using BitStore.Common.Interfaces.Redis;
using BitStore.Common.Interfaces.Repositories;
using BitStore.Common.Interfaces.Services;
using BitStore.Storage;

namespace BitStore.Engine.Services
{
    internal class ObjectService : IObjectService
    {
        private readonly IRedisCache _cache;
        private readonly IObjectRepository _objectRepository;
        public ObjectService(IRedisCache redisCache, IObjectRepository objectRepository)
        {
            _cache = redisCache;
            _objectRepository = objectRepository;
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
                var @object = await _objectRepository.GetObject(objectId, cancellationToken);
                var hostBuilder = $"{@object.Volume.Host}/{@object.AbsolutePath}";
                return new MemoryStream(Output.Read(hostBuilder));
            }

            //publish event to bus that file has been accessed
        }
    }
}
