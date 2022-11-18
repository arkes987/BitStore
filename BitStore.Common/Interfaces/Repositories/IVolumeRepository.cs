using BitStore.Common.Models;

namespace BitStore.Common.Interfaces.Repositories
{
    public interface IVolumeRepository
    {
        void RegisterVolume(Volume volume);
        void UnregisterVolume(Volume volume);
        void GetVolume(Guid id);
    }
}
