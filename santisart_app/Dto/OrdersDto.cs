using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace santisart_app.Dto
{
    public class OrdersDto
    {
        //public OrdersDto()
        //{
        //    this.DD_order_detail = new HashSet<OrderDetailDto>();
        //}
        public string Order_number { get; set; }
        public string Sales_Channel { get; set; }
        public Nullable<System.DateTime> Created_Order_at { get; set; }
        public Nullable<System.DateTime> Checkout_at { get; set; }
        public Nullable<System.DateTime> Paid_at { get; set; }
        public string Shipping_provider { get; set; }
        public string Shipping_method { get; set; }
        public string Shipping_fee { get; set; }
        public string Payment_method { get; set; }
        public string Variant_Name1 { get; set; }
        public string Variant_Name2 { get; set; }
        public string Bill_discount { get; set; }
        public string Rabbit_LINE_Pay_Coupon { get; set; }
        public string LINE_POINTS { get; set; }
        public string Tracking_code { get; set; }
        public string Tracking_URL { get; set; }
        public string Payment_status { get; set; }
        public string Shipping_status { get; set; }
        public string Order_status { get; set; }
        public Nullable<System.DateTime> Canceled_at { get; set; }
        public string Canceled_reason { get; set; }
        public string Seller_notes { get; set; } 
        public string Buyer_notes { get; set; }
        public string status { get; set; }
        public string Order_number_Line { get; set; }
        public int customerId { get; set; }
        public int index { get; set; }
        public CustomerDto DD_customer { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public  ICollection<OrderDetailDto> DD_order_detail { get; set; }
    }
}