namespace BitStore.Common.Interfaces.Redis
{
    public interface IRedisCache
    {
        Task SaveAsync(Guid key, byte[] resource, CancellationToken cancellationToken);
        Task<byte[]?> GetAsync(Guid key, CancellationToken cancellationToken);
    }
}
