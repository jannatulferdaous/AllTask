namespace REST_API.Models
{
    public class QuestionView
    {
        public int ArticleId { get; set; }
        public string? Question { get; set; }
        public int QuestionId { get; set; }
        public int SelectedAnswerId { get; set; }
        public string? Option1 { get; set; }      
        public bool IsCorrect1 { get; set; }
        public string? Option2 { get; set; }
        public bool IsCorrect2 { get; set; }
        public string? Option3 { get; set; }
        public bool IsCorrect3 { get; set; }
        public string? Option4 { get; set; }
        public bool IsCorrect4 { get; set; }
        public List<AnswerView> Answers { get; set; }
    }
}
