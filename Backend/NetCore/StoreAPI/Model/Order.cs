namespace StoreAPI.Model
{
    public class Order
    {
        public int Id { get; set; }
        public User Purchaser { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public float SubTotal { get; set; }
        public float Tax { get; set; }
        public float Total { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
