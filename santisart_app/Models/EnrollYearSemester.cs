//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace santisart_app.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EnrollYearSemester
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EnrollYearSemester()
        {
            this.EnrollStudentCouses = new HashSet<EnrollStudentCouse>();
            this.EnrollEmpCouses = new HashSet<EnrollEmpCouse>();
        }
    
        public Nullable<int> YearEduId { get; set; }
        public Nullable<int> Semester { get; set; }
        public int EnrollYearSemesterId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    
        public virtual YearEdu YearEdu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnrollStudentCouse> EnrollStudentCouses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnrollEmpCouse> EnrollEmpCouses { get; set; }
    }
}
