using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccpSem3.Models.ModeView.ModelJoin
{
    public class QuestionJoinView
    {
        public QuestionOfExamineView QuestionOfExamineView { get; set; }

        public QuestionView questionView { get; set; }
    }
}