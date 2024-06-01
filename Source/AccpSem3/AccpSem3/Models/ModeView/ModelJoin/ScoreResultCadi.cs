using AccpSem3.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccpSem3.Models.ModeView.ModelJoin
{
    public class ScoreResultCadi
    {
        public Member member { get; set; }
        public Cadidate cadidate { get; set; }
        public Vacancy vacancy { get; set; }
        public Examination examination { get; set; }
        public QuestionOfExamination ofExamination { get; set; }
        public Question question { get; set; }
        public Answer answer { get; set; }
    }
}