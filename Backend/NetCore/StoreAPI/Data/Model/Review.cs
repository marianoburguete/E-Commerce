namespace StoreAPI.Model
{
    public class Review
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(User))]
        public int PurchaserId { get; set; }
        [JsonIgnore]
        public virtual User Purchaser { get; set; }
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
