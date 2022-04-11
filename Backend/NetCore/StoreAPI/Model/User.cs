namespace StoreAPI.Model
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //public List<Address> ShippingAddresses { get; set; } = new List<Address>();
        //public Address? DefaultShippingAddress { get; set; }
        public List<Address> BillingAddresses { get; set; } = new List<Address>();
        public Address? DefaultBillingAddress { get; set; }
        [ForeignKey(nameof(Cart))]
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; } = new Cart();
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Product> MyProducts { get; set; } = new List<Product>();
    }
}
