namespace BitStore.Common.Interfaces.Services
{
    public interface IObjectService
    {
        Task<Stream> GetFile(Guid objectId, CancellationToken cancellationToken);
        Task SaveFile(CancellationToken cancellationToken);
    }
}
