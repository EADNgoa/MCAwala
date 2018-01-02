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
            return View("Receipt", base.BaseIndex<InvReceiptVw>(page, "InventoryTransactionID, TDate,QtyAdded, ItemName, RecvdByUserId,ChkByUserId, au.userName as RecvdBy,auc.UserName as ChkBy, UnitName  ",
                "Items i, Aspnetusers au, Units u, InventoryTransaction it left outer join Aspnetusers auc  on it.ChkByUserId = auc.id  where it.itemId=i.itemId and it.RecvdByUserId = au.id and it.UnitId=u.UnitId " +
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
            ViewBag.UnitID = new SelectList(db.Fetch<Unit>("Select UnitID,UnitName from Units"), "UnitID", "UnitName");

            return View(vwData);
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Inventory Receipts", Writable = true)]
        public ActionResult Manage([Bind(Include = "InventoryTransactionId,TDate, ItemId, QtyAdded,ToLocationId,RecvdByUserId,ChkByUserId,UnitId")] InventoryTransaction it, int ItemTypeId)
        {
            using (var transaction = db.GetTransaction())
            {
                try
                {
                    decimal OldTransQty=0;

                    if (it.InventoryTransactionId == 0)//create mode
                    {
                        it.RecvdByUserId = User.Identity.GetUserId();

                        //If the current user is the dept head then auto check 
                        //it.ChkByUserId = MyExtensions.IsPermitted(db, "Inventory Checking", true, it.RecvdByUserId) ? it.RecvdByUserId : null;
                    } else
                        OldTransQty = db.ExecuteScalar<decimal>("Select QtyAdded from InventoryTransaction where InventoryTransactionId=@0",it.InventoryTransactionId);

                    it.TDate = DateTime.Today;

                    //Update stock
                    var ExistStock = db.SingleOrDefault<FoodStock>("select * from FoodStock where ItemId = "+ it.ItemId+" and locationId="+it.ToLocationId+" and UnitId="+it.UnitId+" and TDate='" + String.Format("{0:yyyy-MM-dd}",it.TDate) +"' ");
                    int fsid;
                    if (ExistStock == null)
                        fsid=(int)db.Insert(new FoodStock { TDate=it.TDate, ItemId = it.ItemId, LocationId = (int)it.ToLocationId, Qty= (decimal)it.QtyAdded.Value, UnitId = it.UnitId });
                    else
                    {
                        ExistStock.Qty += ((decimal)it.QtyAdded - OldTransQty);
                        fsid = ExistStock.FoodStockId;
                        db.Update(ExistStock);
                    }
                        

                    if (ModelState.IsValid)
                    {
                        var r = (it.InventoryTransactionId > 0) ? db.Update(it) : db.Insert(it);
                        transaction.Complete();
                        db.Execute($"Update FoodStock set InventoryTransactionId={it.InventoryTransactionId} where FoodStockId={fsid}");
                    }
                    return RedirectToAction("Receipt", new { LocationId = it.ToLocationId, Ite = ItemTypeId, EDate = it.TDate });
                }
                catch (Exception ex)
                {
                    db.AbortTransaction();
                    throw ex;
                }

            }
            
        }

        [EAAuthorize(FunctionName = "Inventory Portion", Writable = false)]
        public ActionResult Portion(int? id, int LocationId, ItemTypesEnum? Ite)
        {
            PreparePortion(id, LocationId, Ite);
            return View();
        }

        private void PreparePortion(int? id, int LocationId, ItemTypesEnum? Ite)
        {
            ViewBag.ITrecd = db.SingleOrDefault<InvReceiptVw>("Select InventoryTransactionID, it.ItemId, TDate,QtyAdded, ItemName, UnitName  from " +
                            "Items i, Units u, InventoryTransaction it where it.itemId=i.itemId and it.UnitId=u.UnitId " +
                            "and it.InventoryTransactionId =@0", id);
            ViewBag.Portions = db.Query<FoodStockVw>("Select FoodstockId, LocationName, Qty,Size, UnitName from FoodStock fs, Location l, Units u where fs.UnitId=u.UnitId and l.LocationId=fs.LocationId and InventoryTransactionId=@0 and LocationTypeId=@1", id, (int)LocationTypesEnum.Fridge);
            ViewBag.ite = Ite;
            ViewBag.lid = LocationId;
            ViewBag.UnitID = new SelectList(db.Fetch<Unit>("Select UnitID,UnitName from Units"), "UnitID", "UnitName");
            ViewBag.LocationID = new SelectList(db.Fetch<Location>("Select LocationID,LocationName from Location where LocationTypeId=@0", LocationTypesEnum.Fridge), "LocationID", "LocationName");
        }

        [EAAuthorize(FunctionName = "Inventory Portion", Writable = true)]
        public ActionResult ManagePortion(int? id, int LocationId, ItemTypesEnum? Ite)
        {
            var InvTrnid = db.ExecuteScalar<int>("Select InventoryTransactionId from FoodStock where FoodStockId=@0", id);
            PreparePortion(InvTrnid, LocationId, Ite);

            var locked = db.ExecuteScalar<int>("select count(*) from InventoryTransaction where FoodStockId=@0", id);
            if (locked == 0)//Portion has been consumed or transfered
            {
                return View("Portion", base.BaseCreateEdit<FoodStock>(id, "FoodStockID"));
            }
            else
            {
                ViewBag.Lockedrec = "Sorry this postion has already been consumed or transfered and hence cannot be edited anymore";
                return View("Portion");
            }
        }

        [HttpPost]
        [EAAuthorize(FunctionName = "Inventory Portion", Writable = true)]
        public ActionResult ManagePortion([Bind(Include = "FoodStockId, InventoryTransactionId,TDate, ItemId, Qty, Size,UnitId, LocationId")] FoodStock fs, ItemTypesEnum ItemTypeId,int LocationId)
        {
            using (var transaction = db.GetTransaction())
            {
                try
                {
                    //fetch the conversion
                    var Existstk = db.SingleOrDefault<FoodStock>("select * from FoodStock where ItemId = " + fs.ItemId + " and locationId=" + LocationId + " and InventoryTransactionId=" + fs.InventoryTransactionId + " and TDate='" + String.Format("{0:yyyy-MM-dd}", fs.TDate) + "' ");
                    var conv = db.FirstOrDefault<UnitConversion>("Select * from UnitConversion Where AUnitOfId = @0 and OfUnitId=@1", fs.UnitId, Existstk.UnitId);

                    Existstk.Qty = Existstk.Qty - ((fs.Qty * fs.Size) * conv.IsJust);
                    Existstk.UnitId = fs.UnitId;
                    db.Update(Existstk);

                    BaseSave<FoodStock>(fs, fs.FoodStockId > 0);
                    
                    transaction.Complete();
                    return RedirectToAction("Portion", new { id = fs.InventoryTransactionId, LocationId = LocationId, Ite = ItemTypeId });
                }
                catch (Exception ex)
                {
                    db.AbortTransaction();
                    throw ex;
                }

            }
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
