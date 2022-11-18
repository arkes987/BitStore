using BitStore.Metadata.Context;

namespace BitStore.Metadata.Repository
{
    interface IObjectRepository
    {
        
    }
    internal class ObjectRepository : BaseRepository, IObjectRepository
    {
        public ObjectRepository(MetadataContext metadataContext) : base(metadataContext)
        {

        }
    }
}
