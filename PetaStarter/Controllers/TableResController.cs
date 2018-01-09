using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class TableResController : EAController
    {
        [EAAuthorize(FunctionName = "Table Res", Writable = false)]
        public ActionResult Index(int? Lid)
        {
            ViewBag.Lid=Lid;
            ViewBag.LoID = new SelectList(db.Fetch<Location>("Select LocationID,LocationName from Location where LocationTypeId=@0", LocationTypesEnum.Restaurant), "LocationID", "LocationName");
            return View();
        }


        [EAAuthorize(FunctionName = "Table Res", Writable = false)]
        public ActionResult TableList(int LocationId)
        {
            ViewBag.Lid = LocationId;
            return PartialView("TableList", base.BaseIndex<TableResVw>(1, "r.TableReservationId,t.TableId, t.TableName,r.TDateTime as ResTime,r.PersonName", $" TableReservation r right Outer Join [Tables] t on t.TableId=r.TableId and convert(varchar(11),r.TDateTime,120) >='{DateTime.Now.ToString("yyyy,MMM,dd")}' where t.LocationId ={LocationId} order by TableName ASC, r.TDateTime desc"));
        }
                
        
        [EAAuthorize(FunctionName = "Table Res", Writable = true)]
        public ActionResult Manage(int? id,int Lid)
        {
            ViewBag.TableId = new SelectList(db.Fetch<Table>("Select TableId,TableName from Tables where LocationId=@0", Lid), "TableId", "TableName");
            return View(base.BaseCreateEdit<TableReservation>(id, "TableReservationId"));
        }

        [EAAuthorize(FunctionName = "Table Res", Writable = true)]
        public ActionResult Create(int? id, int TableId)
        {
            var tr = base.BaseCreateEdit<TableReservation>(id, "TableReservationId")?? new TableReservation();

            tr.TableId = TableId;
            return View("Manage",tr);
        }



        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Table Res", Writable = true)]
        public ActionResult Manage([Bind(Include = "TableReservationId,TableId,TDateTime,PersonName,Contact,NoOfPax")] TableReservation t)
        {
            return base.BaseSave<TableReservation>(t, t.TableReservationId> 0,new { Lid = db.ExecuteScalar<int>("Select LocationId from Tables where tableId=@0",t.TableId)});
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
