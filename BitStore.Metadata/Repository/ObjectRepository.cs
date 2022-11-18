using BitStore.Common.Interfaces.Repositories;
using BitStore.Metadata.Context;

namespace BitStore.Metadata.Repository
{
    internal class ObjectRepository : BaseRepository, IObjectRepository
    {
        public ObjectRepository(MetadataContext metadataContext) : base(metadataContext)
        {

        }

        public async Task<Common.Models.Object> GetObject(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
