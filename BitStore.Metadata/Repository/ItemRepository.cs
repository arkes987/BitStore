using BitStore.Common.Interfaces.Repositories;
using BitStore.Common.Models;
using BitStore.Metadata.Context;
using Dapper;

namespace BitStore.Metadata.Repository
{
    internal class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(MetadataContext metadataContext) : base(metadataContext, Item.TableName) { }

        public async Task<Item> GetItem(Guid id)
            => await base.GetById(id);

        public async Task SaveItem(Item item)
        {
            using (var db = _context.Connection)
            {
                string insertQuery = """INSERT INTO items ("Id", "Size", "Name", "Extension", "AbsolutePath", "CreatedAt", "VolumeId", "AccessId") VALUES (@Id, @Size, @Name, @Extension, @AbsolutePath, @CreatedAt, @VolumeId, @AccessId)""";

                await db.ExecuteAsync(insertQuery, 
                    new
                    {
                        Id = item.Id,
                        Size = item.Size,
                        Name = item.Name,
                        Extension = item.Extension,
                        AbsolutePath = item.AbsolutePath,
                        CreatedAt = item.CreatedAt,
                        VolumeId = item.Volume.Id,
                        AccessId = item.Access?.Id
                    });
            }
        }
    }
}
