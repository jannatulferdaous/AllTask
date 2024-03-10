namespace REST_API.Response
{
    public class QuestionView
    {
        public int ArticleId { get; set; }
        public string? Question { get; set; }
        public int QuestionId { get; set; }
        public string SelectedAnswerId { get; set; }
        public List<AnswerView> Answers { get; set; }
    }
}
