using AccpSem3.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccpSem3.Models.ModeView.ModelJoin
{
    public class QuesAndExam
    {
        public Examination examination { get; set; }
        public QuestionOfExamination question_exam { get; set; }
        public Question question { get; set; }
    }
}