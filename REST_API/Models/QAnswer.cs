using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace REST_API.Models
{
    public class QAnswer
    {
        [Key]
        public int  Id { get; set; }
        [AllowHtml]
        [DataType(DataType.Text)]
        public string? Answer { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public virtual Question? Question { get; set; }
        public QuestionAnswerMap? QuestionAnswerMap { get; set; }

    }
}
