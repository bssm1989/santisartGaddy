using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace santisart_app.Models
{
    public class studentNow
    {
        public int Student_id { get; set; }
        public string Student_title { get; set; }
        public string Student_name { get; set; }
        public string Student_lname { get; set; }
        public DateTime? Student_birthday { get; set; }
        public string Student_idcard { get; set; }
        public int? Student_psis_id { get; set; }
        public string Student_status { get; set; }
        public int Class_id { get; set; }
        public int? Status { get; set; }
        public string Class_name_id { get; set; }
        public int? Teacher_id { get; set; }
        public int? Class_room { get; set; }
        public int? Class_year_index { get; set; }
    }
}
