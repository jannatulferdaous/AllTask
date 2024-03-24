namespace QuizGame.Models
{
    public class QuestionViewMvc
    {
        public int ArticleId { get; set; }
        public string? Question { get; set; }
        public int QuestionId { get; set; }
        public string SelectedAnswerId { get; set; }
        public List<AnswerViewMvc> Answers { get; set; }
    }
}
