namespace BitStore.Storage
{
    public static class Output
    {
        public static byte[] Read(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}
