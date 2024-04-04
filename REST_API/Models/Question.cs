using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace REST_API.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [AllowHtml]
        [DataType(DataType.Text)]
        public string? QuestionText { get; set; }
        public int ArticleId { get; set; }
        public virtual Article? Article { get; set; }
        public ICollection<QAnswer>? Answers { get; set;}
        public virtual QuestionAnswerMap? QuestionAnswerMap { get; set; }

         
    }
}
