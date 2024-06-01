using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccpSem3.Models.ModeView
{
    public class ExamineView
    {
        public int id { get; set; }
        public string title { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public QuestionOfExamineView examineView { get; set; }
        public QuestionView questionView { get; set; }
    }
}