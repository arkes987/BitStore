using BitStore.Metadata.Context;

namespace BitStore.Metadata.Repository
{
    interface IAccessRepository
    {

    }
    internal class AccessRepository : BaseRepository, IAccessRepository
    {
        public AccessRepository(MetadataContext metadataContext) : base(metadataContext)
        {

        }
    }
}
