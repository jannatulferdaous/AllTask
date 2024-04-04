using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REST_API.Models;
using REST_API.Response;

namespace QuizGame.Controllers
{
    public class UserController : Controller
    {
        string BaseUrl = "https://localhost:44301/";

        public async Task<IActionResult> GetAllUsers()

        {
            IEnumerable<User> users = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/User");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var User = JsonConvert.DeserializeObject<PagedResponse<User>>(result);

                    var user = User.Data;
                    users = user;
                }
            }
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> GetUser(int id)

        {
            User user = new User(); ;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/User/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var User = JsonConvert.DeserializeObject<User>(result);                    
                    user=User;
                }
            }
            return View(user);
        }

       [HttpGet]
        public async Task<IActionResult> Create()
        {
            User user =new User();
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsJsonAsync<User>("api/User/CreateUser", user);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "User created successfully!";
                    return RedirectToAction(nameof(GetAllUsers));
                }
                else
                {
                    Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                    return View(user);
                }
            }

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            User user = new User();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));               
                HttpResponseMessage response = await client.GetAsync("api/User/" + id);                 
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var user1 = JsonConvert.DeserializeObject<User>(result);
                    user = user1;
                }
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, User user)

        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PutAsJsonAsync<User>("api/User/" + id, user);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = " User Updated successfully!";
                    return RedirectToAction(nameof(GetAllUsers));
                }
                else
                {
                    Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                    return View(user);
                }
            }

        } 
    }
}
