using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace santisart_app.Dto
{
    public class OrderDetailDto
    {
        public Nullable<int> Order_number { get; set; }
        public Nullable<int> Selling_Price { get; set; }
        public Nullable<int> Full_Price { get; set; }
        public string Product_code { get; set; }
        public Nullable<int> SKU_code { get; set; }
        public string Barcode { get; set; }
        public string Product_Name { get; set; }
        public string status_order { get; set; }
        public Nullable<int> Item_quantity { get; set; }
        public int index { get; set; }

        public virtual InventoriesDto InventoriesDto { get; set; }
        public virtual OrdersDto OrdersDto { get; set; }
    }
}