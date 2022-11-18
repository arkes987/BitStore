namespace BitStore.Metadata.Models
{
    internal class Volume
    {
        public Guid Id { get; set; }
        public string Host { get; set; }
        public long FreeSpace { get; set; }
        public long UsedSpace { get; set; }
    }
}
