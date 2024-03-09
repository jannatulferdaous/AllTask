namespace REST_API.Models
{
    public class QAnswer
    {
        public int  Id { get; set; }
        public string? Answer { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

    }
}
