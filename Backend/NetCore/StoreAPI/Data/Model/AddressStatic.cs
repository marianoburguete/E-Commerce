namespace StoreAPI.Datatypes
{
    public class AddressStatic
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        [JsonIgnore]
        public List<Order> OrdersShipping { get; set; } = new List<Order>();
        [JsonIgnore]
        public List<Order> OrdersBilling { get; set; } = new List<Order>();
    }
}
