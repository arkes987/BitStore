namespace BitStore.Common.Models
{
    public class Object
    {
        public Guid Id { get; set; }
        public long Size { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string AbsolutePath { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}