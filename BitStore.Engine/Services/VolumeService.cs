using BitStore.Common.Interfaces.Repositories;
using BitStore.Common.Interfaces.Services;
using BitStore.Common.Models;

namespace BitStore.Engine.Services
{
    public class VolumeService : IVolumeService
    {
        private readonly IVolumeRepository _volumeRepository;
        public VolumeService(IVolumeRepository volumeRepository)
        {
            _volumeRepository = volumeRepository;
        }

        public async Task<Volume> GetFreeVolume()
        {
            var volumes = await _volumeRepository.GetAllVolumes();

            return volumes.FirstOrDefault();
        }
    }
}
