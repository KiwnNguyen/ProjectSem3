//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccpSem3.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class QuestionOfExamination
    {
        public int id { get; set; }
        public Nullable<int> id_question { get; set; }
        public Nullable<int> id_examination { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    
        public virtual Examination Examination { get; set; }
        public virtual Question Question { get; set; }
    }
}
