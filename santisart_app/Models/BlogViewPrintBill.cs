﻿using santisart_app.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace santisart_app.Models
{
    public class BlogViewPrintBill
    {
        public studentNow detailStudent { get; set; }
        public List<viewdetail> studentPaid { get; set; }
    }
}
