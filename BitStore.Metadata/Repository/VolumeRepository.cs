using BitStore.Metadata.Context;
using BitStore.Metadata.Models;

namespace BitStore.Metadata.Repository
{
    interface IVolumeRepository
    {
        void RegisterVolume(Volume volume);
        void UnregisterVolume(Volume volume);
    }
    internal class VolumeRepository : BaseRepository, IVolumeRepository
    {
        public VolumeRepository(MetadataContext metadataContext) : base(metadataContext)
        {

        }

        public void RegisterVolume(Volume volume)
        {
            throw new NotImplementedException();
        }

        public void UnregisterVolume(Volume volume)
        {
            throw new NotImplementedException();
        }
    }
}
