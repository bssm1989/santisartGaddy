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
    
    public partial class EnrollStudentCouse
    {
        public Nullable<int> studentId { get; set; }
        public Nullable<int> EnrollCouseId { get; set; }
        public Nullable<double> Score1 { get; set; }
        public Nullable<double> Grade { get; set; }
        public Nullable<int> TeacerId { get; set; }
        public Nullable<System.DateTime> Timestamp { get; set; }
        public Nullable<int> YearEdu { get; set; }
        public Nullable<int> Staff { get; set; }
        public Nullable<int> Semester { get; set; }
        public Nullable<int> EnrollStudentClassId { get; set; }
        public Nullable<int> EnYearSemId { get; set; }
        public Nullable<int> EnEmpCouseId { get; set; }
        public Nullable<int> EnEmpCouseClassId { get; set; }
        public int EnrollStudentCouseId { get; set; }
        public Nullable<double> Score2 { get; set; }
        public Nullable<double> Score3 { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual Enroll_student_class Enroll_student_class { get; set; }
        public virtual EnrollEmpCouseClass EnrollEmpCouseClass { get; set; }
        public virtual EnrollYearSemester EnrollYearSemester { get; set; }
    }
}