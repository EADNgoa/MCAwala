using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class BirthdayController : EAController
    {
        // GET: Clients
        [EAAuthorize(FunctionName ="Units",Writable =false)]
        public ActionResult Index(int? page, string PropName)
        {
            if (PropName?.Length > 0) page = 1;
           var res= db.Fetch<AspNetUser>("Select UserName, BirthDate From AspNetUsers where MONTH(BirthDate) = MONTH(GetDate())");

            return View(res);
        }



        // GET: Clients/Create
        [EAAuthorize(FunctionName = "Units", Writable = true)]
        public ActionResult Manage(int? id)
        {
            ViewBag.Id = new SelectList(db.Fetch<AspNetUser>("Select Id,UserName from AspNetUsers"), "Id", "UserName");

            return View(base.BaseCreateEdit<AspNetUser>(id, "Id"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Units", Writable = true)]
        public ActionResult Manage(DateTime? BirthDate,string Id)
        {
            string dt = BirthDate.Value.ToString("yyyy-MM-dd");
          
            db.Execute($"Update AspNetUsers Set BirthDate = '{dt}' where Id = '{Id}'");
            
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
