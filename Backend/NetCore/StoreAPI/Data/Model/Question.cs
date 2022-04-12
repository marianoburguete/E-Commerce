namespace StoreAPI.Model
{
    public class Question
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(User))]
        public int AuthorId { get; set; }
        [JsonIgnore]
        public virtual User Author { get; set; }
        public string QuestionText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Answer { get; set; } = string.Empty;
        public bool IsAnswered { get; set; } = false;
    }
}
