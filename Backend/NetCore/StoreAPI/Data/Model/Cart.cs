namespace StoreAPI.Model
{
    public class Cart
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
