using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Newtonsoft.Json;
using REST_API.Models;
using System.Net.Http;

namespace QuizGame.Controllers
{
    public class QuestionViewController : Controller
    {
        string BaseUrl = "https://localhost:44301/";
       
        public async Task<IActionResult> Index(int id)
        {
            List<QuestionViewPage> questionViewPage =null;
                
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/QuestionView/" +id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var Answer = JsonConvert.DeserializeObject<List<QuestionViewPage>>(result);            
                    questionViewPage = Answer;
                }
            }
            return View(questionViewPage);
        }
            




        //[HttpPost]
        //public IActionResult Index(List<QuestionShow> UserData)
        //{
        //    var sessionUserId = HttpContext.Session.GetInt32("UserId");
        //    int userId = 0;
        //    int questionId = 0;
        //    List<string> questionAnswerIds = new List<string>();

        //    if (sessionUserId != null && sessionUserId > 0)
        //    {
        //        userId = (int)sessionUserId;
        //    }

        //    if (UserData != null)
        //    {
        //        foreach (var item in UserData)
        //        {
        //            questionAnswerIds.Add($"{item.QuestionId}={item.SelectedAnswerId}");
        //            if (questionId == 0)
        //            {
        //                questionId = item.QuestionId;
        //            }
        //        }
        //    }

        //    if (questionAnswerIds.Count > 0)
        //    {
        //        QuestionPageData questionPageData = new QuestionPageData();
        //        // save the answers
        //        questionPageData.UserAnswer(userId, string.Join(",", questionAnswerIds));
        //        // set the next artical for the user
        //        questionPageData.NextArticle(questionId, userId);
        //        // return to result view
        //        return RedirectToAction("Index", "Result");
        //    }
        //    else
        //    {
        //        return View(UserData);
        //    }
        //}
         
    }
}
