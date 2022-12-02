using BitStore.Common.Interfaces.Redis;
using BitStore.Common.Interfaces.Repositories;
using BitStore.Common.Interfaces.Services;
using BitStore.Common.Interfaces.Time;
using BitStore.Storage;
using Microsoft.AspNetCore.Http;

namespace BitStore.Engine.Services
{
    internal class ItemService : IItemService
    {
        private readonly IRedisCache _cache;
        private readonly IItemRepository _itemRepository;
        private readonly IVolumeService _volumeService;
        private readonly IClock _clock;
        public ItemService(IRedisCache redisCache,
            IItemRepository objectRepository,
            IVolumeService volumeService,
            IClock clock)
        {
            _cache = redisCache;
            _itemRepository = objectRepository;
            _clock = clock;
            _volumeService = volumeService;
        }

        public async Task AddFile(IFormFile formFile, CancellationToken cancellationToken)
        {
            var volume = await _volumeService.GetFreeVolume(formFile.Length);

            var item = new Common.Models.Item
            {
                Id = new Guid(),
                AbsolutePath = $"{volume.FullPath}/{formFile.FileName}",
                Extension = formFile.ContentType,
                CreatedAt = _clock.CurrentDate(),
                Name = formFile.FileName,
                Size = formFile.Length,
                Volume = volume
            };

            await _itemRepository.SaveItem(item);

            await Input.Save(volume.FullPath, formFile);
        }
        public Task UpdateFile(Guid itemId, IFormFile formFile, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async Task<Stream> IItemService.GetFile(Guid objectId, CancellationToken cancellationToken)
        {
            var file = await _cache.GetAsync(objectId, cancellationToken);

            if (file != null)
            {
                return new MemoryStream(file);
            }
            else
            {
                var @object = await _itemRepository.GetItem(objectId);
                var hostBuilder = $"{@object.Volume.Host}/{@object.AbsolutePath}";
                return new MemoryStream(Output.Read(hostBuilder));
            }

            //publish event to bus that file has been accessed
        }
    }
}
