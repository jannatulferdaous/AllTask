using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace REST_API.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        public string? Title { get; set; }
        public string? Language { get; set; }
        [AllowHtml]
        [DataType(DataType.Text)]
        public string? ArticleText { get; set; }
        public  ICollection<Question>? questions { get; set; }
         

    }
}
