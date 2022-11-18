namespace BitStore.Common.Interfaces.Services
{
    public interface IObjectService
    {
        Task<Stream> GetFile(Guid objectId);
    }
}
