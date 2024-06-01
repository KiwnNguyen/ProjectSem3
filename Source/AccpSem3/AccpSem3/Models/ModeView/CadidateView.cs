﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccpSem3.Models.ModeView
{
    public class CadidateView
    {
        public int id { get; set; }
        public Nullable<int> id_member { get; set; }
        public Nullable<int> id_vacancy { get; set; }
        public string concern_person { get; set; }
        public Nullable<int> status { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Nullable<int> score { get; set; }
        public string answer_of_cadidate { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string submit_cadidate_cadidate { get; set; }
    }
}