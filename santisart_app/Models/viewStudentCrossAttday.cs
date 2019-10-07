using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace santisart_app.Models
{
    public class viewStudentCrossAttday
    {
        public int? Student_id { get; set; }
        public string Student_title { get; set; }
        public string Student_name { get; set; }
        public string Student_lname { get; set; }
        public Nullable<int> att_id { get; set; }
        public Nullable<int> Staff_id { get; set; }
        public Nullable<int> qira_id { get; set; }
        public Nullable<int> page { get; set; }
        public Nullable<int> attday_id { get; set; }
        public Nullable<System.DateTime> attday_date { get; set; }
        public Nullable<System.DateTime> Timestamp { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> staff_id { get; set; }
        public Nullable<int> year_index { get; set; }
        public string Comment { get; set; }
    }
}