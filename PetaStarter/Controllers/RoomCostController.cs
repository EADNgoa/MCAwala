using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Cavala.Controllers
{
    public class RoomCostController : EAController
    {
        // GET: Clients
        [EAAuthorize(FunctionName = "Room Cost", Writable = false)]
        public ActionResult Index(int? page, string PropName)
        {
            if (PropName?.Length > 0) page = 1;
            return View();
        }




        // GET: Clients/Create
        [EAAuthorize(FunctionName = "Room Cost", Writable = true)]
        public ActionResult Manage(int? id)
        {
            return View(base.BaseCreateEdit<ReservationDetail>(id, "ReservationID"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Room Cost", Writable = true)]
        public ActionResult Manage(FormCollection fm)
        {
            using (var transaction = db.GetTransaction())
            {
                try
                {
                    int resID = int.Parse(fm["ReservationID"]);
                    decimal Qty = int.Parse(fm["Qty"]);
                    decimal fixQty = Qty;
                    int ItemID = db.FirstOrDefault<int>("Select ItemId from Items Where ItemName ='Room Water Bottle' and ItemTypeId='3'");
                    decimal wbPrice = db.FirstOrDefault<decimal>("Select Price From Menu Where LocationId='2' and ItemId=@0", ItemID);
                    int lid = db.FirstOrDefault<int>("Select LocationId from Location Where LocationName ='Room Service' and LocationTypeId =@0", 1);
                    var FsExist = db.Fetch<FoodStock>("Select * From FoodStock Where ItemId =@0 and LocationId=@1 and Qty > 0 Order By Tdate asc ", ItemID, lid);
                    bool QtyChk = true;
                    decimal QtyMatch = 0;
                    if (FsExist.Count > 0)
                    {
                        foreach (var item in FsExist)
                        {
                            if (QtyChk == true)
                            {
                                if (item.Qty >= Qty)
                                {
                                    item.Qty -= Qty;
                                    QtyChk = false;
                                    db.Execute($"Update FoodStock set Qty ={item.Qty} Where FoodStockID = {item.FoodStockId}");
                                    break;

                                }
                                else
                                {
                                    QtyMatch = 0;
                                    QtyMatch += item.Qty;
                                    Qty = Qty - item.Qty;
                                    item.Qty -= QtyMatch;
                                    db.Execute($"Update FoodStock set Qty ={item.Qty} Where FoodStockId = {item.FoodStockId}");

                                }

                            }
                        }



                        var inv = new InventoryTransaction
                        {
                            TDate = DateTime.Now,
                            QtyRemoved = fixQty,
                            FromLocationId = 1,//Room Service
                            RecvdByUserId = User.Identity.GetUserId(),
                            UnitId = 1,//Pieces
                            ItemId = ItemID,
                            FoodStockId = FsExist.First().FoodStockId
                        };
                        db.Insert(inv);
                        int ExQty = db.FirstOrDefault<int>("Select Sum(Qty) as Qty From ReservationDetails Where ChargeID = @0 and ItemID = @1 and RDdate =@2 Group By ChargeID,ItemID", resID, ItemID, DateTime.Now.Date);
                        decimal amt = 0;
                        if (ExQty <= 2)
                        {
                            if (fixQty > 2)
                            {
                                Qty = Qty - 2;
                                amt = wbPrice * Qty;
                            }
                            else
                            {
                                amt = 0;
                            }
                        }
                        else
                        {
                            amt = wbPrice * Qty;
                        }
                        var rd = new ReservationDetail
                        {
                            RDdate = inv.TDate,
                            ChargeID = resID,
                            ChargeType = 2,
                            Description = "Room Water Bottle",
                            Qty = (int)fixQty,
                            ItemID = ItemID,
                            Amount = amt

                        };

                        db.Insert(rd);
                        transaction.Complete();
                    }
                    else
                    {
                        throw new HttpRequestValidationException("Error: Insufficient Quantity in Stock!");

                    }
                }
                catch (Exception ex)
                {
                    db.AbortTransaction();
                    throw ex;
                }
            }

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
