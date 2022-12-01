using BitStore.Common.Interfaces.Repositories;
using BitStore.Common.Models;
using BitStore.Metadata.Context;
using Dapper;

namespace BitStore.Metadata.Repository
{
    internal class VolumeRepository : BaseRepository<Volume>, IVolumeRepository
    {
        public VolumeRepository(MetadataContext metadataContext) : base(metadataContext) { }

        public async Task<IEnumerable<Volume>> GetAllVolumes()
            => await base.GetAll();
        public async Task<Volume> GetVolume(Guid id)
            => await base.GetById(id);

        public async Task RegisterVolume(Volume volume)
        {
            using (var db = _context.Connection)
            {
                string insertQuery = @"INSERT INTO Objects ([Id], [Size], [Name], [Extension], [AbsolutePath], [CreatedAt], [VolumeId]) VALUES (@Id, @Size, @Name, @Extension, @AbsolutePath, @CreatedAt, @VolumeId)";
                await db.ExecuteAsync(insertQuery, volume);
            }
        }
        public async Task UnregisterVolume(Volume volume)
        {
            using (var db = _context.Connection)
            {
                var sql = "DELETE Volumes WHERE Id = @Id";
                await db.ExecuteAsync(sql, new { Id = volume.Id });
            }
        }
    }
}
