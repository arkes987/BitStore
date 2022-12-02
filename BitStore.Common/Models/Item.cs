namespace BitStore.Common.Models
{
    public class Item
    {
        public const string TableName = "items";
        public Guid Id { get; set; }
        public long Size { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string AbsolutePath { get; set; }
        public DateTime CreatedAt { get; set; }
        public Volume Volume { get; set; }
        public Access Access { get; set; }
        public Guid AccessId { get; set; }
    }
}