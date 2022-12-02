using BitStore.Common.Exceptions.Volume;
using BitStore.Common.Interfaces.Repositories;
using BitStore.Common.Interfaces.Services;
using BitStore.Common.Models;
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
            if (!IsShareAvailable(share))
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

            var highestSpaceVolume = volumes.OrderBy(x => x.FreeSpace).FirstOrDefault();

            if (highestSpaceVolume.FreeSpace < requestedSpace)
            {
                throw new NoEnoughSpaceOnVolumeException(requestedSpace);
            }

            //TODO: physically check if there is space on disk for requested space

            return highestSpaceVolume;
        }


        /// <summary>
        /// Share is available when exists and app got r&w permissions
        /// </summary>
        /// <param name="share"></param>
        /// <returns></returns>
        public bool IsShareAvailable(string share)
        {
            if (!Directory.Exists(share))
            {
                return false;
            }

            //TODO: check if we have permissions to write and read

            return true;
        }
    }
}
