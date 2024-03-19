namespace QuizGame.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int ArticleId { get; set; }
        public string? ArticleTitle { get; set; }
        public string? Questions { get; set; }
       
        public List<QAnswer> Answers { get; set; }


         
    }
}

