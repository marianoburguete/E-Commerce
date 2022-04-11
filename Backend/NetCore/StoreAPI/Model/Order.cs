using System.Text.Json.Serialization;

namespace StoreAPI.Model
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Purchaser")]
        public int PurchaserId { get; set; }
        public virtual User Purchaser { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public float SubTotal { get; set; }
        public float Tax { get; set; }
        public float Total { get; set; }
        
        [ForeignKey("ShippingAddress")]
        public int ShippingAddressId { get; set; }
        public virtual Address ShippingAddress { get; set; }

        [ForeignKey("BillingAddress")]
        public int BillingAddressId { get; set; }        
        public virtual Address BillingAddress { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
