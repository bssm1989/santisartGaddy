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
    public class EnrollStudentCousesController : Controller
    {
        private santisartEntities2 db = new santisartEntities2();

        // GET: EnrollStudentCouses
        public ActionResult IndexById(int? id)
        {
            var enrollStudentCouse = db.EnrollStudentCouse
                                        .Where(x => x.studentId == id)
                                        .Include(e => e.Enroll_student_class);
            ViewBag.studentCouse = enrollStudentCouse.ToList();
            return View(enrollStudentCouse.ToList());
        }

       public ActionResult EditListScoreByCouse(int? id)
        {

            var enrollStudentCouse = db.EnrollStudentCouse
                                        .Where(x => x.EnEmpCouseClassId == id)
                                        .Include(e => e.Enroll_student_class)
                                        .Where(x => x.EnEmpCouseClassId == id);
            //ViewBag.studentCouse = enrollStudentCouse.ToList();
            return View(enrollStudentCouse.ToList());
        }
        [HttpPost]
        public ActionResult EditListScoreByCouse(List<EnrollStudentCouse> EnrollStudentCouse)
        {
            foreach (var item in EnrollStudentCouse)
            {
                EnrollStudentCouse EditListScoreByCouse = db.EnrollStudentCouse.Find(item.EnrollStudentCouseId);
                EditListScoreByCouse.Score1 = item.Score1;
                EditListScoreByCouse.Score2 = item.Score2;
                EditListScoreByCouse.Score3 = item.Score3;
                EditListScoreByCouse.Grade = item.Grade;
                EditListScoreByCouse.Timestamp = System.DateTime.Now;

            }
            db.SaveChanges();
            return RedirectToAction("IndexByIdEmpcouseClass", new { id = EnrollStudentCouse.First().EnEmpCouseClassId });
            //return RedirectToAction("IndexByIdEmpcouseClass",new { id = 26});
        }
        public ActionResult IndexByIdEmpcouseClass(int? id)
        {
            var getClass = db.EnrollEmpCouseClass.Find(id).EnClassId;
            var getListStudents = db.Enroll_student_class.Where(x => x.EnrollClass.EnrollClass_id == getClass);
            if (db.EnrollStudentCouse.Where(x => x.EnEmpCouseClassId == id).Count() == 0)
            {
                foreach (var student in getListStudents)
                {
                    db.EnrollStudentCouse.Add(new EnrollStudentCouse
                    {
                        EnrollStudentClassId = student.Enrol_stu_class_id,
                        EnEmpCouseClassId = id,
                        Timestamp = System.DateTime.Now
                    });
                }
db.SaveChanges();
            }

            var enrollStudentCouse = db.EnrollStudentCouse
                                        .Where(x => x.EnEmpCouseClassId == id)
                                        .Include(e => e.Enroll_student_class)
                                        .Where(x => x.EnEmpCouseClassId == id);
            //ViewBag.studentCouse = enrollStudentCouse.ToList();
            return View(enrollStudentCouse.ToList());
        }
        public ActionResult Index()
        {
            var enrollStudentCouse = db.EnrollStudentCouse
                                        .Include(e => e.Enroll_student_class);
            return View(enrollStudentCouse.ToList());
        }

        // GET: EnrollStudentCouses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollStudentCouse enrollStudentCouse = db.EnrollStudentCouse.Find(id);
            if (enrollStudentCouse == null)
            {
                return HttpNotFound();
            }
            return View(enrollStudentCouse);
        }

        // GET: EnrollStudentCouses/Create
        public ActionResult Create()
        {
            ViewBag.TeacerId = new SelectList(db.Enroll_Emp_Po, "EnrEmpPosId", "EnrEmpPosId");
            ViewBag.EnrollCouseId = new SelectList(db.EnrollCouse, "EnrollCouseID", "CouseTxtId");
            ViewBag.studentId = new SelectList(db.Students, "Student_id", "Student_title");
            return View();
        }

        // POST: EnrollStudentCouses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollStudentCouseId,studentId,EnrollCouseId,Score,Grade,TeacerId,Timestamp,YearEdu,Staff,Semester")] EnrollStudentCouse enrollStudentCouse)
        {
            if (ModelState.IsValid)
            {
                db.EnrollStudentCouse.Add(enrollStudentCouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeacerId = new SelectList(db.Enroll_Emp_Po, "EnrEmpPosId", "EnrEmpPosId", enrollStudentCouse.TeacerId);
            ViewBag.EnrollCouseId = new SelectList(db.EnrollCouse, "EnrollCouseID", "CouseTxtId", enrollStudentCouse.EnrollCouseId);
            ViewBag.studentId = new SelectList(db.Students, "Student_id", "Student_title", enrollStudentCouse.studentId);
            return View(enrollStudentCouse);
        }

        // GET: EnrollStudentCouses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollStudentCouse enrollStudentCouse = db.EnrollStudentCouse.Find(id);
            if (enrollStudentCouse == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeacerId = new SelectList(db.Enroll_Emp_Po, "EnrEmpPosId", "EnrEmpPosId", enrollStudentCouse.TeacerId);
            ViewBag.EnrollCouseId = new SelectList(db.EnrollCouse, "EnrollCouseID", "CouseTxtId", enrollStudentCouse.EnrollCouseId);
            ViewBag.studentId = new SelectList(db.Students, "Student_id", "Student_title", enrollStudentCouse.studentId);
            return View(enrollStudentCouse);
        }

        // POST: EnrollStudentCouses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollStudentCouseId,studentId,EnrollCouseId,Score,Grade,TeacerId,Timestamp,YearEdu,Staff,Semester")] EnrollStudentCouse enrollStudentCouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollStudentCouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeacerId = new SelectList(db.Enroll_Emp_Po, "EnrEmpPosId", "EnrEmpPosId", enrollStudentCouse.TeacerId);
            ViewBag.EnrollCouseId = new SelectList(db.EnrollCouse, "EnrollCouseID", "CouseTxtId", enrollStudentCouse.EnrollCouseId);
            ViewBag.studentId = new SelectList(db.Students, "Student_id", "Student_title", enrollStudentCouse.studentId);
            return View(enrollStudentCouse);
        }

        // GET: EnrollStudentCouses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollStudentCouse enrollStudentCouse = db.EnrollStudentCouse.Find(id);
            if (enrollStudentCouse == null)
            {
                return HttpNotFound();
            }
            return View(enrollStudentCouse);
        }

        // POST: EnrollStudentCouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnrollStudentCouse enrollStudentCouse = db.EnrollStudentCouse.Find(id);
            db.EnrollStudentCouse.Remove(enrollStudentCouse);
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
