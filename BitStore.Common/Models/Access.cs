namespace BitStore.Common.Models
{
    public class Access
    {
        public Guid ObjectId { get; set; }
        public DateTime LastAccessAt { get; set; }
        public long Reads { get; set; }
        public long Writes { get; set; }
    }
}