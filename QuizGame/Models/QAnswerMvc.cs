namespace QuizGame.Models
{
    public class QAnswerMvc
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string? Answer { get; set; }
        public Boolean IsCorrect { get; set; }
    }
}
