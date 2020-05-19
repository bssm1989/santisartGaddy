using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using santisart_app.Models;

namespace santisart_app.Controllers
{
    public class DD_OrdersController : Controller
    {
        private santisartEntities3 db = new santisartEntities3();

        // GET: DD_Orders
        public ActionResult Index()
        {
            var dD_Orders = db.DD_Orders.Include(d => d.DD_customer).Where(x=>x.Order_status== "In progress");
            return View(dD_Orders.ToList());
        }

        // GET: DD_Orders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Orders dD_Orders = db.DD_Orders.Find(id);
            if (dD_Orders == null)
            {
                return HttpNotFound();
            }
            return View(dD_Orders);
        }

        // GET: DD_Orders/Create
        public ActionResult Create()
        {
            ViewBag.customerId = new SelectList(db.DD_customer, "index", "Profile_Name");
            return View();
        }

        // POST: DD_Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "index,Order_number,Sales_Channel,Created_Order_at,Checkout_at,Paid_at,Shipping_provider,Shipping_method,Shipping_fee,Payment_method,Variant_Name1,Variant_Name2,Bill_discount,Rabbit_LINE_Pay_Coupon,LINE_POINTS,Tracking_code,Tracking_URL,Payment_status,Shipping_status,Order_status,Canceled_at,Canceled_reason,Seller_notes,Buyer_notes,status,Order_number_Line,customerId")] DD_Orders dD_Orders)
        {
            if (ModelState.IsValid)
            {
                db.DD_Orders.Add(dD_Orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerId = new SelectList(db.DD_customer, "index", "Profile_Name", dD_Orders.customerId);
            return View(dD_Orders);
        }

        // GET: DD_Orders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Orders dD_Orders = db.DD_Orders.Find(id);
            if (dD_Orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerId = new SelectList(db.DD_customer, "index", "Profile_Name", dD_Orders.customerId);
            return View(dD_Orders);
        }

        // POST: DD_Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "index,Order_number,Sales_Channel,Created_Order_at,Checkout_at,Paid_at,Shipping_provider,Shipping_method,Shipping_fee,Payment_method,Variant_Name1,Variant_Name2,Bill_discount,Rabbit_LINE_Pay_Coupon,LINE_POINTS,Tracking_code,Tracking_URL,Payment_status,Shipping_status,Order_status,Canceled_at,Canceled_reason,Seller_notes,Buyer_notes,status,Order_number_Line,customerId")] DD_Orders dD_Orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dD_Orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerId = new SelectList(db.DD_customer, "index", "Profile_Name", dD_Orders.customerId);
            return View(dD_Orders);
        }

        // GET: DD_Orders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Orders dD_Orders = db.DD_Orders.Find(id);
            if (dD_Orders == null)
            {
                return HttpNotFound();
            }
            return View(dD_Orders);
        }

        // POST: DD_Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DD_Orders dD_Orders = db.DD_Orders.Find(id);
            db.DD_Orders.Remove(dD_Orders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
