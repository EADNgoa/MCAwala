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
                var VwData = db.Query<OrderTicket>("Select OTID,TDateTime,RoomNo,TableID,IsVoid from OrderTickets where LocationId=@0 " +
                    "and WaiterId=@1 and CONVERT(date,TDateTime)='" + (string)ViewBag.EDate + "' order by TDateTime desc", LocationId, (UID=="")?User.Identity.GetUserId(): UID);
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
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Order", Writable = true)]
        public void ManageSave([Bind(Include = "OTID,LocationId, TDateTime, WaiterId,TableId,RoomNo,IsVoid,VoidedReason ")] OrderTicket ot)
        {            
            if (ot.IsVoid??false) ot.VoidedBy = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                var r = (ot.OTID > 0) ? db.Update(ot) : db.Insert(ot);                
            }


            //return BaseSave<OrderTicket>(ot, ot.OTID > 0,"Order",new { ot.LocationId,UID=ot.WaiterId,TDate=ot.TDateTime});           

        }


        [HttpGet]
        [EAAuthorize(FunctionName = "Order", Writable = true)]
        public ActionResult Details(int? id)
        {
            return ShowDetails(ref id, null);
        }

        [HttpPost]
        [EAAuthorize(FunctionName = "Order", Writable = true)]
        public ActionResult Details(int? id, int? DetId)
        {
            return ShowDetails(ref id, DetId);
        }

        private ActionResult ShowDetails(ref int? id, int? DetId)
        {
            var vwData = base.BaseCreateEdit<OrderTicketDetail>(DetId, "OTdetailsID") ?? new OrderTicketDetail();
            if (DetId.HasValue)//edit mode
                id = vwData.OTID;

            ViewBag.Order = db.Single<OrderTicket>(id);
            ViewBag.orderDetails = db.Query<OrderDetailsVw>("Select od.*, ItemName as Item from orderTicketDetails od, Items i where od.itemId=i.ItemId and OTID=@0", id);
            ViewBag.ItemName = MyExtensions.GetItemName(vwData?.ItemId, db);
            return PartialView(vwData);
        }

       

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Order", Writable = true)]
        public ActionResult DetailsSave([Bind(Include = "OTDetailsId, OTID,ItemId, Qty,NC,NCtext")] OrderTicketDetail otd)
        {
            //first lets fetch the item price
            otd.Price = db.ExecuteScalar<decimal>("Select Price from Menu where Itemid=@0", otd.ItemId);

            //Get Discounts
            string disct = "";
            otd.Price= MyExtensions.ApplyDiscounts(otd.ItemId.Value,otd.Price.Value, out disct , db);
            otd.Discount = disct;

            if (otd.NC ?? false) otd.NCUserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                var r = (otd.OTdetailsId > 0) ? db.Update(otd) : db.Insert(otd);
                return RedirectToAction("Details", new { id = otd.OTID });
            }

            return RedirectToAction("Details", new { id = otd.OTID });
        }

        

        public ActionResult AutoCompleteItems(string term, int LocationId)
        {
            var filteredItems = db.Fetch<Item>($"Select i.* from Menu m,Items i where m.ItemId=i.ItemId and ItemName like '%{term}%' and m.LocationId=@0", LocationId).Select(c => new { id = c.ItemId, value = c.ItemName });
            return Json(filteredItems, JsonRequestBehavior.AllowGet);
        }

        [EAAuthorize(FunctionName = "Order", Writable = true)]
        public ActionResult Bill(int id, ItemTypesEnum ite)
        {
            ViewBag.Order = db.Single<OrderTicket>(id);
            PetaPoco.Sql sq = new PetaPoco.Sql("Select od.*, ItemName as Item from orderTicketDetails od, Items i where od.itemId=i.ItemId and OTID=@0", id);

            switch (ite)
            {
                case ItemTypesEnum.DrinksNAlc:
                    {
                        sq.Append(" and i.itemTypeId <>@0", ItemTypesEnum.DrinksAlc);
                        break;
                    }
                case ItemTypesEnum.DrinksAlc:
                    {
                        sq.Append(" and i.itemTypeId =@0", ItemTypesEnum.DrinksAlc);
                        break;
                    }
                default:
                    break;
            }

            ViewBag.orderDetails = db.Query<OrderDetailsVw>(sq);
            return View();
        }


        [HttpGet]
        [EAAuthorize(FunctionName = "OrderReceipt", Writable = true)]
        public ActionResult Receipt(int? id)
        {
            return ShowReceipts(ref id, null);
        }

        [HttpPost]
        [EAAuthorize(FunctionName = "OrderReceipt", Writable = true)]
        public ActionResult Receipt(int? id, int? DetId)
        {
            return ShowReceipts(ref id, DetId);
        }

        private ActionResult ShowReceipts(ref int? id, int? RecId)
        {
            var vwData = base.BaseCreateEdit<Reciept>(RecId, "RecieptId") ?? new Reciept();
            vwData.Rdate = DateTime.Now;
            if (RecId.HasValue)//edit mode
               id = vwData.ChargeID;
                        
            ViewBag.PayMode = Enum.GetValues(typeof(PayModesEnum)).Cast<PayModesEnum>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();
            ViewBag.Order = db.Single<OrderTicket>(id);

            ViewBag.RecptDetails = db.Query<Reciept>("Select * from Reciept where ChargeType = @0 and ChargeId=@1",ChargeTypesEnum.Restaurant, id);
            
            return PartialView(vwData);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "OrderReceipt", Writable = true)]
        public ActionResult ReceiptSave([Bind(Include = "RecieptId, RDate,Amount,PayMode,PayDetails,ChargeId")] Reciept reciept)
        {
            if (ModelState.IsValid)
            {
                reciept.ChargeType = (int)ChargeTypesEnum.Restaurant;
                var r = (reciept.RecieptID> 0) ? db.Update(reciept) : db.Insert(reciept);
                return RedirectToAction("Receipt", new { id = reciept.ChargeID});
            }

            return RedirectToAction("Receipt", new { id = reciept.ChargeID});
        }

        [EAAuthorize(FunctionName = "Order", Writable = true)]
        public ActionResult RecptPrint(int id)
        {            
            ViewBag.Receipt = db.Single<Reciept>(id);
            ViewBag.Order = db.Single<OrderTicket>(ViewBag.Receipt.ChargeID);
            
            return View();
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
