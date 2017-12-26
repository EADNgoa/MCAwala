using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class LocationsController : EAController
    {
        // GET: Clients
        [EAAuthorize(FunctionName = "Location", Writable = false)]
        public ActionResult Index(int? page, string PropName)
        {
            if (PropName?.Length > 0) page = 1;
            return View("Index", base.BaseIndex<LocationVw>(page,"l.LocationId,l.locationName, lt.LocationTypeName" , "Location l, LocationTypes lt where l.LocationTypeId=lt.LocationTypeId and LocationName like '%" + PropName + "%'"));
        }



        // GET: Clients/Create
        [EAAuthorize(FunctionName = "Location", Writable = true)]
        public ActionResult Manage(int? id)
        {
            ViewBag.LocationTypeId = new SelectList(db.Fetch<LocationType>("Select LocationTypeId,LocationTypeName from LocationTypes"), "LocationTypeId", "LocationTypeName");
            return View(base.BaseCreateEdit<Location>(id, "LocationId"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage([Bind(Include = "LocationId,LocationTypeId,LocationName")] Location l)
        {
            return base.BaseSave<Location>(l, l.LocationId > 0);
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
