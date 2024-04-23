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
            QuestionView questionView = new QuestionView();
            return View(questionView);

        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionView questionView)
        {
            QAnswer answer = new QAnswer();
            Question question = new Question();
            question.ArticleId = questionView.ArticleId;
            question.QuestionText = questionView.Question;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsJsonAsync<Question>("api/Questions/CreateQuestion", question);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var newQuestion = JsonConvert.DeserializeObject<Question>(result);
                    string[] Option = new string[] {questionView.Option1, questionView.Option2, questionView.Option3, questionView.Option4};
                    var IsCorrect = new bool[] { questionView.IsCorrect1, questionView.IsCorrect2, questionView.IsCorrect3, questionView.IsCorrect4 };
                    for (int i = 0; i < 4; i++)
                    {
                        answer.QuestionId = newQuestion.Id;
                        answer.Answer = Option[i];
                        answer.IsCorrect = IsCorrect[i];
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response2 = await client.PostAsJsonAsync<QAnswer>("api/QAnswer/CreateAnswer", answer);
                        if (response.IsSuccessStatusCode)
                        {
                            ViewBag.Message = "Question created successfully!";
                            
                        }
                    }
                    return RedirectToAction(nameof(GetAllQuestions));
                }
                else
                {
                    Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                    return View(questionView);
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
