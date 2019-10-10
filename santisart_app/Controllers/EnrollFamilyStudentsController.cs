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
    public class EnrollFamilyStudentsController : Controller
    {
        private santisartEntities3 db = new santisartEntities3();

        // GET: EnrollFamilyStudents
        public ActionResult Index()
        {
            var enrollFamilyStudents = db.EnrollFamilyStudents.Include(e => e.Student).Include(e => e.Family);
            return View(enrollFamilyStudents.ToList());
        }

        // GET: EnrollFamilyStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollFamilyStudent enrollFamilyStudent = db.EnrollFamilyStudents.Find(id);
            if (enrollFamilyStudent == null)
            {
                return HttpNotFound();
            }
            return View(enrollFamilyStudent);
        }

        // GET: EnrollFamilyStudents/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "Student_id", "Student_title");
            ViewBag.FamilyId = new SelectList(db.Families, "FamilyId", "Fam_Title");
            return View();
        }

        // POST: EnrollFamilyStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollFamStudentId,StudentId,FamilyId,TypeFamily,Timestamp,status,staftId")] EnrollFamilyStudent enrollFamilyStudent)
        {
            if (ModelState.IsValid)
            {
                db.EnrollFamilyStudents.Add(enrollFamilyStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "Student_id", "Student_title", enrollFamilyStudent.StudentId);
            ViewBag.FamilyId = new SelectList(db.Families, "FamilyId", "Fam_Title", enrollFamilyStudent.FamilyId);
            return View(enrollFamilyStudent);
        }

        // GET: EnrollFamilyStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollFamilyStudent enrollFamilyStudent = db.EnrollFamilyStudents.Find(id);
            if (enrollFamilyStudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "Student_id", "Student_title", enrollFamilyStudent.StudentId);
            ViewBag.FamilyId = new SelectList(db.Families, "FamilyId", "Fam_Title", enrollFamilyStudent.FamilyId);
            return View(enrollFamilyStudent);
        }

        // POST: EnrollFamilyStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "EnrollFamStudentId,StudentId,Student.Student_name,FamilyId,TypeFamily,Timestamp,status,staftId")] EnrollFamilyStudent enrollFamilyStudent)
        public ActionResult Edit(string surveyString)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(enrollFamilyStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.StudentId = new SelectList(db.Students, "Student_id", "Student_title", enrollFamilyStudent.StudentId);
            //ViewBag.FamilyId = new SelectList(db.Families, "FamilyId", "Fam_Title", enrollFamilyStudent.FamilyId);
            //return View(enrollFamilyStudent);
            return View();
        }

        // GET: EnrollFamilyStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollFamilyStudent enrollFamilyStudent = db.EnrollFamilyStudents.Find(id);
            if (enrollFamilyStudent == null)
            {
                return HttpNotFound();
            }
            return View(enrollFamilyStudent);
        }

        // POST: EnrollFamilyStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnrollFamilyStudent enrollFamilyStudent = db.EnrollFamilyStudents.Find(id);
            db.EnrollFamilyStudents.Remove(enrollFamilyStudent);
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
