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
    public class EnrollRoomSessionEmpController : Controller
    {
        private santisartEntities3 db = new santisartEntities3();

        // GET: EnrollRoomSessionEmp
        public ActionResult Index()
        {
            var enroll_RoomSession_Emp = db.Enroll_RoomSession_Emp.Include(e => e.Employee).Include(e => e.RoomSession);
            return View(enroll_RoomSession_Emp.ToList());
        }

        // GET: EnrollRoomSessionEmp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enroll_RoomSession_Emp enroll_RoomSession_Emp = db.Enroll_RoomSession_Emp.Find(id);
            if (enroll_RoomSession_Emp == null)
            {
                return HttpNotFound();
            }
            return View(enroll_RoomSession_Emp);
        }

        // GET: EnrollRoomSessionEmp/Create
        public ActionResult Create()
        {
            List<object> newList = new List<object>();
            foreach (var member in db.Employees)
                newList.Add(new
                {
                    Id = member.EmpId,
                    Name = member.EmpName + " " + member.EmpLname
                });
            ViewBag.userid = new SelectList(newList, "Id", "Name");
            ViewBag.RoomSessionId = new SelectList(db.RoomSessions, "RoomSessionId", "RoomName");
            return View();
        }

        // POST: EnrollRoomSessionEmp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollRoomEmpId,userid,timestamp,staft,status,value,RoomSessionId")] Enroll_RoomSession_Emp enroll_RoomSession_Emp)
        {
            enroll_RoomSession_Emp.timestamp=System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Enroll_RoomSession_Emp.Add(enroll_RoomSession_Emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userid = new SelectList(db.Employees, "EmpId", "EmpTitle", enroll_RoomSession_Emp.userid);
            ViewBag.RoomSessionId = new SelectList(db.RoomSessions, "RoomSessionId", "RoomName", enroll_RoomSession_Emp.RoomSessionId);
            return View(enroll_RoomSession_Emp);
        }

        // GET: EnrollRoomSessionEmp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enroll_RoomSession_Emp enroll_RoomSession_Emp = db.Enroll_RoomSession_Emp.Find(id);
            if (enroll_RoomSession_Emp == null)
            {
                return HttpNotFound();
            }
            List<object> newList = new List<object>();
            foreach (var member in db.Employees)
                newList.Add(new
                {
                    Id = member.EmpId,
                    Name = member.EmpName + " " + member.EmpLname
                });
            ViewBag.userid = new SelectList(newList, "Id", "Name", enroll_RoomSession_Emp.userid);
            ViewBag.RoomSessionId = new SelectList(db.RoomSessions, "RoomSessionId", "RoomName", enroll_RoomSession_Emp.RoomSessionId);
            return View(enroll_RoomSession_Emp);
        }

        // POST: EnrollRoomSessionEmp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollRoomEmpId,userid,timestamp,staft,status,value,RoomSessionId")] Enroll_RoomSession_Emp enroll_RoomSession_Emp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enroll_RoomSession_Emp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<object> newList = new List<object>();
            foreach (var member in db.Employees)
                newList.Add(new
                {
                    Id = member.EmpId,
                    Name = member.EmpName + " " + member.EmpLname
                });
            ViewBag.userid = new SelectList(newList, "Id", "Name", enroll_RoomSession_Emp.userid);
            ViewBag.RoomSessionId = new SelectList(db.RoomSessions, "RoomSessionId", "RoomName", enroll_RoomSession_Emp.RoomSessionId);
            return View(enroll_RoomSession_Emp);
        }

        // GET: EnrollRoomSessionEmp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enroll_RoomSession_Emp enroll_RoomSession_Emp = db.Enroll_RoomSession_Emp.Find(id);
            if (enroll_RoomSession_Emp == null)
            {
                return HttpNotFound();
            }
            return View(enroll_RoomSession_Emp);
        }

        // POST: EnrollRoomSessionEmp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enroll_RoomSession_Emp enroll_RoomSession_Emp = db.Enroll_RoomSession_Emp.Find(id);
            db.Enroll_RoomSession_Emp.Remove(enroll_RoomSession_Emp);
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
