using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API.Models
{
    public class QuestionAnswerMap
    {
        public int id {  get; set; }
        public int UserId { get; set; } 
        public int QuestionsId { get; set; }       
        public int IdAnswers { get; set; }
        public int ArticlesId { get; set; }



    }
}
