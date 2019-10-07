using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using santisart_app.Models;
namespace santisart_app.Models
{
    public class ViewDetailPaide
    {
        public ViewStudentClass student { get; set; }
        public  Enroll_paid enrolpaide { get; set; }
        public Monthly monthly { get; set; }
    }
}
