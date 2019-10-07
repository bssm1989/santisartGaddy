using santisart_app.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace santisart_app.Models
{
    public class ViewPrintInvoise
    {
    
        public List<studentNow> detailStudent { get; set; }
        public List<List<viewPaid>> studentInvoise { get; set; }
    }
}
