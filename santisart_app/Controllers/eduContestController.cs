using NinjaNye.SearchExtensions;
using santisart_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace santisart_app.Controllers
{
    public class eduContestController : Controller
    {
        // GET: eduContest
        santisartEntities2 db = new santisartEntities2();
        public ActionResult Index()
        {

            return View(db.studentEduContest2561.OrderBy(x=>x.TypeContest_id).ThenBy(x=>x.group).ThenBy(x=>x.result));
        }

        // GET: eduContest/Details/5
        public ActionResult Details(int EduContest_id)
        {
            return View(db.studentEduContest2561.Where(x=>x.EduContest_id== EduContest_id).FirstOrDefault());
        }

        // GET: eduContest/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult getcountries(string term)
        {
           return Json(db.student2561.Search(x=>x.Student_name,
                x => x.Student_lname, x => x.Class_name_id) .Containing(term).Take(5)
                , JsonRequestBehavior.AllowGet);
        }
        public ActionResult getDepartment()
        {
          
            return Json(db.ContestEducationSchool.Select(x => new
            {
                DepartmentID = x.TypeContest_id,
                DepartmentName = x.NameContest
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
        // POST: eduContest/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                db.Enroll_EduContest.Add(new Enroll_EduContest
                {
                    Student_id = Convert.ToInt32(collection["Student_id"]),
                    Type_id = Convert.ToInt32(collection["NameContest"]),
                    result= collection["result"],
                    Timestamp__ = DateTime.Now
                });

                db.SaveChanges();
                return View("index");
            }
            catch
            {
                return View("index");
            }
        }

        // GET: eduContest/Edit/5
        public ActionResult Edit(int EduContest_id)
        {
          return View(db.studentEduContest2561.Where(x => x.EduContest_id == EduContest_id).FirstOrDefault());
        }

        // POST: eduContest/Edit/5
        [HttpPost]
        public ActionResult Edit(int EduContest_id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                //db.Enroll_EduContest.Add(new Enroll_EduContest
                //{
                //    Type_id = Convert.ToInt32(collection["NameContest"]),
                //    Student_id = Convert.ToInt32(collection["Student_id"])
                //});
                var result = db.Enroll_EduContest.SingleOrDefault(x => x.EduContest_id == EduContest_id);
                //var result = db.Books.SingleOrDefault(b => b.BookNumber == bookNumber);
                if (result != null)
                {
                    result.Type_id = Convert.ToInt32(collection["NameContest"]);
                    result.result = collection["result"];
                    db.SaveChanges();
                }

                return View("index");
            }
            catch
            {
                return View();
            }
        }

        // GET: eduContest/Delete/5
        public ActionResult Delete(int EduContestId)
        {
           
            return View(db.studentEduContest2561.Where(x=>x.EduContest_id==EduContestId).FirstOrDefault());
        }

        // POST: eduContest/Delete/5
        [HttpPost]
        public ActionResult Delete(int EduContestId, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var studentContest = new Enroll_EduContest { EduContest_id = EduContestId };
                db.Enroll_EduContest.Attach(studentContest);
                db.Enroll_EduContest.Remove(studentContest);
                db.SaveChanges();
                return View("index");
            }
            catch
            {
                return View();
            }
        }
    }
}
