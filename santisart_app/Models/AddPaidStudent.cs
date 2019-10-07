using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace santisart_app.Models
{
    public class AddPaidStudent
    {
        public int Student_id { get; set; }
        public int[] MonthIdAndPaid { get; set; }
        public int numPaid { get; set; }

    }
}
