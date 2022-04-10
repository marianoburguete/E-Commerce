namespace StoreAPI.Model
{
    public class Product
    {
        public int Id { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public int ItemsSold { get; set; }
        public float AvarageScore { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
