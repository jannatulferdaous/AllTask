using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REST_API.Models;
using REST_API.Response;
using System.Net.Http;

namespace QuizGame.Controllers
{
    public class AnswerController : Controller
    {
        string BaseUrl = "https://localhost:44301/";
        public async Task<IActionResult> GetAllAnswers()
        {
            IEnumerable<QAnswer> qAnswers = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/QAnswers");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var Answer = JsonConvert.DeserializeObject<PagedResponse<QAnswer>>(result);

                    var answer = Answer.Data;
                    qAnswers = answer;
                }
            }
            return View(qAnswers);
        }
        [HttpGet]
        public async Task<IActionResult> GetAnswer(int id)

        {
             QAnswer answer = new QAnswer();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/QAnswers/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var Ans = JsonConvert.DeserializeObject<QAnswer>(result);
                    answer =Ans;
                }
            }
            return View(answer);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

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
                    var questions = Question.Data;
                    ViewBag.Question = questions;

                }
            }
             QAnswer answer= new QAnswer();
            return View(answer);

        }

        [HttpPost]
        public async Task<IActionResult> Create(QAnswer answer)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsJsonAsync<QAnswer>("api/QAnswers/CreateAnswer",answer);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Answer created successfully!";
                    return RedirectToAction(nameof(GetAllAnswers));
                }
                else
                {
                    Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                    return View(answer);
                }
            }

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
             QAnswer answer = new QAnswer();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Questions");
                HttpResponseMessage response2 = await client.GetAsync("api/QAnswers/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var question = JsonConvert.DeserializeObject<PagedResponse<Question>>(result);
                    var QSN = question.Data;
                    ViewBag.Question = QSN;

                }
                if (response2.IsSuccessStatusCode)
                {
                    var result = await response2.Content.ReadAsStringAsync();
                    var Answer = JsonConvert.DeserializeObject<QAnswer>(result);
                    answer = Answer;
                }
            }
            return View(answer);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, QAnswer answer)

        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PutAsJsonAsync<QAnswer>("api/QAnswers/" + id, answer);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = " Question Updated successfully!";
                    return RedirectToAction(nameof(GetAllAnswers));
                }
                else
                {
                    Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                    return View(answer);
                }
            }

        }

    }
}
