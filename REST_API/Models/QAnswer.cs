using System.ComponentModel.DataAnnotations;

namespace REST_API.Models
{
    public class QAnswer
    {
        [Key]
        public int  Id { get; set; }
        public string? Answer { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public virtual Question? Question { get; set; }
        public QuestionAnswerMap? QuestionAnswerMap { get; set; }

    }
}
