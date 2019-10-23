using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace santisart_app.Models
{
    public class SurveyStudent
    {
        public Student students{ get; set; }
        public List<EnrollFamilyStudent> enrollFamily{ get; set; }
        
        public enrolladdress address{ get; set; }
        [DisplayAttribute(Name = "จังหวัด")]
        public int Provices { get; set; }
        [DisplayAttribute(Name = "อำเภอ")]

        public int Districts { get; set; }
        [DisplayAttribute(Name = "ตำบล")]
        public int Sub_id { get; set; }
        public int SelectedId { get; set; }
        public SelectList PosFamDropdown { get; set; }
        public string checkFa { get; set; }
        public string checkMo { get; set; }
    }
}