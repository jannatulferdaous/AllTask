namespace QuizGame.Models
{
    public class QuestionMvc
    {
        public int QuestionId { get; set; }
        public int ArticleId { get; set; }
        public string? ArticleTitle { get; set; }
        public string? Questions { get; set; }
       
        public List<QAnswerMvc> Answers { get; set; }


         
    }
}

