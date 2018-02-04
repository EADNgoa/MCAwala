using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class HomeController : EAController
    {
        public ActionResult Index()
        {
            int rem = db.ExecuteScalar<int>("Select Reminders From Config");
            DateTime td = DateTime.Now;
            DateTime date = td.AddDays(-rem);

            ViewBag.Reminder = db.Fetch<Reminder>("Select * From Reminders Where Tdate =@0",date);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ErrorCust(string err)
        {
            return View(err);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}