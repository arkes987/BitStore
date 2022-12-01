using Microsoft.AspNetCore.Http;

namespace BitStore.Storage
{
    public static class Input
    {
        public static async Task Save(string path, IFormFile formFile)
        {
            var fullPath = Path.Combine(path, formFile.FileName);
            using (var stream = File.Create(fullPath))
            {
                await formFile.CopyToAsync(stream);
            }
        }
    }
}