using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class SecurityGuardController : EAController
    {
        // GET: Clients
        [EAAuthorize(FunctionName ="Security",Writable =false)]
        public ActionResult Index(int? page, string PropName)
        {
            if (PropName?.Length > 0) page = 1;
            return View("Index", base.BaseIndex<SecurityGuard>(page, "SecurityGuard where Name like '%" + PropName + "%'"));
        }



        // GET: Clients/Create
        [EAAuthorize(FunctionName = "Security", Writable = true)]
        public ActionResult Manage(int? id)
        {
            return View(base.BaseCreateEdit<SecurityGuard>(id, "SecurityGuardID"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Security", Writable = true)]
        public ActionResult Manage([Bind(Include = "SecurityGuardID,AttendanceSystemID,Name,Address,Mobile")] SecurityGuard security)
        {
            return base.BaseSave<SecurityGuard>(security, security.SecurityGuardID > 0);
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
