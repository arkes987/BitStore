using BitStore.Common.Models;

namespace BitStore.Common.Interfaces.Services
{
    public interface IVolumeService
    {
        Task<Volume> GetFreeVolume();
        Task RegisterVolume(string share);
    }
}
