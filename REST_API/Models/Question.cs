using System.ComponentModel.DataAnnotations;

namespace REST_API.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string? ArticleTitle { get; set; }
        public string? QuestionText { get; set; }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
        public ICollection<QAnswer> Answers { get; set;}
        public virtual QuestionAnswerMap? QuestionAnswerMap { get; set; }
    }
}
