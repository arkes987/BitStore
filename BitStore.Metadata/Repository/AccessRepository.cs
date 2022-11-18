using BitStore.Common.Interfaces.Repositories;
using BitStore.Metadata.Context;

namespace BitStore.Metadata.Repository
{
    internal class AccessRepository : BaseRepository, IAccessRepository
    {
        public AccessRepository(MetadataContext metadataContext) : base(metadataContext)
        {

        }
    }
}
