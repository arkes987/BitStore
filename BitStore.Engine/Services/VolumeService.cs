using BitStore.Common.Exceptions.Volume;
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
        public async Task RegisterVolume(string share)
        {
            if(!IsShareAvailable(share))
            {
                throw new ShareNotAvailableException(share);
            }

            var volume = new Volume(Guid.NewGuid(), host: string.Empty, share);

            await _volumeRepository.RegisterVolume(volume);
        }
        public async Task<Volume> GetFreeVolume()
        {
            var volumes = await _volumeRepository.GetAllVolumes();

            return volumes.FirstOrDefault();
        }


        /// <summary>
        /// Share is available when exists and app got r&w permissions
        /// </summary>
        /// <param name="share"></param>
        /// <returns></returns>
        public bool IsShareAvailable(string share)
        {
            if(!Directory.Exists(share))
            {
                return false;
            }

            //TODO: check if we have permissions to write and read

            return true;
        }
    }
}
