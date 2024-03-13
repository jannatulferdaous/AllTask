using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API.Models
{
    public class QuestionAnswerMap
    {
        [Key]
        public int Id {  get; set; }      
        public int UserId { get; set; }
        public User user { get; set; }         
        public int QuestionId { get; set; }
        public Question question {  get; set; } 
        public int AnswerId { get; set; }
        public QAnswer answer { get; set; }
        public int ArticleId { get; set; }
        public Article article { get; set;}



    }
}
