using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REST_API.Models;
using REST_API.Response;

namespace QuizGame.Controllers
{
    public class ResultController : Controller
    {
        string BaseUrl = "https://localhost:44301/";
        public async Task<IActionResult> CountResult(QuestionAnswerMap questionAnswerMap)
        {
            var id=questionAnswerMap.UserId;
            Result result1 = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsJsonAsync<QuestionAnswerMap>("api/UserResult/",questionAnswerMap);
                HttpResponseMessage response1 = await client.GetAsync("api/UserResult/" +id);
                response.EnsureSuccessStatusCode();
                if (response1.IsSuccessStatusCode)
                {
                    var result = await response1.Content.ReadAsStringAsync();
                    var Count = JsonConvert.DeserializeObject<int>(result);
                     result1 = new Result();
                    result1.Number = Count;
                    return View(result1);
                }
            }

            return View(result1);
        }
    }
}
