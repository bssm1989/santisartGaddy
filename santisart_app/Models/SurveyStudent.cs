﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace santisart_app.Models
{
    public class SurveyStudent
    {
        public Student students{ get; set; }
        public List<EnrollFamilyStudent> enrollFamily{ get; set; }
        
        public enrolladdress address{ get; set; }
    }
}