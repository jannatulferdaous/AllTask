namespace REST_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public QuestionAnswerMap? QuestionAnswerMap { get; set; }
    }
}
