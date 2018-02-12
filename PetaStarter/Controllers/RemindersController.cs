using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class ReminderController : EAController
    {
        // GET: Clients
        [EAAuthorize(FunctionName ="Reminders",Writable =false)]
        public ActionResult Index(int? page)
        {
            page = 1;
            return View("Index", base.BaseIndex<Reminder>(page, "Reminders "));
        }



        // GET: Clients/Create
        [EAAuthorize(FunctionName = "Reminders", Writable = true)]
        public ActionResult Manage(int? id)
        {
            return View(base.BaseCreateEdit<Reminder>(id, "ReminderID"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Reminders", Writable = true)]
        public ActionResult Manage([Bind(Include = "ReminderID,Tdate,Description")] Reminder reminder)
        {
            return base.BaseSave<Reminder>(reminder, reminder.ReminderID > 0);
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
