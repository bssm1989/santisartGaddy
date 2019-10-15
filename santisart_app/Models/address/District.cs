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
        [DisplayAttribute(Name ="อำเภอ")]
        public string NameInThai { get; set; }
        [DisplayAttribute(Name = "ตำบล")]

        public string NameInEnglish { get; set; }
    }
    [MetadataType(typeof(ProvinceMetadata))]
    public partial class Province
    {

    }
    public class ProvinceMetadata
    {
        [DisplayAttribute(Name = "จังหวัด")]
        public string NameInThai { get; set; }
        [DisplayAttribute(Name = "ตำบล")]

        public string NameInEnglish { get; set; }
    }
    [MetadataType(typeof(enrolladdressMetadata))]
    public partial class enrolladdress
    {

    }

    public class enrolladdressMetadata
    {
        [DisplayAttribute(Name = "ชื่อหมู่บ้าน")]
        public string nameVil { get; set; }
        [DisplayAttribute(Name = "บ้านเลขที่")]
        public int  numberHome { get; set; }

        [DisplayAttribute(Name = "ชอย")]
        public string Soi { get; set; }

        [DisplayAttribute(Name = "ถนน")]
        public string Road { get; set; }

    }
    [MetadataType(typeof(FamlyaddressMetadata))]
    public partial class Family{}
    public class FamlyaddressMetadata
    {
        [DisplayAttribute(Name = "คำนำหน้่า")]
        public string Fam_Title { get; set; }
        [DisplayAttribute(Name = "ชื่อ")]
        public string Fam_Name { get; set; }
        [DisplayAttribute(Name = "นามสกุล")]
        public string Fam_Lname { get; set; }
        [DisplayAttribute(Name = "อาชีพ")]
        public string Career { get; set; }
        [DisplayAttribute(Name = "การศึกษา")]
        public string Education { get; set; }
        [DisplayAttribute(Name = "เพศ")]
        public string Gender { get; set; }
        [DisplayAttribute(Name = "รายได้")]
        public Nullable<int> Income { get; set; }
        [DisplayAttribute(Name = "วัน/เดือน/ปี เกิด")]
        public Nullable<System.DateTime> birthday { get; set; }
        [DisplayAttribute(Name = "เบอร์โทรติดต่อ")]

        public string Tel { get; set; }

    }
    [MetadataType(typeof(StudentMetadata))]
    public partial class Student { }
    public class StudentMetadata
    {
        [DisplayAttribute(Name = "คำนำหน้่า")]
        public string Student_title { get; set; }

        [DisplayAttribute(Name = "ชื่อ")]
        public string Student_name { get; set; }

        [DisplayAttribute(Name = "นามสกุล")]
        public string Student_lname { get; set; }
        [DisplayAttribute(Name = "เพศ")]
        public string Studnet_Gender { get; set; }
        [DisplayAttribute(Name = "วัน/เดือน/ปี เกิด")]
        public Nullable<System.DateTime> Student_birthday { get; set; }
        [DisplayAttribute(Name = "เบอร์โทรติดต่อ")]

        public string Student_tel { get; set; }



    }
}