﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REST_API.Models;
using REST_API.Response;

namespace REST_API.Controllers
{
    public class ArticleViewController : Controller
    {

        private readonly ILogger<ArticleViewController> _logger;
        string BaseUrl = "https://localhost:44301/";

        public ArticleViewController(ILogger<ArticleViewController> logger)
        {
            _logger = logger;

        }
        public async Task<IActionResult> Index()

        {
            var sessionUserId = HttpContext.Session.GetInt32("UserId");
            int userId = 0;
            if (sessionUserId != null && sessionUserId > 0)
            {
                userId = (int)sessionUserId;
            }
            if (userId > 0)
            {
                Article article1 = new Article();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync("api/Article/Index" + userId);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var article = JsonConvert.DeserializeObject<Article>(result);
                        article1 = article;

                    }
                }
                return View(article1);
            }
            return Unauthorized();            
        }

        public async Task<IActionResult> GetArticle( int id=1)

        {
             Article article1 = new Article();
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
                    article1 = article;
                     
                }
            }
             return View(article1);
        }

          
    }
}
