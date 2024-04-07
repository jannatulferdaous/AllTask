namespace REST_API.Models
{
    public class UserArticle
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public virtual Article? Article { get; set; }
    }
}
