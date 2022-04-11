using System.Text.Json.Serialization;

namespace StoreAPI.Model
{
    public class Question
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [JsonIgnore]
        public User Author { get; set; }
        [ForeignKey(nameof(User))]
        public int AuthorId { get; set; }
        public string QuestionText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Answer { get; set; } = string.Empty;
        public bool IsAnswered { get; set; } = false;
    }
}
