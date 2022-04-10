namespace StoreAPI.Model
{
    public class Cart
    {
        public int Id { get; set; }
        public User Owner { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
