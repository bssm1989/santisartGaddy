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
    
    public partial class DD_Inventories
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DD_Inventories()
        {
            this.DD_Order_detail = new HashSet<DD_Order_detail>();
        }
    
        public string ProductCode { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string Variant { get; set; }
        public Nullable<int> Price { get; set; }
        public int index { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DD_Order_detail> DD_Order_detail { get; set; }
    }
}
