namespace StoreAPI.Model
{
    public class Cart
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int OwnerId { get; set; }
        [JsonIgnore]
        public virtual User Owner { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
