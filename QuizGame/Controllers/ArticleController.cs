using Microsoft.AspNetCore.Mvc;
using QuizGame.Models;
using System.Diagnostics;
using REST_API;
using REST_API.Models;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using REST_API.Response;
using System.Linq;

namespace QuizGame.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ILogger<ArticleController> _logger;
        string BaseUrl= "https://localhost:44301/" ;

        public ArticleController(ILogger<ArticleController> logger)
        {
            _logger = logger;
             
        }
        public async Task<IActionResult> GetAllArticle()

        {
            IEnumerable<Article> articles = null;
            using (HttpClient client = new HttpClient()) 
            { 
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response= await client.GetAsync("api/Article");
                if (response.IsSuccessStatusCode)
                {
                    var result= await response.Content.ReadAsStringAsync();
                    var article = JsonConvert.DeserializeObject <PagedResponse<Article>>(result);

                    var article2 = article.Data;  
                    articles = article2;
                }
            }
            return View(articles);
        }
         
         
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
