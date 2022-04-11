namespace StoreAPI.Datatypes
{
    public class ProductDto
    {
        public int CreatorId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public int ItemsSold { get; set; }
        public float AvarageScore { get; set; }
    }
}
