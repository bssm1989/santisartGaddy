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
        [HttpGet]
        public ActionResult SearchDistrics(int idProvince)
        {
            try
            {
                //string term = HttpContext.Request.QueryString["term"].ToString();
                var ListDistricts = db.Districts.Where(p => p.ProvinceId==idProvince).ToList();
                return Json(ListDistricts, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public ActionResult SearchSubDist(int idSubdist)
        {
            try
            {
                //string term = HttpContext.Request.QueryString["term"].ToString();
                var ListDistricts = db.Subdistricts.Where(p => p.DistrictId==idSubdist).ToList();
                return Json(ListDistricts, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
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
                    ParentList.Add( db.EnrollFamilyStudents.AsNoTracking()
                        .Where(x => x.StudentId == student.Student_id && x.TypeFamily == "potentate").FirstOrDefault());
                    enrolladdress adress = db.enrolladdresses.AsNoTracking()
                        .Where(x => x.student_id == student.Student_id).FirstOrDefault();
                    studentSurvey.address = adress;
                    studentSurvey.enrollFamily = ParentList;
                    
                    var selectProvince = new[] { 75, 76, 77,71 };
                    var fillterProvince = db.Provinces.Where(x=>selectProvince.Contains(x.Id));
                    var selectDistrict = fillterProvince.Select(y => y.Id).ToList();
                    //var filteredOrders = orders.Order.Where(o => allowedStatus.Contains(o.StatusCode));
                    var fillterDistrict = db.Districts.Where(x => selectProvince.Contains(x.ProvinceId));
                    var selectSubDis = fillterDistrict.Select(x => x.Id).ToList();
                    var fillterSubDistrict = db.Subdistricts.Where(x => selectSubDis.Contains(x.DistrictId));
                    ViewBag.Districts = new SelectList(fillterDistrict, "Id", "NameInThai", 
                                                    db.enrolladdresses.Where(x=>x.student_id==student.Student_id)
                                                    .FirstOrDefault().Sub_id);
                    ViewBag.Sub_id = new SelectList(fillterSubDistrict, "Sub_id", "NameInThai",
                                                    db.enrolladdresses.Where(x => x.student_id == student.Student_id)
                                                    .FirstOrDefault().Sub_id);
                    ViewBag.Provices = new SelectList(fillterProvince, "Id", "NameInThai",
                                                    db.enrolladdresses.Where(x => x.student_id == student.Student_id)
                                                    .FirstOrDefault().Sub_id);
                }
            }
                return View(studentSurvey);
            
            
        }public ActionResult testdropdown()
        {
            ViewBag.sub_id = new SelectList(db.Districts, "Sub_id", "NameInThai");
            return View(db.enrolladdresses.Find(1));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editSurvey( SurveyStudent student)
        //public ActionResult editSurvey([Bind(Include = "students.Student_name,students.Student_lname,enrollFamily[0].Family.Fam_Name,enrollFamily[0].Family.Fam_Lname,enrollFamily[0].Family.Career,enrollFamily[1].Family.Fam_Name,enrollFamily[1].Family.Fam_Lname,enrollFamily[1].Family.Career,address.nameVil,address.number,address.Subdistrict.NameInThai,address.Subdistrict.District.NameInThai,address.Subdistrict.District.Province.NameInThai")] SurveyStudent student)
        {
            if (ModelState.IsValid)
            {
                if (student.enrollFamily != null&&student.address!=null)
                {
                    SaveSurvey(student);
                }
                return RedirectToAction("Index");
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        public void SaveSurvey(SurveyStudent surveyStudents)
        {
            if (surveyStudents != null)
            {
               //family
                    foreach (var  parent in surveyStudents.enrollFamily)
                    {
                        var record = db.Families.Find(parent.Family.FamilyId);
                        if (record != null)
                        {
                            
                            record.FamilyId=parent.Family.FamilyId;
                            record.Fam_Title=parent.Family.Fam_Title;
                            record.Fam_Name=parent.Family.Fam_Name;
                            record.Fam_Lname=parent.Family.Fam_Lname;
                            record.birthday=parent.Family.birthday;
                            record.Career=parent.Family.Career;
                            record.Income=parent.Family.Income;
                            record.Education=parent.Family.Education;
                            record.Timestam=parent.Family.Timestam;
                            record.Staft=parent.Family.Staft;
                            record.Gender=parent.Family.Gender;
                            record.Idcard=parent.Family.Idcard;
                        }
                }
                    db.SaveChanges();
                
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
