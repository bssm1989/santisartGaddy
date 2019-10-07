using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using santisart_app.Models;

namespace santisart_app.Controllers
{
    public class SurveyStudentsController : Controller
    {
        private santisartEntities2 db = new santisartEntities2();

        // GET: SurveyStudents
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.enrolladdress);//.Take(10);
            return View(students.ToList());
        }
        //[Produces("application/json")]
        //[HttpGet]
        public ActionResult Search(string term)
        {
            try
            {
                //string term = HttpContext.Request.QueryString["term"].ToString();
                var postTitle = db.Students.Where(p => p.Student_name.Contains(term))
                    .Select(p =>new { lable = p.Student_name });
                return Json(postTitle, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
        // GET: SurveyStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: SurveyStudents/Create
        public ActionResult Create()
        {
            ViewBag.adressid = new SelectList(db.enrolladdresses, "addressId", "tambol");
            return View();
        }

        // POST: SurveyStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_id,Student_title,Student_name,Student_lname,Student_birthday,Student_idcard,Student_psis_id,Student_status,Student_timestamp,Student_ArabName,Student_OldSchool,Studnet_Gender,Student_firsttime,Student_tel,adressid")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.adressid = new SelectList(db.enrolladdresses, "addressId", "tambol", student.adressid);
            return View(student);
        }

        // GET: SurveyStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.adressid = new SelectList(db.enrolladdresses, "addressId", "tambol", student.adressid);
            return View(student);
        }

        // POST: SurveyStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_id,Student_title,Student_name,Student_lname,Student_birthday,Student_idcard,Student_psis_id,Student_status,Student_timestamp,Student_ArabName,Student_OldSchool,Studnet_Gender,Student_firsttime,Student_tel,adressid")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.adressid = new SelectList(db.enrolladdresses, "addressId", "tambol", student.adressid);
            return View(student);
        }

        // GET: SurveyStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: SurveyStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
