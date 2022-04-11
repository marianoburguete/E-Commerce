using System.Text.Json.Serialization;

namespace StoreAPI.Model
{
    public class Review
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [JsonIgnore]
        public User Purchaser { get; set; }
        [ForeignKey(nameof(User))]
        public int PurchaserId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
