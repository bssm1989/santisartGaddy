//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace santisart_app.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class enrolladdress
    {
        public Nullable<int> number { get; set; }
        public Nullable<int> sub_id { get; set; }
        public string tambol { get; set; }
        public string amper { get; set; }
        public string province { get; set; }
        public string codeCity { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> codeAddress { get; set; }
        public string nameVil { get; set; }
        public Nullable<int> EmpId { get; set; }
        public Nullable<System.DateTime> timestamp { get; set; }
        public Nullable<int> student_id { get; set; }
        public int addressId { get; set; }
    
        public virtual Subdistrict Subdistrict { get; set; }
        public virtual Student Student { get; set; }
    }
}
