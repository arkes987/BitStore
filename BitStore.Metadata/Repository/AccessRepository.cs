using BitStore.Common.Interfaces.Repositories;
using BitStore.Common.Models;
using BitStore.Metadata.Context;

namespace BitStore.Metadata.Repository
{
    internal class AccessRepository : BaseRepository<Access>, IAccessRepository
    {
        public AccessRepository(MetadataContext metadataContext) : base(metadataContext)
        {

        }
    }
}
