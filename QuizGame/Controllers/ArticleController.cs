using Microsoft.AspNetCore.Mvc;
using QuizGame.Models;
using System.Diagnostics;
using REST_API;

namespace QuizGame.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public ArticleController(ILogger<ArticleController> logger, HttpClient httpClient, IConfiguration configuration)
        {
            _logger = logger;
            _httpClient = httpClient;
            _apiBaseUrl = configuration["ApiBaseUrl"];
        }

        public async Task<IActionResult> Index(int id = 1)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/Article/{id}");

            if (response.IsSuccessStatusCode)
            {
                var tutorial = await response.Content.ReadAsAsync<QuizGame.Models.Article>();  
                return View(tutorial);
            }

            return NotFound();
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
