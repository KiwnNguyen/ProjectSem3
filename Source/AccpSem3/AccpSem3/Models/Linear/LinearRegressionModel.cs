using AccpSem3.Models.ModeView.ModelJoin;
using AccpSem3.Models.ModeView;
using AccpSem3.Models.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AccpSem3.Models.Linear
{
    public class LinearRegressionModel
    {
        public int Train(List<string> answers)
        {
            try
            {
                int score = 0;
                int score1 = 0;
                int score2 = 0;
                int totalScore = 0;
               
                Dictionary<string, int> correctAnswers = new Dictionary<string, int>();

                foreach (string listanswers in answers)
                {
                    //string word = new string(listanswers.Where(c => char.IsLetter(c) && c != ' ').ToArray());
                    string[] parts = listanswers.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    // Lấy phần tử đầu tiên (ký tự + và a)
                    // Lấy phần tử thứ hai (số 17)
                    int kitu = parts.Length - 1;
                    string word = string.Join(" ", parts.Take(kitu));
                    string number = parts[parts.Length - 1];
                    if (int.TryParse(number, out int id))
                    {
                        // Chuyển đổi chuỗi "number" thành số nguyên
                        Console.WriteLine("ID: " + id);
                    }
                    else
                    {
                        Console.WriteLine("Chuỗi 'number' không phải là số hợp lệ.");
                    }
                    List<QuestionJoin> questionJoins1 = AnswerRepositories.Instance.GetQuestionI(id);
                    List<QuestionJoin> questionJoins2 = AnswerRepositories.Instance.GetQuestionII(id);
                    List<QuestionJoin> questionJoins3 = AnswerRepositories.Instance.GetQuestionIII(id);
                    if (questionJoins1 != null)
                    {
                        foreach (QuestionJoin item1 in questionJoins1)
                        {
                            if (item1.answer.title.Equals(word))
                            {
                                score++;
                            }
                        }
                    }
                    if (questionJoins2 != null)
                    {
                        foreach (QuestionJoin item2 in questionJoins2)
                        {
                            if (item2.answer.title.Equals(word))
                            {
                                score1++;
                            }
                        }
                    }
                    if (questionJoins3 != null)
                    {
                        foreach (QuestionJoin item3 in questionJoins3)
                        {
                            if (item3.answer.title.Equals(word))
                            {

                                score2++;
                            }
                        }
                    }
                }
                totalScore = score + score1 + score2;
                HttpContext.Current.Session["ScorePhanI"] = score;
                HttpContext.Current.Session["ScorePhanII"] = score1;
                HttpContext.Current.Session["ScorePhanIII"] = score2;
                string account = HttpContext.Current.Session["AccountNameCadidate"] as string;
                IEnumerable<ScoreResultCadi> values = AnswerRepositories.Instance.GetResultCadi(account);
                string questions = null;
                string answersJson = "[";
                foreach (ScoreResultCadi value in values)
                {
                    string question = value.question.title;
                    string answer = value.answer.title;
                    if (questions == null)
                    {
                        questions = question;
                    }
                    // Thêm giá trị answer vào chuỗi JSON
                    answersJson += "{";
                    answersJson += "\"question\": \"" + question + "\",";
                    answersJson += "\"answer\": \"" + answer + "\"";
                    answersJson += "},";
                }
                // Xóa dấu "," cuối cùng trong chuỗi JSON
                if (answersJson.EndsWith(","))
                {
                    answersJson = answersJson.Remove(answersJson.Length - 1);
                }
                answersJson += "]";
                // submit Answer of Candidate
                List<Dictionary<string, string>> answerList = new List<Dictionary<string, string>>();
                foreach (string listanswers in answers)
                {
                    string[] parts = listanswers.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    // Lấy phần tử thứ hai (số 17)
                    int kitu = parts.Length - 1;
                    string word = string.Join(" ", parts.Take(kitu));

                    Dictionary<string, string> answerDict = new Dictionary<string, string>();
                    answerDict.Add("answer", word);
                    answerList.Add(answerDict);
                }
                string answerJsonOfCandidate = JsonConvert.SerializeObject(answerList);
                if (values != null && answerJsonOfCandidate != null)
                {
                    List<CadidateView> caivi = CandidateRepositories.Instance.GetById(account);
                    int id = 0;
                    foreach (CadidateView te in caivi)
                    {
                        id = te.id;
                    }
                    CandidateRepositories.Instance.UpdateCadi(id, totalScore, answersJson, answerJsonOfCandidate);
                }
                HttpContext.Current.Session["ScoreCadi"] = totalScore;
                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
            return  0;
        }
    }
}