using BitStore.Common.Interfaces.Services;

namespace BitStore.Engine.Services
{
    internal class ObjectService : IObjectService
    {

        public ObjectService()
        {

        }
        Task<Stream> IObjectService.GetFile(Guid objectId)
        {
            throw new NotImplementedException();
        }
    }
}
