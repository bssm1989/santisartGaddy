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
    public class enrolladdressesController : Controller
    {
        private santisartEntities2 db = new santisartEntities2();

        // GET: enrolladdresses
        public ActionResult Index()
        {
            return View(db.enrolladdresses.ToList());
        }

        // GET: enrolladdresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enrolladdress enrolladdress = db.enrolladdresses.Find(id);
            if (enrolladdress == null)
            {
                return HttpNotFound();
            }
            return View(enrolladdress);
        }

        // GET: enrolladdresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: enrolladdresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "addressId,number,numVil,tambol,amper,province,codeCity,status,codeAddress,nameVil,EmpId,timestamp")] enrolladdress enrolladdress)
        {
            if (ModelState.IsValid)
            {
                db.enrolladdresses.Add(enrolladdress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enrolladdress);
        }

        // GET: enrolladdresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enrolladdress enrolladdress = db.enrolladdresses.Find(id);
            if (enrolladdress == null)
            {
                return HttpNotFound();
            }
            return View(enrolladdress);
        }

        // POST: enrolladdresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "addressId,number,numVil,tambol,amper,province,codeCity,status,codeAddress,nameVil,EmpId,timestamp")] enrolladdress enrolladdress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrolladdress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enrolladdress);
        }

        // GET: enrolladdresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enrolladdress enrolladdress = db.enrolladdresses.Find(id);
            if (enrolladdress == null)
            {
                return HttpNotFound();
            }
            return View(enrolladdress);
        }

        // POST: enrolladdresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            enrolladdress enrolladdress = db.enrolladdresses.Find(id);
            db.enrolladdresses.Remove(enrolladdress);
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
