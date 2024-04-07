using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REST_API.Models;
using REST_API.Response;
using System.ComponentModel;
using System.Net.Http;

namespace QuizGame.Controllers
{
    public class LoginController : Controller
    {
        string BaseUrl = "https://localhost:44301/";

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Login login =new Login();           
            return View(login);
        }
         
        [HttpPost]
        public async Task<IActionResult> Index(Login login)
        {
            if (login != null)
            {
                 User user1 = new User();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.PostAsJsonAsync<Login>("api/User/ValidUser", login);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var validUSer = JsonConvert.DeserializeObject<User>(result);
                        user1 = new User();
                        user1 = validUSer;

                    }
                }
                if (user1 != null & user1.Id!=0)
                {
                    HttpContext.Session.SetInt32("UserId", user1.Id);
                    return RedirectToAction("Index", "ArticleView");
                }
                else
                {
                    return View(login);
                }
            }
            return View(login);
        }
    }
}
