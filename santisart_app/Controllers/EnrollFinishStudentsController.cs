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
    public class EnrollFinishStudentsController : Controller
    {
        private santisartEntities3 db = new santisartEntities3();

        // GET: EnrollFinishStudents
        public ActionResult Index()
        {
            var enrollFinishStudent = db.EnrollFinishStudents.Include(e => e.Student).Include(e => e.FinishType).ToList();
            return View(enrollFinishStudent);
        }
        public ActionResult Index2()
        {
            var enrollFinishStudent = db.EnrollFinishStudents.Include(e => e.Student).Include(e => e.FinishType).ToList();
            return View(enrollFinishStudent);
        }

        // GET: EnrollFinishStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollFinishStudent enrollFinishStudent = db.EnrollFinishStudents.Find(id);
            if (enrollFinishStudent == null)
            {
                return HttpNotFound();
            }
            return View(enrollFinishStudent);
        }

        // GET: EnrollFinishStudents/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "Student_id", "Student_title");
            ViewBag.FinishTypeId = new SelectList(db.FinishTypes, "FinishFormID", "FormName");
            return View();
        }

        // POST: EnrollFinishStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,FinishTypeId,Status,TimeStam,Staff,FinishId,FinishCouse")] EnrollFinishStudent enrollFinishStudent)
        {
            if (ModelState.IsValid)
            {
                db.EnrollFinishStudents.Add(enrollFinishStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "Student_id", "Student_title", enrollFinishStudent.StudentId);
            ViewBag.FinishTypeId = new SelectList(db.FinishTypes, "FinishFormID", "FormName", enrollFinishStudent.FinishTypeId);
            return View(enrollFinishStudent);
        }

        // GET: EnrollFinishStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollFinishStudent enrollFinishStudent = db.EnrollFinishStudents.Find(id);
            if (enrollFinishStudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "Student_id", "Student_title", enrollFinishStudent.StudentId);
            ViewBag.FinishTypeId = new SelectList(db.FinishTypes, "FinishFormID", "FormName", enrollFinishStudent.FinishTypeId);
            return View(enrollFinishStudent);
        }

        // POST: EnrollFinishStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,FinishTypeId,Status,TimeStam,Staff,FinishId,FinishCouse")] EnrollFinishStudent enrollFinishStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollFinishStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Student_id", "Student_title", enrollFinishStudent.StudentId);
            ViewBag.FinishTypeId = new SelectList(db.FinishTypes, "FinishFormID", "FormName", enrollFinishStudent.FinishTypeId);
            return View(enrollFinishStudent);
        }

        // GET: EnrollFinishStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollFinishStudent enrollFinishStudent = db.EnrollFinishStudents.Find(id);
            if (enrollFinishStudent == null)
            {
                return HttpNotFound();
            }
            return View(enrollFinishStudent);
        }

        // POST: EnrollFinishStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnrollFinishStudent enrollFinishStudent = db.EnrollFinishStudents.Find(id);
            db.EnrollFinishStudents.Remove(enrollFinishStudent);
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
