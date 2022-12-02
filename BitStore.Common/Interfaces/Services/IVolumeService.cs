using BitStore.Common.Models;

namespace BitStore.Common.Interfaces.Services
{
    public interface IVolumeService
    {
        Task<Volume> GetFreeVolume(long requestedSpace);
        Task RegisterVolume(string share);
    }
}
