using Rotativa;
using santisart_app.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace santisart_app.Controllers
{
    public class FoodPaidController : Controller
    {
        // GET: FoodPaid
        santisartEntities3 db = new santisartEntities3();
        
        
        public async Task<ActionResult> Index()
       {
            var ps = await db.Enroll_student_class.ToListAsync();

            return View(ps);
        }
        public  ActionResult Details(int Student_id)
        {

            //var ps = await(from p in db.Food where p.FoodIdStudent == id orderby p.FoodId select p).ToListAsync();
            List<viewdetail> vpaidStu = (from s in db.Students
                                               from cl in db.Classes
                                               from en in db.Enroll_student_class.Where(x => s.Student_id == x.Student_id && cl.Class_id == x.Class_id)
                                               from mo in db.Monthlies.Where(x => cl.Class_year_index == x.Month_year)
                                               from enpa in db.Enroll_paid.Where(x => s.Student_id == x.Student_id && mo.Monthly_id == x.Monthly_id).DefaultIfEmpty()
                                               where s.Student_id == Student_id
                                               orderby mo.Monthly_id descending
                                               select new viewdetail
                                               {
                                                   Student_id = s.Student_id,
                                                   Student_title = s.Student_title,
                                                   Student_name = s.Student_name ?? "",
                                                   Student_lname = s.Student_lname,
                                                   Month_name = mo.Month_name,
                                                   Month_year = mo.Month_year,
                                                   Month_yearindex=mo.Month_yearindex,
                                                   Month_course = mo.Month_course,
                                                   Class_id = cl.Class_id,
                                                   Status = cl.Status_class,
                                                   Class_name_id = cl.Class_name_id,
                                                   Teacher_id = cl.Teacher_id,
                                                   Class_room = cl.Class_room,
                                                   Class_year_index = cl.Class_year_index,
                                                   Paid_id = enpa.Paid_id,
                                                   Paid = enpa.Paid == null ? 0 : enpa.Paid,
                                                   Monthly_id = mo.Monthly_id,
                                                   //Timestamp = enpa.Timestamp.HasValue ? enpa.Timestamp : DateTime.Parse("19/02/1989"),
                                                   Staff_paid_id = enpa.Staff_paid_id == null ? 0 : enpa.Staff_paid_id
                                               }).ToList();

            if (vpaidStu == null)
            {
                // return NotFound();
            }
            return View(vpaidStu);
        }




        public async Task<ActionResult> paid(int Student_id)
        {
            if (Student_id == 0)
            {
                //  return NotFound();

            }
            List<viewPaid> vpaidBystu = VpaidBystuFun(Student_id).Where(x => x.Month_course - x.totalPaid != 0).ToList();
            if (vpaidBystu == null)
            {
                //  return NotFound();
            }
            return View(vpaidBystu.OrderBy(x => x.Monthly_id));
            //vpaidStu.GroupBy(x => x.Monthly_id).Select(x=>new {col1=x.Key(y=>y.)
        }
        public List<viewPaid> VpaidBystuFun(int Student_id)
        {
            List<viewdetail> vpaidStu = (from s in db.Students
                                         from cl in db.Classes
                                         from en in db.Enroll_student_class.Where(x => s.Student_id == x.Student_id && cl.Class_id == x.Class_id)
                                         from mo in db.Monthlies.Where(x => cl.Class_year_index == x.Month_year)
                                         from enpa in db.Enroll_paid.Where(x => s.Student_id == x.Student_id && mo.Monthly_id == x.Monthly_id).DefaultIfEmpty()
                                         where s.Student_id == Student_id
                                         orderby mo.Monthly_id descending
                                         select new viewdetail
                                         {
                                             Student_id = s.Student_id,
                                             Student_title = s.Student_title,
                                             Student_name = s.Student_name ?? "",
                                             Student_lname = s.Student_lname,
                                             Month_name = mo.Month_name,
                                             Month_year = mo.Month_year,
                                             Month_yearindex =mo.Month_yearindex,
                                             Month_course = mo.Month_course,
                                             Class_id = cl.Class_id,
                                             Status = cl.Status_class,
                                             Class_name_id = cl.Class_name_id,
                                             Teacher_id = cl.Teacher_id,
                                             Class_room = cl.Class_room,
                                             Class_year_index = cl.Class_year_index,
                                             Paid_id = enpa.Paid_id,
                                             Paid = enpa.Paid == null ? 0 : enpa.Paid,
                                             Monthly_id = mo.Monthly_id,
                                             //Timestamp = enpa.Timestamp.HasValue ? enpa.Timestamp : DateTime.Parse("19/02/1989"),
                                             Staff_paid_id = enpa.Staff_paid_id == null ? 0 : enpa.Staff_paid_id
                                         }).ToList();
            List<viewPaid> vpaidBystu = (vpaidStu.GroupBy(x => x.Monthly_id)
                                                .Select(y => new viewPaid
                                                {

                                                    Student_id = y.FirstOrDefault().Student_id.HasValue?y.FirstOrDefault().Student_id.Value:0,
                                                    Student_title = y.FirstOrDefault().Student_title,
                                                    Student_name = y.FirstOrDefault().Student_name,
                                                    Student_lname = y.FirstOrDefault().Student_lname,
                                                    Month_name = y.FirstOrDefault().Month_name,
                                                    Month_year = y.FirstOrDefault().Month_year,
                                                    Month_yearindex=y.FirstOrDefault().Month_yearindex,
                                                    Month_course = y.FirstOrDefault().Month_course,
                                                    Class_id = y.FirstOrDefault().Class_id.HasValue?y.FirstOrDefault().Class_id.Value:0,
                                                    Status = y.FirstOrDefault().Status,
                                                    Class_name_id = y.FirstOrDefault().Class_name_id,
                                                    Teacher_id = y.FirstOrDefault().Teacher_id,
                                                    Class_room = y.FirstOrDefault().Class_room,
                                                    Class_year_index = y.FirstOrDefault().Class_year_index,
                                                    Paid_id = y.FirstOrDefault().Paid_id,
                                                    totalPaid = y.Sum(x => x.Paid) == null ? 0 : y.Sum(x => x.Paid),
                                                    Monthly_id = y.FirstOrDefault().Monthly_id

                                                })

                                               ).ToList();
            return vpaidBystu;
        }
        public List<viewPaid> VpaidFun()
        {
            
            List<viewdetail> vpaidStu = (from s in db.student2561_food
                                         
                                         from cl in db.Classes
                                         from en in db.Enroll_student_class.Where(x => s.Student_id == x.Student_id && cl.Class_id == x.Class_id)

                                         from mo in db.Monthlies.Where(x => cl.Class_year_index == x.Month_year)
                                         from enpa in db.Enroll_paid.Where(x => s.Student_id == x.Student_id && mo.Monthly_id == x.Monthly_id).DefaultIfEmpty()
                                             //where s.Student_id == Student_id
                                         orderby mo.Monthly_id descending
                                         select new viewdetail
                                         {
                                             Student_id = s.Student_id,
                                             Student_title = s.Student_title,
                                             Student_name = s.Student_name ?? "",
                                             Student_lname = s.Student_lname,
                                             Month_name = mo.Month_name,
                                             Month_year = mo.Month_year,
                                             Month_course = mo.Month_course,
                                             Month_yearindex=mo.Month_yearindex,
                                             Class_id = s.Class_id,
                                             Class_name_id = s.Class_name_id,
                                             Teacher_id = s.Teacher_id,
                                             Class_room = s.Class_room,
                                             Class_year_index = s.Class_year_index,
                                             Paid_id = enpa.Paid_id,
                                             Paid = enpa.Paid == null ? 0 : enpa.Paid,
                                             Monthly_id = mo.Monthly_id,
                                             //Timestamp = enpa.Timestamp.HasValue ? enpa.Timestamp : DateTime.Parse("19/02/1989"),
                                             Staff_paid_id = enpa.Staff_paid_id == null ? 0 : enpa.Staff_paid_id
                                         }).ToList();
            List<viewPaid> vpaidBystu = (vpaidStu.GroupBy(x => new { x.Monthly_id, x.Student_id })

                                                .Select(y => new viewPaid
                                                {

                                                    Student_id = y.FirstOrDefault().Student_id.HasValue ? y.FirstOrDefault().Student_id.Value : 0,
                                                    Student_title = y.FirstOrDefault().Student_title,
                                                    Student_name = y.FirstOrDefault().Student_name,
                                                    Student_lname = y.FirstOrDefault().Student_lname,
                                                    Month_name = y.FirstOrDefault().Month_name,
                                                    Month_year = y.FirstOrDefault().Month_year,
                                                    Month_yearindex=y.FirstOrDefault().Month_yearindex,
                                                    
                                                    Month_course = y.FirstOrDefault().Month_course,
                                                        // mustPay=y.FirstOrDefault().Month_course-( y.Sum(x => x.Paid) == null ? 0 : y.Sum(x => x.Paid)),
                                                        Class_id = y.FirstOrDefault().Class_id.HasValue ? y.FirstOrDefault().Class_id.Value : 0,
                                                    Status = y.FirstOrDefault().Status,
                                                    Class_name_id = y.FirstOrDefault().Class_name_id,
                                                    Teacher_id = y.FirstOrDefault().Teacher_id,
                                                    Class_room = y.FirstOrDefault().Class_room,
                                                    Class_year_index = y.FirstOrDefault().Class_year_index,
                                                    Paid_id = y.FirstOrDefault().Paid_id,
                                                    totalPaid = y.Sum(x => x.Paid) == null ? 0 : y.Sum(x => x.Paid),
                                                    Monthly_id = y.FirstOrDefault().Monthly_id

                                                })

                                               ).ToList();
                return vpaidBystu.Where(x => x.Month_course - x.totalPaid != 0).ToList();
        }
        [AllowAnonymous]
        public ActionResult invoiceAllStudent()
        {

            List<viewPaid> vpaid = VpaidFun();
            ViewPrintInvoise detailinvoice = new ViewPrintInvoise();
            int themStudent_id = 0;
            List<viewPaid> vPaidByStudent = new List<viewPaid>();

            foreach (var item in vpaid.OrderBy(c => c.Student_id).ThenBy(n => n.Monthly_id))
            {
                if (themStudent_id != item.Student_id && themStudent_id != 0)
                {
                    var detaiilStudent = (from st in db.Students.Where(x => x.Student_id == themStudent_id)
                                          join encl in db.Enroll_student_class on st.Student_id equals encl.Student_id into encll
                                          from encl in encll.DefaultIfEmpty()
                                          join cl in db.Classes on encl.Class_id equals cl.Class_id into clli
                                          from cl in clli.DefaultIfEmpty()
                                          //orderby st.
                                          select new studentNow
                                          {
                                              Student_id = st.Student_id,
                                              Student_title = st.Student_title,
                                              Student_name = st.Student_name,
                                              Student_lname = st.Student_lname,
                                              Student_birthday = st.Student_birthday,
                                              Student_idcard = st.Student_idcard,
                                              Student_psis_id = st.Student_psis_id,
                                              Student_status = st.Student_status,
                                              Class_id = cl.Class_id,
                                              Status = cl.Status_class,
                                              Class_name_id = cl.Class_name_id,
                                              Teacher_id = cl.Teacher_id,
                                              Class_room = cl.Class_room,
                                              Class_year_index = cl.Class_year_index
                                          }).ToList().OrderByDescending(x => x.Class_id).FirstOrDefault();
                    themStudent_id = item.Student_id;
                    if (detailinvoice.detailStudent == null)
                    {
                        //It's null - create it
                        detailinvoice.detailStudent = new List<studentNow>();
                    }
                    if (detailinvoice.studentInvoise == null)
                    {
                        //It's null - create it
                        detailinvoice.studentInvoise = new List<List<viewPaid>>();
                    }
                    detailinvoice.detailStudent.Add(detaiilStudent);
                    detailinvoice.studentInvoise.Add(vPaidByStudent);
                    vPaidByStudent = new List<viewPaid>();
                }
                //else
                //{
                vPaidByStudent.Add(item);
                themStudent_id = item.Student_id;
                //}


                // detailinvoice.studentInvoise.(item);
            }

            ViewBag.TotalStudents = detailinvoice;

            //return new ViewAsPdf("invoiceAllStudent", detailinvoice)
            return new ViewAsPdf()
            {
                PageSize = Rotativa.Options.Size.A4,
                // PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };
            //if (vpaid == null)
            //{
            //    return NotFound();
            //}
            //return View(detailinvoice);
            //vpaidStu.GroupBy(x => x.Monthly_id).Select(x=>new {col1=x.Key(y=>y.)
        }
        
        public List<viewdetail> VpaidBystubyMonId(int monId)
        {

            List<viewdetail> vpaidStu = (from enpa in db.Enroll_paid.Where(x => x.Pay_id == monId)
                                         join st in db.Students on enpa.Student_id equals st.Student_id into stl
                                         from st in stl.DefaultIfEmpty()
                                         from encl in db.Enroll_student_class.Where(x => st.Student_id == x.Student_id && enpa.Class_id == x.Class_id)
                                         join cl in db.Classes on encl.Class_id equals cl.Class_id into cll
                                         from cl in cll.DefaultIfEmpty()
                                         join mo in db.Monthlies on enpa.Monthly_id equals mo.Monthly_id into mol
                                         from mo in mol.DefaultIfEmpty()
                                         select new viewdetail
                                         {
                                             Student_id = st.Student_id

                                       ,
                                             Student_title = st.Student_title,
                                             Student_name = st.Student_name ?? "",
                                             Student_lname = st.Student_lname,
                                             Student_id_card = st.Student_idcard,
                                             Student_psis_id = st.Student_psis_id,
                                             Month_name = mo.Month_name,
                                             Month_year = mo.Month_year,
                                             Month_course = mo.Month_course,
                                             Class_id = cl.Class_id,
                                             Status = cl.Status_class,
                                             Class_name_id = cl.Class_name_id,
                                             Teacher_id = cl.Teacher_id,
                                             Class_room = cl.Class_room,
                                             Class_year_index = cl.Class_year_index,
                                             Paid_id = enpa.Paid_id,
                                             Paid = enpa.Paid == null ? 0 : enpa.Paid,
                                             Monthly_id = mo.Monthly_id,
                                             Pay_id=enpa.Pay_id,
                                             //Timestamp = enpa.Timestamp.HasValue ? enpa.Timestamp : DateTime.Parse("19/02/1989"),
                                             Staff_paid_id = enpa.Staff_paid_id == null ? 0 : enpa.Staff_paid_id
                                         }).ToList();

            return vpaidStu;
        }
        public async Task<ActionResult> ViewDetail()
        {
            var ps = await (from p in db.Students orderby p.Student_id select p).ToListAsync();
            var ps2 = await (from en in db.Enroll_student_class
                             join cl in db.Classes on en.Class_id equals cl.Class_id
                             where cl.Class_year_index == 2561
                             select new { cl, en.Student_id } into intermediate
                             join st in db.student2561_food on intermediate.Student_id equals st.Student_id

                             select new ViewStudentClass { students = st, Class2 = intermediate.cl }).ToListAsync();
            return View(ps2);
        }
        [HttpPost]
        public ActionResult AddPaidStudent(AddPaidStudent model1)
        {
            int idPay = 0;
            if (model1.MonthIdAndPaid != null)
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var cousePay = (from p in db.Monthlies select p).ToList();
                    var EnrollPay = new Enroll_pay
                    {
                        Student_id = model1.Student_id,
                        Pay = model1.numPaid,
                        Timestamp = DateTime.Now,
                        Id_token=  Guid.NewGuid().ToString()

        };
                    db.Enroll_pay.Add(EnrollPay);
                    db.SaveChanges();
                   // var idPayFir = db.Enroll_pay.Where(x => x.Timestamp> EnrollPay.Timestamp).SingleOrDefault() ?.Paid_id;
                    var idPayFir = db.Enroll_pay.Where(x => x.Id_token == EnrollPay.Id_token).Select(x => x.Pay_id).FirstOrDefault();
                    //var idPayFir = (from x in db.Enroll_pay where x.Timestamp == EnrollPay.Timestamp select x.Pay_id);
                    List<viewPaid> couseUnpay = VpaidBystuFun(model1.Student_id);
                    idPay = idPayFir;
                    int stuPay = model1.numPaid;
                    int pay = 0;
                    if (model1.MonthIdAndPaid.Length > 0)
                    {

                        foreach (int i in model1.MonthIdAndPaid)
                        {
                            var MonthCouse = couseUnpay.Where(x => x.Monthly_id == i).Select(x => x.Month_course).Single();
                            var Class_id = couseUnpay.Where(x => x.Monthly_id == i).Select(x => x.Class_id).Single();
                            var sumPaid = MonthCouse - couseUnpay.Where(x => x.Monthly_id == i).Select(x => x.totalPaid).Single();
                            if (stuPay > sumPaid)
                            {
                                pay = (int)sumPaid;
                                stuPay = stuPay - (int)sumPaid;
                            }
                            else if (stuPay == 0)
                            {
                                break;
                            }
                            else
                            {
                                pay = stuPay;
                                stuPay = 0;
                            }
                            var enrollPaid = new Enroll_paid
                            {


                                Student_id = model1.Student_id,
                                Monthly_id = i,
                                Timestamp = DateTime.Now,
                                Student_type_id = 1,
                                Paid = pay,
                                Pay_id = idPay,
                                Class_id = Class_id
                            };
                            db.Enroll_paid.Add(enrollPaid);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        foreach (int i in couseUnpay.Select(x => x.Monthly_id))
                        {
                            var MonthCouse = couseUnpay.Where(x => x.Monthly_id == i).Select(x => x.Month_course).Single();
                            var Class_id = couseUnpay.Where(x => x.Monthly_id == i).Select(x => x.Class_id).Single();
                            var sumPaid = MonthCouse - couseUnpay.Where(x => x.Monthly_id == i).Select(x => x.Paid_sum).Single();
                            if (stuPay > sumPaid)
                            {
                                pay = (int)sumPaid;
                                stuPay = stuPay - (int)sumPaid;
                            }
                            else if (stuPay == 0)
                            {
                                break;
                            }
                            else
                            {
                                pay = stuPay;
                                stuPay = 0;
                            }
                            var enrollPaid = new Enroll_paid
                            {


                                Student_id = model1.Student_id,
                                Monthly_id = i,
                                Timestamp = DateTime.Now,
                                Student_type_id = 1,
                                Paid = pay,
                                Pay_id = idPay,
                                Class_id = Class_id

                            };
                            db.Enroll_paid.Add(enrollPaid);
                            db.SaveChanges();
                        }
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }




            return Json(new { idpay = idPay });
        }
        public ActionResult printPaid(int enrollPay_id)
        {
            List<viewdetail> listPay = VpaidBystubyMonId(enrollPay_id);



            return View(listPay);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create(Food food)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Add(food);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewData["foodId"] = new Sel
        //}
        public ActionResult printBill(int enrollPay_id)
        {


            List<viewdetail> listPay = VpaidBystubyMonId(enrollPay_id);
            var detaiilStudent = db.Students.Where(x => x.Student_id == 591)
                                    .Join(db.Enroll_student_class,
                                        st => st.Student_id,
                                        en => en.Student_id,
                                        (st, en) => new
                                        {
                                            St = st,
                                            En = en
                                        })
                                        .Join(db.Classes,
                                            cl => cl.En.Class_id,
                                            sten => sten.Class_id,
                                            (cl, sten) => new
                                            {
                                                Cl = cl,
                                                St = sten
                                            })
                                            .OrderByDescending(x => x.St.Class_id).First();
           var settoviewdetail= new studentNow
           {
                                                Student_id = detaiilStudent.Cl.St.Student_id,
                                                Student_title = detaiilStudent.Cl.St.Student_title,
                                                Student_name = detaiilStudent.Cl.St.Student_name,
                                                Student_lname = detaiilStudent.Cl.St.Student_lname,
                                                Student_birthday = detaiilStudent.Cl.St.Student_birthday,
                                                Student_idcard = detaiilStudent.Cl.St.Student_idcard,
                                                Student_psis_id = detaiilStudent.Cl.St.Student_psis_id,
                                                Student_status = detaiilStudent.Cl.St.Student_status,
                                                Class_id = detaiilStudent.St.Class_id,
                                                Status = detaiilStudent.St.Status_class,
                                                Class_name_id = detaiilStudent.St.Class_name_id,
                                                Teacher_id = detaiilStudent.St.Teacher_id,
                                                Class_room = detaiilStudent.St.Class_room,
                                                Class_year_index = detaiilStudent.St.Class_year_index
                                            };

            ;
            //var detaiilStudent =  db.Students
            //                      .Where(x => x.Student_id == listPay.FirstOrDefault().Student_id)
            //                      .Select(s => s.Student_name)
            //                      .ToList();
            //join encl in db.Enroll_student_class on st.Student_id equals encl.Student_id into encll
            //from encl in encll.DefaultIfEmpty()
            //join cl in db.Classes on encl.Class_id equals cl.Class_id into clli
            //from cl in clli.DefaultIfEmpty()
            //select new studentNow
            //{
            //    Student_id = st.Student_id,
            //    Student_title = st.Student_title,
            //    Student_name = st.Student_name,
            //    Student_lname = st.Student_lname,
            //    Student_birthday = st.Student_birthday,
            //    Student_idcard = st.Student_idcard,
            //    Student_psis_id = st.Student_psis_id,
            //    Student_status = st.Student_status,
            //Class_id = cl.Class_id,
            //Status = cl.Status_class,
            //Class_name_id = cl.Class_name_id,
            //Teacher_id = cl.Teacher_id,
            //Class_room = cl.Class_room,
            //Class_year_index = cl.Class_year_index
            //}).ToList();
            //.OrderByDescending(x => x.Class_id).First();
            BlogViewPrintBill detailBill = new BlogViewPrintBill
            {
                detailStudent = settoviewdetail,
                studentPaid = listPay
            };

            return new ViewAsPdf("printBill", detailBill)
            {
                PageSize = Rotativa.Options.Size.A5,
                // PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };
            //return View(detailBill);
        }
        public ActionResult DemoViewAsPDF()
        {
            return new ViewAsPdf("DemoViewAsPDF")
            {
                PageSize = Rotativa.Options.Size.A5
            };
        }
    }
}