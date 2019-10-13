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
    public class enrolladdresses1Controller : Controller
    {
        private santisartEntities3 db = new santisartEntities3();

        // GET: enrolladdresses1
        public ActionResult Index()
        {
            var enrolladdresses = db.enrolladdresses.Include(e => e.Subdistrict).Include(e => e.Student);
            return View(enrolladdresses.ToList());
        }

        // GET: enrolladdresses1/Details/5
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

        // GET: enrolladdresses1/Create
        public ActionResult Create()
        {
            ViewBag.Sub_id = new SelectList(db.Subdistricts, "Sub_id", "NameInThai");
            ViewBag.student_id = new SelectList(db.Students, "Student_id", "Student_title");
            return View();
        }

        // POST: enrolladdresses1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "number,Sub_id,tambol,amper,province,codeCity,status,codeAddress,nameVil,EmpId,timestamp,student_id,addressId,staff_id")] enrolladdress enrolladdress)
        {
            if (ModelState.IsValid)
            {
                db.enrolladdresses.Add(enrolladdress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sub_id = new SelectList(db.Subdistricts, "Sub_id", "NameInThai", enrolladdress.Sub_id);
            ViewBag.student_id = new SelectList(db.Students, "Student_id", "Student_title", enrolladdress.student_id);
            return View(enrolladdress);
        }

        // GET: enrolladdresses1/Edit/5
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
            ViewBag.Sub_id = new SelectList(db.Subdistricts, "Sub_id", "NameInThai", enrolladdress.Sub_id);
            ViewBag.student_id = new SelectList(db.Students, "Student_id", "Student_title", enrolladdress.student_id);
            return View(enrolladdress);
        }

        // POST: enrolladdresses1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "number,Sub_id,tambol,amper,province,codeCity,status,codeAddress,nameVil,EmpId,timestamp,student_id,addressId,staff_id")] enrolladdress enrolladdress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrolladdress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sub_id = new SelectList(db.Subdistricts, "Sub_id", "NameInThai", enrolladdress.Sub_id);
            ViewBag.student_id = new SelectList(db.Students, "Student_id", "Student_title", enrolladdress.student_id);
            return View(enrolladdress);
        }

        // GET: enrolladdresses1/Delete/5
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

        // POST: enrolladdresses1/Delete/5
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
