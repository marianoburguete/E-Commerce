using System.Text.Json.Serialization;

namespace StoreAPI.Model
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [JsonIgnore]
        public User CreatedBy { get; set; }
        [ForeignKey(nameof(User))]
        public int CreatorId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public int ItemsSold { get; set; }
        public float AvarageScore { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
