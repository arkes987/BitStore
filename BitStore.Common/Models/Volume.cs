namespace BitStore.Common.Models
{
    public class Volume
    {
        private Volume() { }
        public Volume(Guid id, string host, string share)
        {
            Id = id;
            Host = host;
            Share = share;
        }

        public Guid Id { get; }
        public string Host { get; }
        public string Share { get; }
        public long FreeSpace { get; }
        public long UsedSpace { get; }
        public ICollection<Item> Items{ get; }
        public string FullPath
        {
            get
            {
                return Host + Share;
            }
        }
    }
}