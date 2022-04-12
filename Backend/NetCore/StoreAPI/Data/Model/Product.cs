using System.Text.Json.Serialization;

namespace StoreAPI.Model
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int CreatorId { get; set; }
        [JsonIgnore]
        public virtual User CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public int Sales { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public int ItemsSold { get; set; } = 0;
        public float AvarageScore { get; set; } = 0;
        public List<Question> Questions { get; set; } = new List<Question>();
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
