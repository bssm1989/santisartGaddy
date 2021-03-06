﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using santisart_app.Models;
using System.Web.Optimization;

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

                var ListDistricts = db.Districts.Where(p => p.ProvinceId == idProvince)
                  .AsEnumerable()
                .Select(x => new
                {
                    x.Id,x.NameInThai
                }
                ).ToList();
            string strJson;
            strJson = "{";
            foreach (var item in ListDistricts)
            {
                strJson +=  "'" + item.Id + "' : '" +
                    item.NameInThai+"'," ;
            }
            strJson = strJson.Remove(strJson.Length - 1)+ "}";
            JavaScriptSerializer j = new JavaScriptSerializer();
            object a = j.Deserialize(strJson, typeof(object));
           
            return Json(a, JsonRequestBehavior.AllowGet);
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
                var ListDistricts = db.Subdistricts.Where(p => p.DistrictId==idSubdist)
                    .AsEnumerable()
                .Select(x => new
                {
                    x.Sub_id,
                    x.NameInThai
                }
                ).ToList();
                string strJson;
                strJson = "{";
                foreach (var item in ListDistricts)
                {
                    strJson += "'" + item.Sub_id + "' : '" +
                        item.NameInThai + "',";
                }
                strJson = strJson.Remove(strJson.Length - 1) + "}";
                JavaScriptSerializer j = new JavaScriptSerializer();
                object a = j.Deserialize(strJson, typeof(object));
                return Json(a, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult editSurvey(int? id)
        {
            var studentSurvey = new SurveyStudent();
            if (true)
            {
                Student student = db.Students.Find(id);
                if (student != null)
                {
                    //baby
                    studentSurvey.students = student;
                    //father&mother
                    List<EnrollFamilyStudent> ParentList = new List<EnrollFamilyStudent>();
                    ParentList.Add(db.EnrollFamilyStudents.AsNoTracking()
                        .Where(x => x.StudentId == student.Student_id && x.TypeFamily == "father" &&x.status=="1").FirstOrDefault());
                    ParentList.Add(db.EnrollFamilyStudents.AsNoTracking()
                        .Where(x => x.StudentId == student.Student_id && x.TypeFamily == "mother" && x.status == "1").FirstOrDefault());
                    ParentList.Add(db.EnrollFamilyStudents.AsNoTracking()
                        .Where(x => x.StudentId == student.Student_id && x.TypeFamily == "potentate" && x.status == "1").FirstOrDefault());
                    if (ParentList[0]==null)
                    {
                        ParentList[0] = new EnrollFamilyStudent();
                        ParentList[0].Family = new Family();
                    } if (ParentList[1]==null)
                    {
                        ParentList[1] = new EnrollFamilyStudent();
                        ParentList[1].Family = new Family();
                    } if (ParentList[2]==null)
                    {
                        ParentList[2] = new EnrollFamilyStudent();
                        ParentList[2].Family = new Family();
                    }
                    if (ParentList[0].FamilyId == ParentList[2].FamilyId&& ParentList[0].FamilyId!=null)
                    {
                        studentSurvey.checkFa= "checked";
                        ParentList[2] = new EnrollFamilyStudent();
                        ParentList[2].Family = new Family();
                    }
                    else
                    {
                        studentSurvey.checkFa= "";

                    }
                    if (ParentList[1].FamilyId == ParentList[2].FamilyId && ParentList[1].FamilyId != null)
                    {
                        studentSurvey.checkMo= "checked";
                        ParentList[2] = new EnrollFamilyStudent();
                        ParentList[2].Family = new Family();
                    }
                    else
                    {
                        studentSurvey.checkMo= "";

                    }

                    enrolladdress adress = new enrolladdress();
                   
                    adress=db.enrolladdresses.AsNoTracking()
                        .Where(x => x.student_id == student.Student_id&&x.Active==1).FirstOrDefault();
                    studentSurvey.address = adress;
                    if (adress == null)
                    {
                        adress = new enrolladdress();
                    }
                    studentSurvey.enrollFamily = ParentList;
                    var selectProvince = new[] { 75, 76, 77, 71 };
                    var fillterSubDistrict = new List<Subdistrict>();
                    var fillterDistrict = new List<District>();
                    var fillterProvince = new List<Province>();
                      fillterProvince = db.Provinces.Where(x => selectProvince.Contains(x.Id)).ToList();
                    if (adress.DistrictId != null)
                        fillterSubDistrict = db.Subdistricts.Where(x => x.DistrictId == adress.DistrictId).ToList();
                    if (adress.ProvinceID != 0)
                    {
                        fillterDistrict = db.Districts.Where(x => x.ProvinceId == adress.ProvinceID).ToList();
                    }
                    if (adress.ProvinceID != null)
                    {

                        ViewBag.Provices = new SelectList(fillterProvince, "Id", "NameInThai", adress.ProvinceID);
                        ViewBag.Districts = new SelectList(fillterDistrict, "Id", "NameInThai", adress.DistrictId);
                        ViewBag.Sub_id = new SelectList(fillterSubDistrict, "Sub_id", "NameInThai", adress.Sub_id);
                    }
                    else
                    {

                        ViewBag.Provices = new SelectList(fillterProvince, "Id", "NameInThai");
                        ViewBag.Districts = new SelectList(fillterDistrict, "Id", "NameInThai");
                        ViewBag.Sub_id = new SelectList(fillterSubDistrict, "Sub_id", "NameInThai");
                    }
                    studentSurvey.PosFamDropdown= new SelectList(db.PositionFams, "PositionId", "PositionName");
                   
                }
            }
  
            return View(studentSurvey);


        }
            
           
        public ActionResult listStudentFamAdd()
        {
            var listEnrolladdress = db.enrolladdresses.Where(x => x.Active == 1).OrderByDescending(x => x.timestamp);//.Take(10);
            var surveyStudentList = new List<surveyList>();

            foreach (var item in listEnrolladdress)
            {
                var families = item.Student.EnrollFamilyStudents.Where(
                            x => x.status == "1");
                var FatherName = families.Where(x => x.TypeFamily == "father").FirstOrDefault();
                var MotherName = families.Where(x => x.TypeFamily == "mother").FirstOrDefault();
                var PotentateName = families.Where(x => x.TypeFamily == "potentate").FirstOrDefault();
                //var  TeststudentName = item.Student.Student_name + " " + item.Student.Student_lname;
                //var  TestFatherName = FatherName != null ? FatherName.Family.Fam_Name + " " + FatherName.Family.Fam_Lname : " ";
                //var  TestMotherName = MotherName != null ? MotherName.Family.Fam_Name + " " + MotherName.Family.Fam_Lname : " ";
                //var  TestPotentateName = PotentateName != null ? PotentateName.Family.Fam_Name + " " + PotentateName.Family.Fam_Lname : "";
                //var  TestFatherCareer = FatherName != null ? FatherName.Family.Career ?? "" : "";
                //var  TestMotherCareer = MotherName != null ? MotherName.Family.Career ?? "" : "";
                //var  TestPotentateCareer = PotentateName != null ? PotentateName.Family.Career ?? "" : "";
                //var  TestFatherPosition = FatherName != null ? FatherName.Family.PositionFam!=null? FatherName.Family.PositionFam.PositionName :"": "";
                //var  TestMotherPosition = MotherName != null ? MotherName.Family.PositionFam!=null? MotherName.Family.PositionFam.PositionName :"": "";
                    //var test1= item.codeAddress                                        ;
                    //var test2= item.Soi != null ? " soi " + item.Soi : ""                  ;
                    //var test3= item.numberHome != null ? " mou "+item.numberHome : "";
                    //var test4=  item.Sub_id != null ? " tumbol "+item.Subdistrict.NameInThai : ""                            ;
                    //var test6= item.DistrictId != null ? " aumper " +item.District.NameInThai : ""                               ;
                    //var test8= item.ProvinceID != null ? " " + item.Province.NameInThai : "";
               
                surveyStudentList.Add(new surveyList
                {
                    studentName = item.Student.Student_name + " " + item.Student.Student_lname,
                    FatherName = FatherName != null ? FatherName.Family.Fam_Name + " " + FatherName.Family.Fam_Lname : " ",
                    MotherName = MotherName != null ? MotherName.Family.Fam_Name + " " + MotherName.Family.Fam_Lname : " ",
                    PotentateName = PotentateName != null ? PotentateName.Family.Fam_Name + " " + PotentateName.Family.Fam_Lname : "",
                    FatherCareer = FatherName != null ? FatherName.Family.Career ?? "" : "",
                    MotherCareer = MotherName != null ? MotherName.Family.Career ?? "" : "",
                    PotentateCareer = PotentateName != null ? PotentateName.Family.Career ?? "" : "",
                    FatherPosition = FatherName != null ? FatherName.Family.PositionFam != null ? FatherName.Family.PositionFam.PositionName : "" : "",
                    MotherPosition = MotherName != null ? MotherName.Family.PositionFam != null ? MotherName.Family.PositionFam.PositionName : "" : "",
                    address = item.numberHome 
                    +(item.codeAddress!=null?" หมู่ที่ "+item.codeAddress:"")
                    +(item.Soi != null ? " ซอย " + item.Soi : "")
                    +( item.Sub_id!=null?" ต."+item.Subdistrict.NameInThai:""         )
                    +( item.DistrictId!=null?" อ."+item.District.NameInThai:""        )
                    +( item.ProvinceID!=null?" "+item.Province.NameInThai:""              )
                }) ;
            }

                
            return View(surveyStudentList);
        }
        public ActionResult testdropdown()
        {
            ViewBag.sub_id = new SelectList(db.Districts, "Sub_id", "NameInThai");
            return View(db.enrolladdresses.Find(1));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editSurvey( SurveyStudent student)
         {
            if (ModelState.IsValid)
            {
                if (student.enrollFamily != null&&student.address!=null)
                {
                    SaveSurvey(student);
                    
                    SaveAddress(student);
                }

                return RedirectToAction("Index");
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public void SaveAddress(SurveyStudent student)
        {
            
            //try
            //{
                //if(address.addressId!=0)
                if(student.address.addressId!=null)
                { 
                var unactive=db.enrolladdresses.Find(student.address.addressId);
                unactive.Active = 0;
                }
                var address = student.address;
            address.student_id = student.students.Student_id;
                    address.timestamp = DateTime.Now;
                    address.Active = 1;
                if (student.Sub_id != 0)
                    address.Sub_id = student.Sub_id;
                if (student.Districts != 0)
                    address.DistrictId = student.Districts;
                if (student.Provices != 0)
                    address.ProvinceID = student.Provices;
                  
                    address.staff_id = Convert.ToInt32(Session["UserID"]);
                    db.enrolladdresses.Add(address);
                    db.SaveChanges();
                
               
                
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
           

        }

        public void SaveSurvey(SurveyStudent surveyStudents)
        {
            if (surveyStudents != null)
            {
                //family
                using (var db2 = new santisartEntities3())
                {
                    int fatherId=0, motherId=0;
                    int index = 0;
                    db2.EnrollFamilyStudents
                    .Where(x => x.StudentId == surveyStudents.students.Student_id)
                    .ToList().ForEach(y => y.status = "0"); 

                    foreach (var  parent in surveyStudents.enrollFamily)
                    {
                       
                        if (index == 2 && !(parent.TypeFamily == "potentate"))
                        {

                            if (parent.TypeFamily == "father")
                            {
                                int studentId = surveyStudents.students.Student_id;
                               
                                var recordEnrollFam = new EnrollFamilyStudent();
                                recordEnrollFam.FamilyId = fatherId;
                                recordEnrollFam.status = "1";
                                recordEnrollFam.StudentId = surveyStudents.students.Student_id;
                             
                                recordEnrollFam.Timestamp = DateTime.Now;
                                recordEnrollFam.staftId = Convert.ToInt32(Session["UserID"]); ;
                                recordEnrollFam.TypeFamily = "potentate";
                                db2.EnrollFamilyStudents.Add(recordEnrollFam);
                            }
                            else
                            {
                                int studentId = surveyStudents.students.Student_id;

                                var recordEnrollFam = new EnrollFamilyStudent();
                                recordEnrollFam.FamilyId = motherId;
                                recordEnrollFam.status = "1";
                                recordEnrollFam.StudentId = surveyStudents.students.Student_id;
                                recordEnrollFam.Timestamp = DateTime.Now;
                                recordEnrollFam.staftId = Convert.ToInt32(Session["UserID"]); ;
                                recordEnrollFam.TypeFamily ="potentate";
                                db2.EnrollFamilyStudents.Add(recordEnrollFam);
                            }

                        }
                        else
                        {
                            var record = new Family();
                            record.Fam_Title = parent.Family.Fam_Title;
                            record.Fam_Name = parent.Family.Fam_Name;
                            record.Fam_Lname = parent.Family.Fam_Lname;
                            record.birthday = parent.Family.birthday;
                            record.Career = parent.Family.Career;
                            record.Income = parent.Family.Income;
                            record.Education = parent.Family.Education;
                            record.Timestam = DateTime.Now;
                            record.Staft = parent.Family.Staft;
                            record.Tel = parent.Family.Tel;
                            record.Gender = parent.Family.Gender;
                            record.Idcard = parent.Family.Idcard;
                            record.PositionFam_id = parent.Family.PositionFam_id;
                            record.Staft = Convert.ToInt32(Session["UserID"]); ;
                            db2.Families.Add(record);
                            db2.SaveChanges();
                            int idFamParent = record.FamilyId;
                            var recordEnrollFam = new EnrollFamilyStudent();
                            recordEnrollFam.FamilyId = idFamParent;
                            recordEnrollFam.status = "1";
                            recordEnrollFam.StudentId = surveyStudents.students.Student_id;
                            recordEnrollFam.Timestamp = DateTime.Now;
                            recordEnrollFam.staftId = Convert.ToInt32(Session["UserID"]); ;
                            recordEnrollFam.TypeFamily = parent.TypeFamily;
                            db2.EnrollFamilyStudents.Add(recordEnrollFam);
                            if (index == 0)
                            {
                                fatherId = record.FamilyId;
                            }
                            else
                            {
                                motherId = record.FamilyId;
                            }
                        }

                        index++;
                        

                }
                    db2.SaveChanges();
                }
                   
               
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
