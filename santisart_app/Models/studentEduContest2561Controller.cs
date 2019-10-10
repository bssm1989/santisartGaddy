using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace santisart_app.Models
{
    public class studentEduContest2561Controller : Controller
    {
        private santisartEntities3 db = new santisartEntities3();

        // GET: studentEduContest2561
        public ActionResult Index()
        {
            return View(db.studentEduContest2561.ToList());
        }

        // GET: studentEduContest2561/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentEduContest2561 studentEduContest2561 = db.studentEduContest2561.Find(id);
            if (studentEduContest2561 == null)
            {
                return HttpNotFound();
            }
            return View(studentEduContest2561);
        }

        // GET: studentEduContest2561/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: studentEduContest2561/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_id,Student_title,Student_name,Student_lname,Class_name_id,Class_room,Class_year_index,Teacher_id,Class_id,TypeContest_id,NameContest,Staff_id,Timestamp,group,Day_contest,EduContest_id")] studentEduContest2561 studentEduContest2561)
        {
            if (ModelState.IsValid)
            {
                db.studentEduContest2561.Add(studentEduContest2561);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentEduContest2561);
        }

        // GET: studentEduContest2561/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentEduContest2561 studentEduContest2561 = db.studentEduContest2561.Find(id);
            if (studentEduContest2561 == null)
            {
                return HttpNotFound();
            }
            return View(studentEduContest2561);
        }

        // POST: studentEduContest2561/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_id,Student_title,Student_name,Student_lname,Class_name_id,Class_room,Class_year_index,Teacher_id,Class_id,TypeContest_id,NameContest,Staff_id,Timestamp,group,Day_contest,EduContest_id")] studentEduContest2561 studentEduContest2561)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentEduContest2561).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentEduContest2561);
        }

        // GET: studentEduContest2561/Delete/5s
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentEduContest2561 studentEduContest2561 = db.studentEduContest2561.Find(id);
            if (studentEduContest2561 == null)
            {
                return HttpNotFound();
            }
            return View(studentEduContest2561);
        }

        // POST: studentEduContest2561/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            studentEduContest2561 studentEduContest2561 = db.studentEduContest2561.Find(id);
            db.studentEduContest2561.Remove(studentEduContest2561);
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
