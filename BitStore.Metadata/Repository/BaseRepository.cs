using BitStore.Metadata.Context;
using Dapper;

namespace BitStore.Metadata.Repository
{
    public abstract class BaseRepository<T>
    {
        protected readonly MetadataContext _context;
        public BaseRepository(MetadataContext metadataContext)
        {
            _context = metadataContext;
        }

        public virtual async Task<T> GetById(Guid id)
        {
            using (var db = _context.Connection)
            {
                string query = $"SELECT Id = @Id;";
                return await db.QuerySingleOrDefaultAsync<T>(query, new { Id = id });
            }
        }
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            using (var db = _context.Connection)
            {
                return await db.QueryAsync<T>("SELECT");
            }
        }
    }
}
