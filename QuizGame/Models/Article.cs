using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace QuizGame.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string? Language { get; set; }
        public string? Title { get; set; }
        [AllowHtml]
        [DataType(DataType.Text)]
        public string? ArticleText { get; set; }
    }
}
