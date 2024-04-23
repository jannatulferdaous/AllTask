using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult Create()
        {
            Article article = new Article();
            return View(article);
        }

        [HttpPost]
        public async Task <IActionResult> Create(Article article)

        {
          
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsJsonAsync<Article>("api/Article/CreateArticle", article);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Article created successfully!";
                    return RedirectToAction(nameof(GetAllArticle));
                }
                else
                {           
                    Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                    return View(article);
                }
            }  

        }
        [HttpGet]
        public async Task<IActionResult>Update(int id)
        { 
            Article article2 = new Article();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Article/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var article = JsonConvert.DeserializeObject<Article>(result);
                    article2 = article;

                }
            }
            return View(article2);
        }

        [HttpPost]
        public async Task<IActionResult> Update( int id,Article article)

        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PutAsJsonAsync<Article>("api/Article/"+id, article);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Article Updated successfully!";
                    return RedirectToAction(nameof(GetAllArticle));
                }
                else
                {
                    Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                    return View(article);
                }
            }

        }
    }
}
