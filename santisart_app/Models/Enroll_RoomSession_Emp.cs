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
    
    public partial class Enroll_RoomSession_Emp
    {
        public int EnrollRoomEmpId { get; set; }
        public Nullable<int> userid { get; set; }
        public Nullable<System.DateTime> timestamp { get; set; }
        public string staft { get; set; }
        public string status { get; set; }
        public string value { get; set; }
        public Nullable<int> RoomSessionId { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual RoomSession RoomSession { get; set; }
    }
}