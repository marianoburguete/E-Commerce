namespace StoreAPI.Model
{
    public class Question
    {
        public int Id { get; set; }
        public Product Product { get; set; } // Cambiar a referencia de Id para no traerse todo?
        public User Author { get; set; } // Cambiar a referencia de Id para no traerse todo?
        public string QuestionText { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Answer { get; set; } = string.Empty;
        public bool IsAnswered { get; set; } = false;
    }
}
