namespace StoreAPI.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
