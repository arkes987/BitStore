using BitStore.Metadata.Context;

namespace BitStore.Metadata.Repository
{
    internal class BaseRepository
    {
        protected readonly MetadataContext _context;
        public BaseRepository(MetadataContext metadataContext)
        {
            _context = metadataContext;
        }
    }
}
