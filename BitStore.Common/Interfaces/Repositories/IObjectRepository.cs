namespace BitStore.Common.Interfaces.Repositories
{
    public interface IObjectRepository
    {
        Task<Models.Object> GetObject(Guid id, CancellationToken cancellationToken);
    }
}
