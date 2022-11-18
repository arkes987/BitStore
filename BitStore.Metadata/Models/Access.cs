namespace BitStore.Metadata.Models
{
    internal class Access
    {
        public Guid ObjectId { get; set; }
        public DateTime LastAccessAt { get; set; }
        public long Reads { get; set; }
        public long Writes { get; set; }
    }
}