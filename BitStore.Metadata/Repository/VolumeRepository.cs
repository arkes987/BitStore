using BitStore.Common.Interfaces.Repositories;
using BitStore.Common.Models;
using BitStore.Metadata.Context;

namespace BitStore.Metadata.Repository
{
    internal class VolumeRepository : BaseRepository, IVolumeRepository
    {
        public VolumeRepository(MetadataContext metadataContext) : base(metadataContext)
        {

        }

        public void GetVolume(Guid id)
        {
            throw new NotImplementedException();
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
