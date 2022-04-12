namespace StoreAPI.Model
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
