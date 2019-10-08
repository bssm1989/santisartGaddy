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
    public class UserProfilesController : Controller
    {
        private santisartEntities2 db = new santisartEntities2();

        // GET: UserProfiles
        public ActionResult Index()
        {
            return View(db.UserProfiles.ToList());
        }
        public ActionResult Login(string ReturnUrl)
        {
            
            Session["PageUrl"] = ReturnUrl;
            //Response.Redirect("~/login.aspx?ReturnURL=" + returnUrl);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserProfiles objUser)
        {
            if (ModelState.IsValid)
            {
                using (santisartEntities2 db2 = new santisartEntities2())
                {
                    var obj = db2.Employees.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.EmpId.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                       Session["Room"] = db.Enroll_RoomSession_Emp.Where(x => x.userid == obj.EmpId).Include(e=>e.RoomSession).ToList();
                        if (Session["PageUrl"] == null)
                        {
                            return Redirect("/Home");
                        }else if(Session["PageUrl"].ToString() == "" )
                            return Redirect("/Home");
                        else
                        {
                            return Redirect(
                                Session["PageUrl"].ToString());
                        }

                    }
                }
            }
            
            return View(objUser);
        }
        public ActionResult Logout(string ReturnUrl)
        {
            Session["UserID"] = "";
            Session["UserName"] = "";
            if (ReturnUrl == "" || ReturnUrl == null)
            {
                return View("Login");
            }
            else
            {
                return Redirect(
                    Session["PageUrl"].ToString());
            }
        }
        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        // GET: UserProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfiles UserProfiles = db.UserProfiles.Find(id);
            if (UserProfiles == null)
            {
                return HttpNotFound();
            }
            return View(UserProfiles);
        }

        // GET: UserProfiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,Password,IsActive")] UserProfiles UserProfiles)
        {
            if (ModelState.IsValid)
            {
                db.UserProfiles.Add(UserProfiles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(UserProfiles);
        }

        // GET: UserProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfiles UserProfiles = db.UserProfiles.Find(id);
            if (UserProfiles == null)
            {
                return HttpNotFound();
            }
            return View(UserProfiles);
        }

        // POST: UserProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,Password,IsActive")] UserProfiles UserProfiles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(UserProfiles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(UserProfiles);
        }

        // GET: UserProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfiles UserProfiles = db.UserProfiles.Find(id);
            if (UserProfiles == null)
            {
                return HttpNotFound();
            }
            return View(UserProfiles);
        }

        // POST: UserProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfiles UserProfiles = db.UserProfiles.Find(id);
            db.UserProfiles.Remove(UserProfiles);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
