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
    public class Enroll_Emp_PosController : Controller
    {
        private santisartEntities2 db = new santisartEntities2();

        // GET: Enroll_Emp_Pos
        public ActionResult Index()
        {
            var enroll_Emp_Pos = db.Enroll_Emp_Pos.Include(e => e.Employee).Include(e => e.Position);
            return View(enroll_Emp_Pos.ToList());
        }

        // GET: Enroll_Emp_Pos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enroll_Emp_Pos enroll_Emp_Pos = db.Enroll_Emp_Pos.Find(id);
            if (enroll_Emp_Pos == null)
            {
                return HttpNotFound();
            }
            return View(enroll_Emp_Pos);
        }

        // GET: Enroll_Emp_Pos/Create
        public ActionResult Create()
        {
            ViewBag.Employee_id = new SelectList(db.Employees, "EmpId", "EmpTitle");
            ViewBag.Position_id = new SelectList(db.Positions, "PosId", "PosName");
            return View();
        }

        // POST: Enroll_Emp_Pos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_id,Position_id,EnrEmpPosStatus,EnrEmpPosTimestamp,EnrEmpPosId")] Enroll_Emp_Pos enroll_Emp_Pos)
        {
            if (ModelState.IsValid)
            {
                db.Enroll_Emp_Pos.Add(enroll_Emp_Pos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_id = new SelectList(db.Employees, "EmpId", "EmpTitle", enroll_Emp_Pos.Employee_id);
            ViewBag.Position_id = new SelectList(db.Positions, "PosId", "PosName", enroll_Emp_Pos.Position_id);
            return View(enroll_Emp_Pos);
        }

        // GET: Enroll_Emp_Pos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enroll_Emp_Pos enroll_Emp_Pos = db.Enroll_Emp_Pos.Find(id);
            if (enroll_Emp_Pos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_id = new SelectList(db.Employees, "EmpId", "EmpTitle", enroll_Emp_Pos.Employee_id);
            ViewBag.Position_id = new SelectList(db.Positions, "PosId", "PosName", enroll_Emp_Pos.Position_id);
            return View(enroll_Emp_Pos);
        }

        // POST: Enroll_Emp_Pos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_id,Position_id,EnrEmpPosStatus,EnrEmpPosTimestamp,EnrEmpPosId")] Enroll_Emp_Pos enroll_Emp_Pos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enroll_Emp_Pos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_id = new SelectList(db.Employees, "EmpId", "EmpTitle", enroll_Emp_Pos.Employee_id);
            ViewBag.Position_id = new SelectList(db.Positions, "PosId", "PosName", enroll_Emp_Pos.Position_id);
            return View(enroll_Emp_Pos);
        }

        // GET: Enroll_Emp_Pos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enroll_Emp_Pos enroll_Emp_Pos = db.Enroll_Emp_Pos.Find(id);
            if (enroll_Emp_Pos == null)
            {
                return HttpNotFound();
            }
            return View(enroll_Emp_Pos);
        }

        // POST: Enroll_Emp_Pos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enroll_Emp_Pos enroll_Emp_Pos = db.Enroll_Emp_Pos.Find(id);
            db.Enroll_Emp_Pos.Remove(enroll_Emp_Pos);
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
