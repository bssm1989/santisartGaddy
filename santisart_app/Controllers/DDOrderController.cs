using OfficeOpenXml.FormulaParsing.Excel.Functions.Information;
using santisart_app.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace santisart_app.Controllers
{
    public class DDOrderController : Controller
    {
        // GET: DDOrder
        public ActionResult list()
        {
           
            return View();
        }
        public ActionResult test(string who,String test)
        {
            MyHub Hub = new MyHub();
            Hub.Sendmsg(test, who);
            return View();
        }
    }
}