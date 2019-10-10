using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using santisart_app.Models;
namespace santisart_app.Controllers
{
    public class AttendanceController : Controller
    {
        santisartEntities3 db = new santisartEntities3();
        // GET: Attendance
        public ActionResult Index(int? classId)
        {
            int month = DateTime.Now.Month;
            // class_ student id 

            List<attdanceClass> listStudentByclass = new List<attdanceClass>();


            //attendance by student_id
            //var attdance = db.attendance_day
            //    .GroupJoin(db.C_enrollattstudent,
            //        left => left.attday_id, right => right.attday_id,
            //        (left, right) => new { TableA = right, TableB = left })
            //    .SelectMany(p => p.TableA.DefaultIfEmpty(), (x, y) =>
            //        new { TableA = y, TableB = x.TableB }).OrderBy(x => x.TableB.attday_id);
            List<viewStudentCrossAttday> att = new List<viewStudentCrossAttday>();
            //foreach (var item in attdance)
            //{
            //    att.Add(new viewStudentCrossAttday
            //    {
            //        Student_id = item?.TableA?.Student_id??0,
            //        Student_title = item?.TableA?.Student_title??"" ,
            //        Student_name = item.TableA?.Student_name ??"",
            //        Student_lname = item.TableA?.Student_lname ?? "",
            //        att_id = item?.TableA?.att_id??0,
            //        Staff_id = item?.TableA?.Staff_id ?? 0,
            //       qira_id = item?.TableA?.qira_id ?? 0,
            //       page = item?.TableA?.page ?? 0,
            //       attday_id = item.TableB.attday_id,
            //       attday_date = item.TableB.attday_date,
            //       Timestamp = item.TableB.Timestamp,
            //       status = item.TableB.status,
            //       staff_id = item.TableB.staff_id,
            //       year_index = item.TableB.staff_id,
            //       Comment = item.TableB.Comment,

            //    });
            //}



            //listStudentByclass.Add(new attdanceClass
            //{
            //    students = db.Students.Where(x => x.Student_id == 1).FirstOrDefault(),
            //    attMonunt = att
            //});
            //    var att2 = att[0].TableA.attday_id;

            var attbyclass = db.EnrollStudentAttdances.Where(x => x.Class_id ==classId);
            var studentbyclass = db.student2561.Where(x => x.Class_id == classId).ToList();
            var attbymonth = db.attendance_day;
            List<SelectListItem> listClass = new List<SelectListItem>();
            foreach (var item in db.Classes.Where(x=>x.Status_class==1))
            {
                listClass.Add(new SelectListItem
                {
                    Text = item.Class_name_id + "/" + item.Class_room,
                    Value = item.Class_id.ToString()
                });
            }

            // ViewBag.data = {attbyclass,student;
            attdeanceBymonth valuepass = new attdeanceBymonth
            {
                attMonth = attbymonth.ToList(),
                attStudent = attbyclass.ToList(),
                studentByClass = studentbyclass.ToList(),
                classList = listClass.ToList()


            };
            return View(valuepass);
        }
        //public IEnumerable studentsbyid()
        //{
        //    var attdance = db.attendance_day
        //        .GroupJoin(db.C_enrollattstudent,
        //            left => left.attday_id, right => right.attday_id,
        //            (left, right) => new { TableA = right, TableB = left })
        //        .SelectMany(p => p.TableA.DefaultIfEmpty(), (x, y) =>
        //            new { TableA = y, TableB = x.TableB }).OrderBy(x => x.TableB.attday_id);
        //    return attdance;
        //}

    }
}