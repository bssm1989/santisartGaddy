using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace santisart_app.Models
{
    [MetadataType(typeof(DistrictsMetadata))]
    public partial class District
    {
    }
    public class DistrictsMetadata
    {
        [DisplayAttribute(Name ="ตำบล")]
        public string NameInThai { get; set; }
        [DisplayAttribute(Name = "ตำบล")]

        public string NameInEnglish { get; set; }
    }
}