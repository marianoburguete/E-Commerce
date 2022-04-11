using System.Text.Json.Serialization;

namespace StoreAPI.Model
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [JsonIgnore]
        public User Purchaser { get; set; }
        [ForeignKey(nameof(User))]
        public int PurchaserId { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public float SubTotal { get; set; }
        public float Tax { get; set; }
        public float Total { get; set; }
        [JsonIgnore]
        public Address ShippingAddress { get; set; }
        [ForeignKey("ShippingAddressId")]
        public int ShippingAddressId { get; set; }
        [JsonIgnore]
        public Address BillingAddress { get; set; }
        [ForeignKey("BillingAddressId")]
        public int BillingAddressId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
