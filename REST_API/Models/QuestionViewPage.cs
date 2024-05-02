namespace REST_API.Models
{
    public class QuestionViewPage
    {
        public int ArticleId { get; set; }
        public string? Question { get; set; }
        public int QuestionId { get; set; }
        public int SelectedAnswerId { get; set; }
        public List<AnswerView> Answers { get; set; }
    }
}
