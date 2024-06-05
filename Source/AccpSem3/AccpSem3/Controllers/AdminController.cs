
using AccpSem3.Models.Email;
using AccpSem3.Models.Encryption;
using AccpSem3.Models.Entities;
using AccpSem3.Models.ModeView;
using AccpSem3.Models.ModeView.ModelJoin;
using AccpSem3.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;

namespace AccpSem3.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminController : Controller
    {
        // GET: Admins
        //DAT DO
        public ActionResult Index()
        {
            try
            {
                var ls = VacanciesRepositories.Instance.GetAll();

                var chartData = new
                {
                    labels = ls.Select(v => v.name),
                    data = ls.Select(v => v.quantity_emp)
                };
                if (chartData != null)
                {
                    ViewBag.ChartData = chartData;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return View();
        }

        public ActionResult PageViewVancacies()
        {
            try
            {
                List<VacanciesView> ls = VacanciesRepositories.Instance.GetAll();
                ViewBag.Vanciest = ls;
            }
            catch (Exception e)
            {
                throw e;
            }
            return View();
        }

        public ActionResult PageViewDetails(int? id)
        {
            try
            {
                if (id != null)
                {
                    List<VacanciesView> ls = VacanciesRepositories.Instance.GetById(id);
                    if (ls != null)
                    {
                        ViewBag.VanciesDetail = ls;
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("PageViewVancacies", "Home");
                    }
                }
                return null;
            }
            catch (Exception e)
            {

            }
            return View();
        }
        public ActionResult PageAddDep()
        {
            try
            {
                DepartmentView model = new DepartmentView();
                return View(model);
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }
        [HttpPost]
        public ActionResult SubmitAddDep(DepartmentView model)
        {
            try
            {
                if (model !=null)
                {
                    DepartmentRepositories.Instance.InsertDep(model);
                    return RedirectToAction("PageViewVancies","Admin");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }
        public ActionResult PageUpdateDep(int? id)
        {
            try
            {
                if (id > 0)
                {
                    List<DepartmentView> ls = DepartmentRepositories.Instance.GetByIdDep(id);
                    foreach (DepartmentView item in ls)
                    {
                        ViewBag.DName = item.Dname;
                    }
                    return View();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }
        public ActionResult SubmitUptDep(DepartmentView model)
        {
            try
            {
                if (model != null)
                {
                    DepartmentRepositories.Instance.UpdateDep(model);
                    return RedirectToAction("PageViewVancies", "Admin");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }
        public ActionResult PageViewDetailDepart(int? id)
        {
            try
            {
                if (id != null)
                {
                    List<DepartmentView> ls = DepartmentRepositories.Instance.GetByIdDep(id);
                    if (ls != null)
                    {
                        ViewBag.DepDetail = ls;
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("PageViewDetails", "Home");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return View();
        }

        public ActionResult PageViewQuestionOfExam(int? id)
        {
            try
            {
                if (id != 0)
                {
                    List<QuesAndExam> ls = ExamineRepositories.Instance.GetAll_Ques_Ans(id);
                    if (ls != null)
                    {
                        ViewBag.DetailsQuesofExa = ls;
                    }
                    return View();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }

        [HttpGet]
        public ActionResult GetIdAnswer(int id)
        {
            try
            {
                //var dataQuestion1 = "";
                if (id != null)
                {
                    List<AnswerView> ls = AnswerRepositories.Instance.GetByAnswer(id);
                    if (ls != null)
                    {
                        var dataQuestion1 = ls.Select(ev => new
                        {
                            id = ev.id,
                            title = ev.title,
                            iscorrect = ev.is_correct,
                        }).ToList();

                        var combinedData = new
                        {
                            Data = dataQuestion1,

                        };
                        return Json(combinedData, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }

        public ActionResult PageViewDetailExa(int? id)
        {
            try
            {
                if (id != null)
                {
                    List<ExamineView> ls = ExamineRepositories.Instance.GetByIdExa(id);
                    if (ls != null)
                    {
                        ViewBag.ExaDetail = ls;
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("PageViewDetails", "Home");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return View();
        }

        public ActionResult PageAddVancacies()
        {
            try
            {
                VacanciesView vacanciesView = new VacanciesView();
                List<ExamineView> ls = ExamineRepositories.Instance.GetAll();
                List<DepartmentView> ls1 = DepartmentRepositories.Instance.GetAll();
                if (ls != null)
                {
                    ViewBag.Examine = ls;
                    ViewBag.Depart = ls1;
                }
                return View(vacanciesView);
            }
            catch (Exception e)
            {
                throw e;
            }
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubmitVancies(VacanciesView model)
        {
            try
            {
                var derciption = Request.Form["myData"].ToString();

                string id_exam = Request.Params["exam"];
                string id_dep = Request.Params["depart"];
                string jobnature = Request.Params["jobnature"];
                string featured = Request.Params["featured"];

                model.description = derciption;
                model.id_dep = int.Parse(id_dep);
                model.id_examination = int.Parse(id_exam);
                model.jobnature = jobnature;
                if (model != null)
                {
                    VacanciesRepositories.Instance.InsertVan(model);
                    return RedirectToAction("PageAddVancacies", "Admin");

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }
        public ActionResult PageUpdateVancies(int id)
        {
            try
            {
                if (id != null)
                {
                    VacanciesView view = new VacanciesView();
                    List<VacanciesView> ls = VacanciesRepositories.Instance.GetById(id);
                    if (ls != null)
                    {

                        foreach (VacanciesView item in ls)
                        {
                            ViewBag.decription = item.description;
                            ViewBag.quantity = item.quantity_emp;
                            ViewBag.salary1 = item.salary;
                            ViewBag.dateline1 = item.dateline;
                            ViewBag.id = item.id;

                        }
                    }
                    return View(view);
                }
                else
                {

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubmitEditVancies(VacanciesView model)
        {
            try
            {
                if (model != null)
                {
                    var derciption_t = Request.Form["myData"].ToString();
                    string jobnature = Request.Params["jobnature"];
                    string featured = Request.Params["featured"];
                    string id_test = Request.Params["id"];
                    model.description = derciption_t;
                    model.jobnature = jobnature;
                    model.featured = int.Parse(featured);
                    int id = int.Parse(id_test);
                    VacanciesRepositories.Instance.UpdateVan(id, model);
                }
                return RedirectToAction("PageViewVancacies", "Admin");
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }
        public ActionResult PageViewDetialCandi(int id)
        {
            try
            {
                if (id != null)
                {
                    List<CadidateView> ls = CandidateRepositories.Instance.GetByIdCadi(id);
                    if (ls != null)
                    {
                        ViewBag.CadiDetail = ls;
                    }
                    return View();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }

        public ActionResult PageDetailMember(int? id)
        {
            try
            {

                if (id != null)
                {
                    int a = Convert.ToInt32(id);
                    string id_string = a.ToString();

                    Session["id_mem"] = id_string;
                    List<MemberView> ls = MemberRepositories.Instance.GetById(id);
                    List<CadidateView> ls1 = CandidateRepositories.Instance.GetByIdMem(id);
                    if (ls != null)
                    {
                        ViewBag.MemberDetail = ls;
                        ViewBag.CandiDetail = ls1;
                    }
                }
                if (id == null)
                {
                    string s = (string)Session["id_mem"];
                    id = int.Parse(s);
                    List<MemberView> ls = MemberRepositories.Instance.GetById(id);
                    List<CadidateView> ls1 = CandidateRepositories.Instance.GetByIdMem(id);
                    if (ls != null)
                    {
                        ViewBag.MemberDetail = ls;
                        ViewBag.CandiDetail = ls1;
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return View();
        }

        [HttpPost]
        public ActionResult ProvideAccountCadi()
        {
            try
            {
                string user = Request.Params["username"];
                string pass = Request.Params["password"];
                string id_mem = Request.Params["id_mem"];
                if (!string.IsNullOrEmpty(string.Concat(user, pass, id_mem)))
                {
                    CadidateView model = new CadidateView();
                    model.id = int.Parse(id_mem);
                    model.username = user;
                    string pass_encrypt = PasswordHasher1.EncodePasswordToBase64(pass);
                    model.password = pass_encrypt;
                    int result = CandidateRepositories.Instance.CreateAccountCadi(model);
                    if (result == 1)
                    {
                        string fullname = Request.Params["fullname"];
                        string from = "dvo31666@gmail.com";
                        string recipient = "1318thang@gmail.com";
                        string subject = "Tôi gửi bạn tài khoản đăng nhập làm bài test";
                        string body = "<!DOCTYPE html><html lang='en'><head>  " +
                        "<meta charset='UTF-8'> " +
                         "<meta name='viewport' content='width=device-width, initial-scale=1.0'>  " +
                         "<title>Responsive Email Template</title></head>" +
                         "<link rel='preconnect' href=''><link rel='preconnect' href='' crossorigin><link href='0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap' rel='stylesheet'>" +
                         "<style>  @media screen and (max-width: 600px) {    .content {        width: 100% !important;        display: block !important;padding: 10px !important;    }.header, .body, .footer {padding: 20px !important;   } }</style>" +
                        "<body style='font-family: 'Poppins', Arial, sans-serif'>   " +
                        "<table width='100%' border='0' cellspacing='0' cellpadding='0'>  " +
                        "<tr><td align='center' style='padding: 20px;'>    " +
                        "<table class='content' width='600' border='0' cellspacing='0' cellpadding='0' style='border-collapse: collapse; border: 1px solid #cccccc;'>            " +
                        "<!-- Header --><tr><td class='header' style='background-color: #345C72; padding: 40px; text-align: center; color: white; font-size: 24px;'>           " +
                        "Responsive Email Template</td></tr>  " +
                        "<!-- Body -->                " +
                        "<tr><td class='body' style='padding: 40px; text-align: left; font-size: 16px; line-height: 1.6;'>   Hello '" + fullname + "'! <br> Welcome arrive company us. That is company ABC developmnent product Website in the word and Anyone also join project for project company us. </br> We need persons is expersive and skill active. Today We want test you of review scroce</td></tr><!-- Call to action Button --><tr><td style='padding: 0px 40px 0px 40px; text-align: center;'>" +
                        "<!-- CTA Button --><table cellspacing='0' cellpadding='0' style='margin: auto;'>                                <tr>                                  <td align='center' style='background-color: #345C72; padding: 10px 20px; border-radius: 5px;'><a href='https://www.yourwebsite.com' target='_blank' style='color: #ffffff; text-decoration: none; font-weight: bold;'>Book a Free Consulatation</a></td></tr></table></td></tr><tr><td class='body' style='padding: 40px; text-align: left; font-size: 16px; line-height: 1.6;'> We are provide account cadidate for Cadidate.</br><p> - <b>UserName: " + user + " </b>< </p> </br> <p> <b> - Password: " + pass + "</b></p></td></tr>  " +
                        " <!-- Footer --><tr><td class='footer' style='background-color: #333333; padding: 40px; text-align: center; color: white; font-size: 14px;'>Copyright &copy; 2024 | Your brand name</td></tr></table></td> </tr>  " +
                        "  </table>" +
                        "</body></html>";
                        EmailSender.Instance.SendEmail(from, recipient, subject, body);

                        return RedirectToAction("PageViewVancacies", "Admin");
                    }
                    else
                    {
                        Console.WriteLine("Edit Error data");
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }

        public ActionResult UpdatestatusMem(int id)
        {
            try
            {
                if (id != null)
                {
                    MemberRepositories.Instance.UpdateStatusMem(id);
                    return RedirectToAction("PageDetailMember", "Admin");
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }

        public ActionResult ActionRefused(int id)
        {
            try
            {
                if (id != null)
                {

                    int result = CandidateRepositories.Instance.RefusedCadi(id);
                    if (result > 0)
                    {
                        return RedirectToAction("PageDetailMember", "Admin");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }

        public ActionResult ViewQuantityCandidate(int id_van)
        {
            try
            {
                if (id_van != null)
                {

                    IEnumerable<ScoreResultCadi> ls = CandidateRepositories.Instance.GetQuantiyCandil(id_van);
                    if (ls != null)
                    {
                        ViewBag.QuantityCandidate = ls;
                    }
                }
            }
            catch (Exception e)
            {

            }
            return View();
        }

        public ActionResult ChangerStatusVan(int id, string num)
        {
            try
            {
                if (id != null && num != null)
                {
                    VacanciesRepositories.Instance.UpdateStatusVan(id, num);
                }
                return RedirectToAction("PageViewVancacies", "Admin");
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }

        // TAN DO
        //Question MANAGER
        public ActionResult QuestionMgr()
        {
            ViewBag.qt = QuestionRepository.Instance.GetQuestions();
            return View();
        }

        public ActionResult ChangeStatusQuestion(int id)
        {
            QuestionRepository.Instance.ChangeStatusQuestion(id);
            return RedirectToAction("QuestionMgr");
        }
        public ActionResult AddQuestion()
        {
            ViewBag.catques = QuestionRepository.Instance.GetCategoryOfQuestions();
            return View();
        }
        [HttpPost]
        public ActionResult SaveQuestion(FormCollection form)
        {
            Question question = new Question();
            question.title = form["title"];
            question.id_categoryofquestion = int.Parse(form["enhanced-select-idcat"]);
            question.status = 1;

            List<Answer> answerList = new List<Answer>();
            string[] lsas = form["titleas"].Split(',');

            string isCorrectValue = form["iscorrect"];
            int correctIndex;  // Biến lưu trữ index của đáp án đúng (nếu có)

            // Kiểm tra xem có giá trị iscorrect không (xử lý trường hợp iscorrect trống)
            if (!string.IsNullOrEmpty(isCorrectValue))
            {
                correctIndex = int.Parse(isCorrectValue);
            }
            else
            {
                correctIndex = -1;
            }

            for (int i = 0; i < lsas.Length; i++)
            {
                Answer answer = new Answer();
                answer.title = lsas[i];
                answer.is_correct = (i == correctIndex) ? 1 : 0;
                answerList.Add(answer);
            }

            QuestionRepository.Instance.AddQuestion(question, answerList.ToArray());

            return RedirectToAction("QuestionMgr");
        }

        [HttpPost]
        public ActionResult SaveEditQuestion(int id, FormCollection form)
        {
            try
            {
                // Fetch the question to edit from the repository
                var question = QuestionRepository.Instance.GetQuestionById(id);
                Question qt = new Question();
                qt.id = id;
                qt.title = question.title;
                qt.status = question.status;
                qt.id_categoryofquestion = question.id_categoryofquestion;
                qt.created_at = question.created_at;
                qt.updated_at = question.updated_at;

                if (question == null)
                {
                    // Handle case where the question to edit doesn't exist
                    return HttpNotFound(); // Or throw an exception
                }

                // Update question properties
                qt.title = form["title"];
                qt.id_categoryofquestion = int.Parse(form["enhanced-select-idcat"]);

                // Update existing answers or add new ones
                List<Answer> answerList = new List<Answer>();
                string[] lsas = form["titleas"].Split(',');
                string[] lsasid = form["idas"].Split(',');
                string isCorrectValue = form["iscorrect"];
                int correctIndex;

                // Check if iscorrect value exists
                if (!string.IsNullOrEmpty(isCorrectValue))
                {
                    correctIndex = int.Parse(isCorrectValue);
                }
                else
                {
                    correctIndex = -1;
                }
                // Clear existing answers (assuming you want to replace all answers)
                //question.Clear(); // Adjust based on your logic
                for (int i = 0; i < lsas.Length; i++)
                {
                    Answer answer = new Answer();
                    answer.id = int.Parse(lsasid[i]);
                    answer.title = lsas[i];
                    answer.is_correct = (i == correctIndex) ? 1 : 0;
                    answerList.Add(answer);
                }

                // Save changes using the repository
                QuestionRepository.Instance.UpdateQuestion(qt, answerList.ToArray());

                return RedirectToAction("QuestionMgr"); // Or your desired action after successful edit
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., logging)
                return null; // Or handle error differently
            }
        }

        public ActionResult ViewDtQuestion(int id)
        {
            ViewBag.catques = QuestionRepository.Instance.GetCategoryOfQuestions();
            ViewBag.qt = QuestionRepository.Instance.GetQuestionById(id);
            ViewBag.answer = QuestionRepository.Instance.GetAnswerByQuestion(id);
            return View();
        }
        //Examiniation Manager
        public ActionResult ExaminiationMgr()
        {
            ViewBag.listExam = QuestionRepository.Instance.GetExaminations();
            return View();
        }
        public ActionResult AddExaminiation()
        {
            ViewBag.qtgk = QuestionRepository.Instance.GetQuestionByCategory(1);
            ViewBag.qtm = QuestionRepository.Instance.GetQuestionByCategory(2);
            ViewBag.qtct = QuestionRepository.Instance.GetQuestionByCategory(3);
            return View();
        }

        [HttpPost]
        public ActionResult SaveExaminiation(FormCollection form)
        {
            Examination examination = new Examination();
            examination.title = form["title"];

            List<QuestionOfExamination> questionList = new List<QuestionOfExamination>();
            string[] lsqt = form["questionidlist"].Split(',');

            for (int i = 0; i < lsqt.Length; i++)
            {
                QuestionOfExamination questionOfExamination = new QuestionOfExamination();
                if (int.Parse(lsqt[i]) != 0)
                {
                    questionOfExamination.id_question = int.Parse(lsqt[i]);
                    questionList.Add(questionOfExamination);
                }
            }
            QuestionRepository.Instance.AddQuestionOfExaminiation(examination, questionList.ToArray());

            return RedirectToAction("ExaminiationMgr");
        }

        [HttpPost]
        public ActionResult SaveEditExaminiation(int idex, FormCollection form)
        {
            var examiniation = QuestionRepository.Instance.GetExaminationById(idex);
            Examination examination = new Examination();
            examination.title = form["title"];

            return RedirectToAction("ExaminiationMgr");
        }

        public ActionResult ViewDtExaminiation(int id)
        {
            var ex = QuestionRepository.Instance.GetExaminationById(id);
            ViewBag.examiniation = ex;
            var listqt = QuestionRepository.Instance.GetQuestionOfExaminiation(ex.id);
            ICollection<QuestionView> listqtgk = new List<QuestionView>();
            ICollection<QuestionView> listqtm = new List<QuestionView>();
            ICollection<QuestionView> listqtct = new List<QuestionView>();
            foreach (var item in listqt)
            {
                if (item.id_categoryofquestion == 1)
                {
                    listqtgk.Add(item);                    
                }
                else if (item.id_categoryofquestion == 2)
                {
                    listqtm.Add(item);                    
                }
                else if (item.id_categoryofquestion == 3)
                {
                    listqtct.Add(item);
                }
            }
            ViewBag.listqtgk = listqtgk;
            ViewBag.listqtm = listqtm;
            ViewBag.listqtct = listqtct;

            ViewBag.qtgk = QuestionRepository.Instance.GetQuestionByCategory(1);
            ViewBag.qtm = QuestionRepository.Instance.GetQuestionByCategory(2);
            ViewBag.qtct = QuestionRepository.Instance.GetQuestionByCategory(3);
            return View();
        }

        
    }
}