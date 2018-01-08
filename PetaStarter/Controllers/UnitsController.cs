using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class UnitsController : EAController
    {
        // GET: Clients
        [EAAuthorize(FunctionName ="Units",Writable =false)]
        public ActionResult Index(int? page, string PropName)
        {
            if (PropName?.Length > 0) page = 1;
            return View("Index", base.BaseIndex<Unit>(page, "Units where UnitName like '%" + PropName + "%'"));
        }



        // GET: Clients/Create
        [EAAuthorize(FunctionName = "Units", Writable = true)]
        public ActionResult Manage(int? id)
        {
            return View(base.BaseCreateEdit<Unit>(id, "UnitID"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Units", Writable = true)]
        public ActionResult Manage([Bind(Include = "UnitID,UnitName")] Unit unit)
        {
            return base.BaseSave<Unit>(unit, unit.UnitId > 0);
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
