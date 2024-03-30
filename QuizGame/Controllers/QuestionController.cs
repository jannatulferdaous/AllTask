using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REST_API.Models;
using REST_API.Response;

namespace QuizGame.Controllers
{
    public class QuestionController : Controller
    {         
        string BaseUrl = "https://localhost:44301/";

        public async Task<IActionResult> GetAllQuestions()

        {
            IEnumerable<Question> questions = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Questions");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var Question = JsonConvert.DeserializeObject<PagedResponse<Question>>(result);

                    var question = Question.Data;
                    questions = question;
                }
            }
            return View(questions);
        }
        [HttpGet]
        public async Task<IActionResult> GetQuestion(int id)

        {
            Question question = new Question();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Questions/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var Qsn = JsonConvert.DeserializeObject<Question>(result);
                    question = Qsn;
                }
            }
            return View(question);
        }





        [HttpGet]
        public async Task<IActionResult> Create()
        {
            
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Article");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var article = JsonConvert.DeserializeObject<PagedResponse<Article>>(result);
                    var article2 = article.Data;
                    ViewBag.Article = article2;
                    
                }
            }
            Question question = new Question();
            return View(question);

        }

        [HttpPost]
        public async Task<IActionResult> Create(Question question)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsJsonAsync<Question>("api/Questions/CreateQuestion", question);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Question created successfully!";
                    return RedirectToAction(nameof(GetAllQuestions));
                }
                else
                {
                    Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                    return View(question);
                }
            }

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Question question = new Question();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Article");
                HttpResponseMessage response2 = await client.GetAsync("api/Questions/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var article = JsonConvert.DeserializeObject<PagedResponse<Article>>(result);
                    var article1 = article.Data;
                    ViewBag.Article = article1;

                }
                if (response2.IsSuccessStatusCode)
                {
                    var result = await response2.Content.ReadAsStringAsync();
                    var Question = JsonConvert.DeserializeObject<Question>(result);
                    question = Question;
                }
            }
            return View(question);
        }
          
        [HttpPost]
        public async Task<IActionResult> Update(int id, Question question)

        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PutAsJsonAsync<Question>("api/Questions/" + id, question);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = " Question Updated successfully!";
                    return RedirectToAction(nameof(GetAllQuestions));
                }
                else
                {
                    Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                    return View(question);
                }
            }

        }

    }
}
