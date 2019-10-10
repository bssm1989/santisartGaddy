
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using santisart_app.Models;

namespace santisart_app.Controllers
{
    public class EmployeesController : Controller
    {
        private santisartEntities3 db = new santisartEntities3();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }
        public JsonResult IndexListJson()
        {
            List<Employee> empList = new List<Employee>() ;
            List<Employee> res = db.Employees.ToList();
            foreach (var item in res)
            {
                empList.Add(new Employee
                {
                    EmpTitle = item.EmpTitle,
                    EmpName =item.EmpName,
                    EmpLname=item.EmpLname,
                    EmpBirthday = item.EmpBirthday,

                    EmpIdcard = item.EmpIdcard,
                    EmpPsis_id = item.EmpPsis_id,
                    EmpStatus = item.EmpStatus,
                    EmpTimestamp = item.EmpTimestamp,
                    EmpTelephone = item.EmpTelephone,
                    Empbank_id = item.Empbank_id,

                    EmpId = item.EmpId,
                    EmpGender = item.EmpGender,
                    Password = item.Password,
                    UserName = item.UserName
                });
            }
            string output = JsonConvert.SerializeObject(empList);
            return Json(empList, JsonRequestBehavior.AllowGet);

        }
        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpTitle,EmpName,EmpLname,EmpBirthday,EmpIdcard,EmpPsis_id,EmpStatus,EmpTimestamp,EmpTelephone,Empbank_id,EmpId,EmpGender")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpTitle,EmpName,EmpLname,EmpBirthday,EmpIdcard,EmpPsis_id,EmpStatus,EmpTimestamp,EmpTelephone,Empbank_id,EmpId,EmpGender")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
