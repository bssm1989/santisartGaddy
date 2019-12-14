using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace santisart_app.Models
{
    public class indexByIdEnrollCouse
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
        public Nullable<int> ClassId { get; set; }
        public string CouseTxtId { get; set; }
        public string CourseName { get; set; }
        
    }
}