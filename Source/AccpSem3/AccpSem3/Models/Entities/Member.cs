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
    
    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            this.Cadidates = new HashSet<Cadidate>();
        }
    
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public string cv { get; set; }
        public string education_details { get; set; }
        public string personal_details { get; set; }
        public string work_experience { get; set; }
        public string phone { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cadidate> Cadidates { get; set; }
    }
}
