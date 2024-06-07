using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccpSem3.Models.ModeView
{
    public class CadidatePassExam
    {
        public int id { get; set; }
        public Nullable<int> id_member { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public Nullable<int> id_vacancy { get; set; }
        public string title_vacancy { get; set; }
        public string concern_person { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> score { get; set; }
        public string answer_of_cadidate { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string submit_cadidate_cadidate { get; set; }
        public Nullable<System.DateTime> expire_date { get; set; }
    }
}