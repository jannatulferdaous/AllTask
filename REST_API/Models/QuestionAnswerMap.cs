using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API.Models
{
    public class QuestionAnswerMap
    {
        [Key]
        public int Id {  get; set; }      
        public int UserId { get; set; }                                
        public int QuestionId { get; set; }
         
        public int AnswerId { get; set; }
         
        public int ArticleId { get; set; }
        



    }
}
