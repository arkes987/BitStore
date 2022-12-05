using Microsoft.AspNetCore.Http;

namespace BitStore.Common.Interfaces.Services
{
    public interface IItemService
    {
        Task<Stream> GetItem(Guid itemId, CancellationToken cancellationToken);
        Task UpdateItem(Guid itemId, IFormFile formFile, CancellationToken cancellationToken);
        Task AddItem(IFormFile formFile, CancellationToken cancellationToken);
    }
}
