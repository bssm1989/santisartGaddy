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
    public class EnrollCousesController : Controller
    {
        private santisartEntities2 db = new santisartEntities2();

        // GET: EnrollCouses
        public ActionResult Index()
        {
            var enrollCouse = db.EnrollCouses
                .Include(e => e.ClassInSchool)
                .Include(e => e.Course)
                .Include(e => e.Department)
                .OrderBy(x=>x.ClassInSchool.ClassID)
                .ThenBy(x=>x.semester__)
                .ThenBy(x=>x.CouseId);
            return View(enrollCouse.ToList());
        }
        public ActionResult EditList()
        {
            var enrollCouse = db.EnrollCouses
                .Where(xx=>xx.ClassInSchool.ClassShortName=="ป.1")
                .Include(e => e.ClassInSchool)
                .Include(e => e.Course)
                .Include(e => e.Department)
                .OrderBy(x => x.semester__)
                .ThenBy(x => x.IndexSort)
                .ThenBy(x => x.CouseId);
          
            ViewBag.ClassId = new SelectList(db.ClassInSchools, "ClassID", "ClassShortName");
            ViewBag.CouseId = new SelectList(db.Courses, "CourseId", "CourseName");
            ViewBag.DepartId = new SelectList(db.Departments, "Depart_Id", "DepartName");

            return View(enrollCouse.ToList());
        }
        [HttpPost]
        public ActionResult EditList(List<EnrollCouse> EnrollCouse)
        {
            foreach (var item in EnrollCouse)
            {
                //EnrollCouse EditListEdit = db.EnrollCouses.Find(item.EnrollCouseID);
                if (ModelState.IsValid)
                {
                    EnrollCouse EditListEdit = db.EnrollCouses.Find(item.EnrollCouseID);
                    EditListEdit.EnrollCouseID = item.EnrollCouseID;
                    EditListEdit.ClassId= item.ClassId;
                    EditListEdit.CouseTxtId = item.CouseTxtId;
                    EditListEdit.CouseTime = item.CouseTime;
                    EditListEdit.CouseWeight__ = item.CouseWeight__;
                    EditListEdit.IndexSort = item.IndexSort;
                    EditListEdit.Timestamp = System.DateTime.Now;
                    //db.Entry(item).State = EntityState.Modified;
                    //db.SaveChanges();
                   
                }
               
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: EnrollCouses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollCouse enrollCouse = db.EnrollCouses.Find(id);
            if (enrollCouse == null)
            {
                return HttpNotFound();
            }
            return View(enrollCouse);
        }

        // GET: EnrollCouses/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.ClassInSchools, "ClassID", "ClassShortName");
            ViewBag.CouseId = new SelectList(db.Courses, "CourseId", "CourseName");
            ViewBag.DepartId = new SelectList(db.Departments, "Depart_Id", "DepartName");
            return View();
        }

        // POST: EnrollCouses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CouseTxtId,CouseId,DepartId,CouseTime,CouseWeight__,ClassId,semester__,EnrollCouseID")] EnrollCouse enrollCouse)
        {
            if (ModelState.IsValid)
            {
                db.EnrollCouses.Add(enrollCouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.ClassInSchools, "ClassID", "ClassShortName", enrollCouse.ClassId);
            ViewBag.CouseId = new SelectList(db.Courses, "CourseId", "CourseName", enrollCouse.CouseId);
            ViewBag.DepartId = new SelectList(db.Departments, "Depart_Id", "DepartName", enrollCouse.DepartId);
            return View(enrollCouse);
        }

        // GET: EnrollCouses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollCouse enrollCouse = db.EnrollCouses.Find(id);
            if (enrollCouse == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.ClassInSchools, "ClassID", "ClassShortName", enrollCouse.ClassId);
            ViewBag.CouseId = new SelectList(db.Courses, "CourseId", "CourseName", enrollCouse.CouseId);
            ViewBag.DepartId = new SelectList(db.Departments, "Depart_Id", "DepartName", enrollCouse.DepartId);
            return View(enrollCouse);
        }

        // POST: EnrollCouses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CouseTxtId,CouseId,DepartId,CouseTime,CouseWeight__,ClassId,semester__,EnrollCouseID")] EnrollCouse enrollCouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollCouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.ClassInSchools, "ClassID", "ClassShortName", enrollCouse.ClassId);
            ViewBag.CouseId = new SelectList(db.Courses, "CourseId", "CourseName", enrollCouse.CouseId);
            ViewBag.DepartId = new SelectList(db.Departments, "Depart_Id", "DepartName", enrollCouse.DepartId);
            return View(enrollCouse);
        }

        // GET: EnrollCouses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollCouse enrollCouse = db.EnrollCouses.Find(id);
            if (enrollCouse == null)
            {
                return HttpNotFound();
            }
            return View(enrollCouse);
        }

        // POST: EnrollCouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnrollCouse enrollCouse = db.EnrollCouses.Find(id);
            db.EnrollCouses.Remove(enrollCouse);
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
