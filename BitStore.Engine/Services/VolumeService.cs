using BitStore.Common.Exceptions.Volume;
using BitStore.Common.Interfaces.Repositories;
using BitStore.Common.Interfaces.Services;
using BitStore.Common.Models;
using BitStore.Storage;
using Microsoft.Extensions.Logging;

namespace BitStore.Engine.Services
{
    public class VolumeService : IVolumeService
    {
        private readonly IVolumeRepository _volumeRepository;
        private readonly ILogger<VolumeService> _logger;
        public VolumeService(IVolumeRepository volumeRepository, ILogger<VolumeService> logger)
        {
            _volumeRepository = volumeRepository;
            _logger = logger;
        }
        public async Task RegisterVolume(string share)
        {
            if (!Input.IsShareAvailable(share))
            {
                throw new ShareNotAvailableException(share);
            }

            var volume = new Volume(Guid.NewGuid(), host: string.Empty, share);

            await _volumeRepository.RegisterVolume(volume);

            _logger.LogInformation("New volume registered with {id}", volume.Id);

            //TODO: propagate event that volume registered
        }
        public async Task<Volume> GetFreeVolume(long requestedSpace)
        {
            var volumes = await _volumeRepository.GetAllVolumes();

            if (!volumes.Any())
            {
                throw new NoVolumesAvailableException();
            }

            var highestSpaceVolume = volumes
                .OrderBy(x => x.FreeSpace)
                .FirstOrDefault(x => x.FreeSpace >= requestedSpace);

            if (highestSpaceVolume is null || !Input.IsEnoughSpaceOnShare(highestSpaceVolume.FullPath, requestedSpace))
            {
                throw new NoEnoughSpaceOnVolumeException(requestedSpace);
            }

            return highestSpaceVolume;
        }
    }
}
