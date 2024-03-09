namespace REST_API.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string? ArticleTitle { get; set; }
        public string? QuestionText { get; set; }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
        public virtual QAnswer Answers { get; set;}
            
    }
}
