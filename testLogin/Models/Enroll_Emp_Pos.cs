//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace testLogin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Enroll_Emp_Pos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Enroll_Emp_Pos()
        {
            this.EnrollStudentCouse = new HashSet<EnrollStudentCouse>();
        }
    
        public Nullable<int> Employee_id { get; set; }
        public Nullable<int> Position_id { get; set; }
        public Nullable<int> EnrEmpPosStatus { get; set; }
        public Nullable<System.DateTime> EnrEmpPosTimestamp { get; set; }
        public int EnrEmpPosId { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Position Position { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnrollStudentCouse> EnrollStudentCouse { get; set; }
    }
}