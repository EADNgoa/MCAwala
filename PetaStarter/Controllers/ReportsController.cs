using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


/// <summary>
/// Flags for generating the report reqest
///     ViewBag.PeriodID = new SelectList(db.PeriodSLs, "PeriodID", "PeriodSL1");
///     ViewBag.YearBox = MyExtensions.MakeYrRq(3, 1, DateTime.Today.Year);
///     ViewBag.MonthBox = MyExtensions.MonthList();
///     ViewBag.FromDate = 1;
///     ViewBag.ToDate = 1;
///     ViewBag.SubLedger = 1;
///     ViewBag.IsIncome = new List<SelectListItem>() { new SelectListItem() { Value = "True", Text = "Receipts" }, new SelectListItem() { Value = "False", Text = "Expenditure" } };
///     
/// </summary>

namespace Cavala.Controllers
{
    public class ReportsController : EAController
    {
        [EAAuthorize(FunctionName = "Wastage Report", Writable = false)]
        public ActionResult Wastage()
        {
            ViewBag.FromDate = 1;
            ViewBag.ToDate = 1;
            ViewBag.ReturnAction = "Wastage";
            ViewBag.Title = "Kitchen Wastage";

            return View("ReportRq");
        }

        [HttpPost]
        [EAAuthorize(FunctionName = "Wastage Report", Writable = false)]
        [ValidateAntiForgeryToken]
        public ActionResult Wastage(DateTime FromDate, DateTime ToDate)
        {
            if (ModelState.IsValid)
            {
                ViewBag.FromDate = String.Format("{0:dd-MMM-yyyy}", FromDate);
                ViewBag.ToDate = String.Format("{0:dd-MMM-yyyy}", ToDate);

                Sql sq = new Sql("Select it.TDate,QtyAdded, ItemName, RecvdByUserId,ChkByUserId, au.userName as RecvdBy, u.UnitName, fs.Qty as Wastage, uw.UnitName as WastageUnitName  from " +
                "Items i, Aspnetusers au, Units u, Units uw, InventoryTransaction it, FoodStock fs  where it.itemId=i.itemId and it.RecvdByUserId = au.id and it.UnitId=u.UnitId and " +
                " it.InventoryTransactionId = fs.InventoryTransactionId and it.ToLocationId = fs.LocationId and fs.UnitId=uw.UnitId " +
                " and it.TDate between @0 and @1", String.Format("{0:yyyy-MM-dd}", FromDate), String.Format("{0:yyyy-MM-dd}", ToDate));
                var vwData = db.Query<InvReceiptVw>(sq);
                return View("Wastage", vwData);
            }
            else
            {
                throw new HttpRequestValidationException("Error in selected parameters");                
            }
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
