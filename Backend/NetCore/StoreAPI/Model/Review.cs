namespace StoreAPI.Model
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public Product Product { get; set; }
        public User Purchaser { get; set; }
        public Order Order { get; set; }
    }
}
