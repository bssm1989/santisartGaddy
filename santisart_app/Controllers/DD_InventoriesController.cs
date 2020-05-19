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
    public class DD_InventoriesController : Controller
    {
        private santisartEntities3 db = new santisartEntities3();

        // GET: DD_Inventories
        public ActionResult Index()
        {
            return View(db.DD_Inventories.ToList());
        }

        // GET: DD_Inventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Inventories dD_Inventories = db.DD_Inventories.Find(id);
            if (dD_Inventories == null)
            {
                return HttpNotFound();
            }
            return View(dD_Inventories);
        }

        // GET: DD_Inventories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DD_Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "index,ProductCode,SKU,ProductName,Variant,Price")] DD_Inventories dD_Inventories)
        {
            if (ModelState.IsValid)
            {
                db.DD_Inventories.Add(dD_Inventories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dD_Inventories);
        }

        // GET: DD_Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Inventories dD_Inventories = db.DD_Inventories.Find(id);
            if (dD_Inventories == null)
            {
                return HttpNotFound();
            }
            return View(dD_Inventories);
        }

        // POST: DD_Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "index,ProductCode,SKU,ProductName,Variant,Price")] DD_Inventories dD_Inventories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dD_Inventories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dD_Inventories);
        }

        // GET: DD_Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Inventories dD_Inventories = db.DD_Inventories.Find(id);
            if (dD_Inventories == null)
            {
                return HttpNotFound();
            }
            return View(dD_Inventories);
        }

        // POST: DD_Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DD_Inventories dD_Inventories = db.DD_Inventories.Find(id);
            db.DD_Inventories.Remove(dD_Inventories);
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
