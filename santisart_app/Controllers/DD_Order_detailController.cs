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
    public class DD_Order_detailController : Controller
    {
        private santisartEntities3 db = new santisartEntities3();

        // GET: DD_Order_detail
        public ActionResult Index()
        {
            var dD_Order_detail = db.DD_Order_detail.Include(d => d.DD_Inventories).Include(d => d.DD_Orders);
            return View(dD_Order_detail.ToList());
        }

        // GET: DD_Order_detail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Order_detail dD_Order_detail = db.DD_Order_detail.Find(id);
            if (dD_Order_detail == null)
            {
                return HttpNotFound();
            }
            return View(dD_Order_detail);
        }

        // GET: DD_Order_detail/Create
        public ActionResult Create()
        {
            ViewBag.SKU_code = new SelectList(db.DD_Inventories, "index", "ProductCode");
            ViewBag.Order_number = new SelectList(db.DD_Orders, "index", "Order_number");
            return View();
        }

        // POST: DD_Order_detail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "index,Order_number,Selling_Price,Full_Price,Product_code,SKU_code,Barcode,Product_Name,status_order,Item_quantity")] DD_Order_detail dD_Order_detail)
        {
            if (ModelState.IsValid)
            {
                db.DD_Order_detail.Add(dD_Order_detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SKU_code = new SelectList(db.DD_Inventories, "index", "ProductCode", dD_Order_detail.SKU_code);
            ViewBag.Order_number = new SelectList(db.DD_Orders, "index", "Order_number", dD_Order_detail.Order_number);
            return View(dD_Order_detail);
        }

        // GET: DD_Order_detail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Order_detail dD_Order_detail = db.DD_Order_detail.Find(id);
            if (dD_Order_detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.SKU_code = new SelectList(db.DD_Inventories, "index", "ProductCode", dD_Order_detail.SKU_code);
            ViewBag.Order_number = new SelectList(db.DD_Orders, "index", "Order_number", dD_Order_detail.Order_number);
            return View(dD_Order_detail);
        }

        // POST: DD_Order_detail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "index,Order_number,Selling_Price,Full_Price,Product_code,SKU_code,Barcode,Product_Name,status_order,Item_quantity")] DD_Order_detail dD_Order_detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dD_Order_detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SKU_code = new SelectList(db.DD_Inventories, "index", "ProductCode", dD_Order_detail.SKU_code);
            ViewBag.Order_number = new SelectList(db.DD_Orders, "index", "Order_number", dD_Order_detail.Order_number);
            return View(dD_Order_detail);
        }

        // GET: DD_Order_detail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Order_detail dD_Order_detail = db.DD_Order_detail.Find(id);
            if (dD_Order_detail == null)
            {
                return HttpNotFound();
            }
            return View(dD_Order_detail);
        }

        // POST: DD_Order_detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DD_Order_detail dD_Order_detail = db.DD_Order_detail.Find(id);
            db.DD_Order_detail.Remove(dD_Order_detail);
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
