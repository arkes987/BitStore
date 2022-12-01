using BitStore.Common.Models;

namespace BitStore.Common.Interfaces.Repositories
{
    public interface IVolumeRepository
    {
        Task<IEnumerable<Volume>> GetAllVolumes();
        Task RegisterVolume(Volume volume);
        Task UnregisterVolume(Volume volume);
        Task<Volume> GetVolume(Guid id);
    }
}
