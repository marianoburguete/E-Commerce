﻿namespace StoreAPI.Model
{
    public class Address
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public List<Order> OrdersShipping { get; set; } = new List<Order>();
        public List<Order> OrdersBilling { get; set; } = new List<Order>();
    }
}
