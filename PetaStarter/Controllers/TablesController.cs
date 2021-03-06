﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class TablesController : EAController
    {
        // GET: Clients
        [EAAuthorize(FunctionName = "Table", Writable = false)]
        public ActionResult Index(int? page, string PropName)
        {
            if (PropName?.Length > 0) page = 1;
            return View("Index", base.BaseIndex<TablesVw>(page,"TableId, TableName, LocationName", "Tables t, Location l where t.locationId=l.locationId and TableName like '%" + PropName + "%'"));
        }



        // GET: Clients/Create
        [EAAuthorize(FunctionName = "Table", Writable = true)]
        public ActionResult Manage(int? id)
        {
            ViewBag.LocationId = MyExtensions.GetLocations(LocationTypesEnum.Restaurant, db);
            return View(base.BaseCreateEdit<Table>(id, "TableId"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Table", Writable = true)]
        public ActionResult Manage([Bind(Include = "TableId,TableName,LocationId")] Table t)
        {
            return base.BaseSave<Table>(t, t.TableId > 0);
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
