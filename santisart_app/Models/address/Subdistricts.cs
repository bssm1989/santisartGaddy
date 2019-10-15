using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace santisart_app.Models
{
    [MetadataType(typeof(SubdistrictsMetadata))]
    public partial class Subdistrict
    {
    }
    public class SubdistrictsMetadata
    {
        [DisplayAttribute(Name ="ตำบล")]
        public string NameInThai { get; set; }
        [DisplayAttribute(Name = "ตำบล")]

        public string NameInEnglish { get; set; }
    }
}