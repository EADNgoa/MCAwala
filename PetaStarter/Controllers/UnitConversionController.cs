using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class UnitConversionController : EAController
    {
        // GET: Clients
        [EAAuthorize(FunctionName ="Unit Conversion",Writable =false)]
        public ActionResult Index(int? page, string PropName)
        {
            if (PropName?.Length > 0) page = 1;
            return View("Index", base.BaseIndex<UnitConversionVw>(page,"uc.UCId, u1.UnitName as AUnitOf, IsJust, u2.UnitName as OfUnit", "UnitConversion uc, Units u1, Units u2 where  uc.AUnitOfId= u1.unitId and uc.OfUnitId=u2.UnitId and u1.UnitName like '%" + PropName + "%'"));
        }



        // GET: Clients/Create
        [EAAuthorize(FunctionName = "Unit Conversion", Writable = true)]
        public ActionResult Manage(int? id)
        {
            ViewBag.AUnitOfId = new SelectList(db.Fetch<Unit>("Select UnitID,UnitName from Units"), "UnitID", "UnitName");
            ViewBag.OfUnitId = new SelectList(db.Fetch<Unit>("Select UnitID,UnitName from Units"), "UnitID", "UnitName");
            return View(base.BaseCreateEdit<UnitConversion>(id, "UCId"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Unit Conversion", Writable = true)]
        public ActionResult Manage([Bind(Include = "UCId, AUnitOfId, IsJust, OfUnitId")] UnitConversion unitcon)
        {
            return base.BaseSave<UnitConversion>(unitcon, unitcon.UCId > 0);
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
