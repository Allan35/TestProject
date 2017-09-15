//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SampleWebApplication.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class CeitStudent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CeitStudent()
        {
            this.CeitUsers = new HashSet<CeitUser>();
        }
        [Key]
        public string StudentID { get; set; }
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Nullable<int> CourseId { get; set; }
        public Nullable<int> YearLevelId { get; set; }
        public Nullable<int> QuestionId { get; set; }
        public string Answer { get; set; }
    
        public virtual CeitCourse CeitCourse { get; set; }
        public virtual CeitSecurityQuestion CeitSecurityQuestion { get; set; }
        public virtual CeitYearLevel CeitYearLevel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CeitUser> CeitUsers { get; set; }
    }
}
