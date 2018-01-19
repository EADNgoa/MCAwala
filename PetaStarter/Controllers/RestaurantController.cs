using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Cavala.Controllers
{
    public class RestaurantController : EAController
    {
        [EAAuthorize(FunctionName = "Order", Writable = false)]
        public ActionResult Order(int? LocationId, string UID, DateTime? TDate)
        {
            ViewBag.LoID = MyExtensions.GetLocations(LocationTypesEnum.Restaurant, db, LocationId);
            ViewBag.UID = MyExtensions.GetUsersInGroup("Waiter", db, (UID == "") ? User.Identity.GetUserId() : UID);
            ViewBag.TDate = TDate;
            return View();
        }


        [EAAuthorize(FunctionName = "Order", Writable = false)]
        public ActionResult OrderPart(int LocationId, DateTime? OrderDate, string UID)
        {   
                ViewBag.EDate = String.Format("{0:dd-MMM-yyyy}", OrderDate ?? DateTime.Today);
                var VwData = db.Query<OrderTicket>("Select OTID,TDateTime,RoomNo,TableID from OrderTickets where LocationId=@0 " +
                    "and WaiterId=@1 and CONVERT(date,TDateTime)='" + (string)ViewBag.EDate + "'", LocationId, (UID=="")?User.Identity.GetUserId(): UID);
                ViewBag.lid = LocationId;
                ViewBag.LocationID = MyExtensions.GetLocations(LocationTypesEnum.Restaurant, db);
                ViewBag.UID = MyExtensions.GetUsersInGroup("Waiter", db);
                return PartialView(VwData);         
        }


        [HttpPost]
        [EAAuthorize(FunctionName = "Order", Writable = true)]
        public ActionResult Manage(int? id, int LocationId, DateTime OrderDate, string UID)
        {            
            var vwData = base.BaseCreateEdit<OrderTicket>(id, "OTID")??new OrderTicket();
            ViewBag.LoID = LocationId;
            vwData.TDateTime = vwData.TDateTime?? DateTime.Now;
            ViewBag.UID = (UID=="") ? User.Identity.GetUserId():UID;

            return PartialView(vwData);
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Order", Writable = true)]
        public ActionResult ManageSave([Bind(Include = "OTID,LocationId, TDateTime, WaiterId,TableId,RoomNo,IsVoid,VoidedReason ")] OrderTicket ot)
        {            
            if (ot.IsVoid??false) ot.VoidedBy = User.Identity.GetUserId();
            return BaseSave<OrderTicket>(ot, ot.OTID > 0,"Order",new { LocationId=ot.LocationId,UID=ot.WaiterId,TDate=ot.TDateTime});           

        }
        
        public ActionResult AutoCompleteItems(string term, int ite)
        {
            var filteredItems = db.Fetch<Item>($"Select * from Items where ItemTypeId={ite} and ItemName like '%{term}%'").Select(c => new { id = c.ItemId, value = c.ItemName });
            return Json(filteredItems, JsonRequestBehavior.AllowGet);
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
