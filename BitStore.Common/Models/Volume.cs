namespace BitStore.Common.Models
{
    public class Volume
    {
        public Guid Id { get; set; }
        public string Host { get; set; }
        public string Share { get; set; }
        public long FreeSpace { get; set; }
        public long UsedSpace { get; set; }
        public ICollection<Item> Items{ get; set; }
        public string FullPath
        {
            get
            {
                return Host + Share;
            }
        }
    }
}