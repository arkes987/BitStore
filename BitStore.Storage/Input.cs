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

        /// <summary>
        /// Share is available when exists and app got r&w permissions
        /// </summary>
        /// <param name="share"></param>
        /// <returns></returns>
        public static bool IsShareAvailable(string share)
        {
            if (!Directory.Exists(share))
            {
                return false;
            }

            //TODO: check if we have permissions to write and read

            return true;
        }

        /// <summary>
        /// Checks if there is enough space on share to save item
        /// </summary>
        /// <param name="volume"></param>
        /// <param name="requestedSpace"></param>
        /// <returns></returns>
        public static bool IsEnoughSpaceOnShare(string share, long requestedSpace)
        {
            var driveInfo = new DriveInfo(share);

            if (driveInfo.AvailableFreeSpace < requestedSpace)
            {
                return false;
            }

            return true;
        }
    }
}