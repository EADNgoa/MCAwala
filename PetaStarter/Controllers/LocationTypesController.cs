using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class LocationTypesController : EAController
    {
        // GET: Clients
        [EAAuthorize(FunctionName = "LocationType", Writable = false)]
        public ActionResult Index(int? page, string PropName)
        {
            if (PropName?.Length > 0) page = 1;
            return View("Index", base.BaseIndex<LocationType>(page, "LocationTypes where LocationTypeName like '%" + PropName + "%'"));
        }



        // GET: Clients/Create
        [EAAuthorize(FunctionName = "LocationType", Writable = true)]
        public ActionResult Manage(int? id)
        {
            return View(base.BaseCreateEdit<LocationType>(id, "LocationTypeID"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "LocationType", Writable = true)]
        public ActionResult Manage([Bind(Include = "LocationTypeID,LocationTypeName")] LocationType lt)
        {
            return base.BaseSave<LocationType>(lt, lt.LocationTypeId > 0);
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
