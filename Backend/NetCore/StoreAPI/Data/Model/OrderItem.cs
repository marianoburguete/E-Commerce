namespace StoreAPI.Model
{
    public class OrderItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
