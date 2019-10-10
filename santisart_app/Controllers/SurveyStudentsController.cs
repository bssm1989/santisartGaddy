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
        private santisartEntities3 db = new santisartEntities3();

        // GET: SurveyStudents
        public ActionResult Index()
        {
            var students = db.Students.Take(10);
            return View(students.ToList());
        }
        [HttpGet]
        public ActionResult IndexSearch(string postTitle)
        {
            if (postTitle==null)
            {
                postTitle = "";
            }
           
                var listDataStudents = db.Students.Where(p => p.Student_name.Contains(postTitle));
            //var students = db.Students.Include(s => s.enrolladdress);//.Take(10);
            return View("Index",listDataStudents.ToList());
        }
        //[Produces("application/json")]
        //[HttpGet]
        public ActionResult Search()
        {
            try
            {
                string term = HttpContext.Request.QueryString["term"].ToString();
                var postTitle = db.Students.Where(p => p.Student_name.Contains(term)).Take(5)
                    .Select(p =>p.Student_name ).ToList();
                return Json(postTitle, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //List<OrderDisplayViewModel> orderList = context.Orders.AsNoTracking()
        //                   .Where(x => x.CustomerID == customerid)
        //                   .OrderBy(x => x.OrderDate)
        //                   .Select(x =>
        //                  new OrderDisplayViewModel
        //                   {
        //                       CustomerID = x.CustomerID,
        //                       OrderID = x.OrderID,
        //                       OrderDate = x.OrderDate,
        //                       Description = x.Description
        //                   }).ToList();
        //customerOrdersListVm.Orders = orderList;
        public ActionResult editSurvey()
        {
                var studentSurvey = new SurveyStudent();
            if (true)
            {
                Student student = db.Students.Find(705);
                if (student != null)
                {
                    //baby
                    studentSurvey.students = student;
                    //father&mother
                    List<EnrollFamilyStudent> ParentList = new List<EnrollFamilyStudent>();
                    ParentList.Add( db.EnrollFamilyStudents.AsNoTracking()
                        .Where(x => x.StudentId == student.Student_id && x.TypeFamily == "father").FirstOrDefault());
                    ParentList.Add( db.EnrollFamilyStudents.AsNoTracking()
                        .Where(x => x.StudentId == student.Student_id && x.TypeFamily == "mother").FirstOrDefault());
                    enrolladdress adress = db.enrolladdresses.AsNoTracking()
                        .Where(x => x.addressId == student.adressid).FirstOrDefault();
                    studentSurvey.address = adress;
                    studentSurvey.enrollFamily = ParentList;
                }
            }
                return View(studentSurvey);
            
            
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
            //ViewBag.adressid = new SelectList(db.enrolladdresses, "addressId", "tambol", student.adressid);
            ViewBag.ParentA = new SelectList(db.EnrollFamilyStudents, "addressId", "tambol", student.adressid);
            return View(student);
        }     
        public ActionResult EditFamily(int? id)
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
