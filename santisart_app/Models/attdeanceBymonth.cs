using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace santisart_app.Models
{
    public class attdeanceBymonth
    {
        public List<attendance_day> attMonth{ get; set; }
        public List<EnrollStudentAttdance> attStudent { get; set; }
        public List<student2561> studentByClass{ get; set; }
        public List<SelectListItem> classList{ get; set; }
    }
}