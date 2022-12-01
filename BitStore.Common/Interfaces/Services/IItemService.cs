using Microsoft.AspNetCore.Http;

namespace BitStore.Common.Interfaces.Services
{
    public interface IItemService
    {
        Task<Stream> GetFile(Guid itemId, CancellationToken cancellationToken);
        Task UpdateFile(Guid itemId, IFormFile formFile, CancellationToken cancellationToken);
        Task AddFile(IFormFile formFile, CancellationToken cancellationToken);
    }
}
