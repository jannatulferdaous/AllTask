using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Newtonsoft.Json;
using REST_API.Models;
using REST_API.Controllers;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuizGame.Controllers
{
    public class MvcQuestionViewController : Controller
    {
        readonly string BaseUrl = "https://localhost:44301/";
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            List<QuestionViewPage> questionViewPageList=new List<QuestionViewPage>();
            QuestionViewPage questionViewPage = null;
            List<AnswerView> answerList = null;
            AnswerView answerView = null;
            int previousQuestionId = -1;
            int currentQuestionId = -1;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/QuestionView/"+id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var QuestionAnswerList = JsonConvert.DeserializeObject<List<QuestionViewPage>>(result);            
                    foreach(var item in QuestionAnswerList)
                    {
                        currentQuestionId=item.QuestionId;
                        if(previousQuestionId == -1 || previousQuestionId != currentQuestionId)
                        {
                            previousQuestionId=currentQuestionId;
                            questionViewPage=new QuestionViewPage();
                            questionViewPage.ArticleId = item.ArticleId;
                            questionViewPage.Question=item.Question;
                            questionViewPage.QuestionId = currentQuestionId;
                            answerList = new List<AnswerView>();
                            answerView = new AnswerView();
                            answerView.AnswerId = item.Answers[0].AnswerId;
                            answerView.Answer = item.Answers[0].Answer;
                            answerView.IsCorrect = item.Answers[0].IsCorrect;
                            answerList.Add(answerView);
                            questionViewPage.Answers = answerList;
                            questionViewPageList.Add(questionViewPage);
                           
                        }
                        else if (previousQuestionId == currentQuestionId)
                        {
                            // row with same questionid as previouse one
                             
                                answerView = new AnswerView();
                                answerView.AnswerId = item.Answers[0].AnswerId;
                                answerView.Answer = item.Answers[0].Answer;
                                answerView.IsCorrect = item.Answers[0].IsCorrect;
                                questionViewPage.Answers.Add(answerView);                           
                        }
                    }
                     
                }
            }
            return View(questionViewPageList);
        }

        [HttpPost]
        public async Task <IActionResult> Index(List<QuestionViewPage> submittedData)
        {
            var sessionUserId = HttpContext.Session.GetInt32("UserId");
            int userId = 0;
                      
            if (sessionUserId != null && sessionUserId > 0)
            {
                userId = (int)sessionUserId;
            }
            QuestionAnswerMap questionAnswerMap = null;
            List<QuestionAnswerMap> quesAnswerList=new List<QuestionAnswerMap>();
            foreach (var item in submittedData)
            {
                questionAnswerMap = new QuestionAnswerMap();
                questionAnswerMap.UserId = userId;
                questionAnswerMap.QuestionId = item.QuestionId;
                questionAnswerMap.AnswerId = item.SelectedAnswerId;
                questionAnswerMap.ArticleId = item.ArticleId;
                quesAnswerList.Add(questionAnswerMap);
            }

            if (quesAnswerList.Count>0)
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(BaseUrl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = await client.PostAsJsonAsync<List<QuestionAnswerMap>>("api/QuestionView/Index", quesAnswerList);
                        response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("CountResult", "Result", quesAnswerList[0]);
                        }
                        else
                        {                           
                            string errorContent = await response.Content.ReadAsStringAsync();
                            Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                            Console.WriteLine($"Error content: {errorContent}");
                            return View("Error");  
                        }
                    }
                }
                catch (HttpRequestException ex)
                {

                    Console.WriteLine($"API call failed: {ex.Message}");
                    return View("Error");
                }  

            }
            

            return View();
            //if (questionAnswerIds.Count > 0)
            //{
            //    QuestionPageData questionPageData = new QuestionPageData();
            //    // save the answers
            //    questionPageData.UserAnswer(userId, string.Join(",", questionAnswerIds));
            //    // set the next artical for the user
            //    questionPageData.NextArticle(questionId, userId);
            //    // return to result view
            //    return RedirectToAction("Index", "Result");
            //}
            //else
            //{
            //    return View(UserData);
            //}
        }

    }
}
