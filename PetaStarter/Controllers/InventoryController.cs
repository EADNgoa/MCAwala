using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Cavala.Controllers
{
    public class InventoryController : EAController
    {
        // GET: Clients
        [EAAuthorize(FunctionName = "Inventory Receipts", Writable = false)]
        public ActionResult Receipt(int LocationId, int? page, ItemTypesEnum Ite, string PropName, DateTime? EDate)
        {
            if (PropName?.Length > 0) page = 1;
            ViewBag.iteName = db.ExecuteScalar<string>("Select ItemTypeName from ItemTypes where ItemTypeId=@0", Ite);
            ViewBag.ite = Ite;
            ViewBag.lid = LocationId;
            ViewBag.LocationName = db.ExecuteScalar<string>("Select locationName from Location where LocationId=@0", LocationId);
            ViewBag.EDate = EDate ?? DateTime.Today;            
            return View("Receipt", base.BaseIndex<InvReceiptVw>(page, "InventoryTransactionID, TDate,QtyAdded, ItemName, RecvdByUserId,ChkByUserId, au.userName as RecvdBy,auc.UserName as ChkBy  ",
                "Items i, Aspnetusers au, InventoryTransaction it left outer join Aspnetusers auc  on it.ChkByUserId = auc.id  where it.itemId=i.itemId and it.RecvdByUserId = au.id " +
                "and ItemName like '%" + PropName + "%'" + ((EDate!=null)? " and TDate='" + String.Format("{0:yyyy-MM-dd}", EDate) + "'" :"")));
        }

        [EAAuthorize(FunctionName = "Inventory Checking", Writable = true)]
        public ActionResult Checked(int id, int LocationId, ItemTypesEnum? Ite, DateTime? EDate)
        {
            var it = db.Single<InventoryTransaction>("Select * from InventoryTransaction where InventoryTransactionId=@0", id);
            it.ChkByUserId = User.Identity.GetUserId();
            db.Update(it);
            return RedirectToAction("Receipt", new { LocationId = LocationId, Ite = Ite, EDate = EDate });            
        }

        [EAAuthorize(FunctionName = "Inventory Receipts", Writable = true)]
        public ActionResult Manage(int? id, int LocationId, ItemTypesEnum? Ite)
        {            
            ViewBag.ite = Ite;
            ViewBag.lid = LocationId;
            ViewBag.iteName = db.ExecuteScalar<string>("Select ItemTypeName from ItemTypes where ItemTypeId=@0", Ite);
            ViewBag.LocationName = db.ExecuteScalar<string>("Select locationName from Location where LocationId=@0", LocationId);
            var vwData = base.BaseCreateEdit<InventoryTransaction>(id, "InventoryTransactionID");
            ViewBag.ItemName = db.ExecuteScalar<string>("Select ItemName from Items where ItemId=@0", vwData?.ItemId??0)??"";
            
            return View(vwData);
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Inventory Receipts", Writable = true)]
        public ActionResult Manage([Bind(Include = "InventoryTransactionId,TDate, ItemId, QtyAdded,ToLocationId,RecvdByUserId,ChkByUserId")] InventoryTransaction it, int ItemTypeId)
        {
            if (it.InventoryTransactionId == 0) it.RecvdByUserId = User.Identity.GetUserId();

            //If the current user is the dept head then auto check 
            it.ChkByUserId = MyExtensions.IsPermitted(db, "Inventory Checking", true, it.RecvdByUserId) ? it.RecvdByUserId : null;

            it.TDate = DateTime.Today;

            if (ModelState.IsValid)
            {
                var r = (it.InventoryTransactionId > 0) ? db.Update(it) : db.Insert(it);
                return RedirectToAction("Receipt", new { LocationId = it.ToLocationId, Ite = ItemTypeId, EDate = it.TDate });
            }

            return RedirectToAction("Receipt", new { LocationId = it.ToLocationId, Ite = ItemTypeId, EDate = it.TDate});
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
