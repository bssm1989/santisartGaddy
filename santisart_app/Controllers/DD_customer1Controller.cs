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
    public class DD_customer1Controller : Controller
    {
        private santisartEntities3 db = new santisartEntities3();

        // GET: DD_customer1
        public ActionResult Index()
        {
            return View(db.DD_customer.ToList());
        }

        // GET: DD_customer1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_customer dD_customer = db.DD_customer.Find(id);
            if (dD_customer == null)
            {
                return HttpNotFound();
            }
            return View(dD_customer);
        }

        // GET: DD_customer1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DD_customer1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Profile_Name,Recipient_s_name,Recipient_s_phone,Recipient_s_Email,Shipping_address,Shipping_city,Shipping_post_code,index")] DD_customer dD_customer)
        {
            if (ModelState.IsValid)
            {
                db.DD_customer.Add(dD_customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dD_customer);
        }

        // GET: DD_customer1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_customer dD_customer = db.DD_customer.Find(id);
            if (dD_customer == null)
            {
                return HttpNotFound();
            }
            return View(dD_customer);
        }

        // POST: DD_customer1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Profile_Name,Recipient_s_name,Recipient_s_phone,Recipient_s_Email,Shipping_address,Shipping_city,Shipping_post_code,index")] DD_customer dD_customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dD_customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dD_customer);
        }

        // GET: DD_customer1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_customer dD_customer = db.DD_customer.Find(id);
            if (dD_customer == null)
            {
                return HttpNotFound();
            }
            return View(dD_customer);
        }

        // POST: DD_customer1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DD_customer dD_customer = db.DD_customer.Find(id);
            db.DD_customer.Remove(dD_customer);
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
