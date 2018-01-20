using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class DiscountsController : EAController
    {
        // GET: Clients
        [EAAuthorize(FunctionName ="Discounts",Writable =false)]
        public ActionResult Index(int? page, string PropName)
        {
            if (PropName?.Length > 0) page = 1;
            return View("Index", base.BaseIndex<DiscountVw>(page,"d.DiscountId, Discountname, i.ItemId,i.ItemName, it.ItemTypeId, it.ItemTypeName, Tfrom, Tto," +
                "Percentage, amount", "Discounts d left join Items i on d.itemId=i.itemId left join ItemTypes it on d.itemTypeId=it.ItemTypeid where ItemName" +
                " like '%" + PropName + "%' or ItemTypeName  like '%" + PropName + "%' order by Tfrom Desc"));
        }

        public ActionResult AutoCompleteItems(string term)
        {
            var filteredItems = db.Fetch<Item>($"Select * from Items where ItemName like '%{term}%'").Select(c => new { id = c.ItemId, value = c.ItemName });
            return Json(filteredItems, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AutoCompleteItemTypes(string term)
        {
            var filteredItems = db.Fetch<ItemType>($"Select * from ItemTypes where ItemTypeName like '%{term}%'").Select(c => new { id = c.ItemTypeId, value = c.ItemTypeName });
            return Json(filteredItems, JsonRequestBehavior.AllowGet);
        }

        // GET: Clients/Create
        [EAAuthorize(FunctionName = "Discounts", Writable = true)]
        public ActionResult Manage(int? id)
        {
            var vwData = base.BaseCreateEdit<Discount>(id, "DiscountID");
            ViewBag.ItemName = MyExtensions.GetItemName(vwData?.ItemId, db);
            ViewBag.ItemTypeName = MyExtensions.GetItemTypeName(vwData?.ItemTypeId, db);
            return View(vwData);
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Discounts", Writable = true)]
        public ActionResult Manage([Bind(Include = "DiscountID,DiscountName,ItemId,ItemTypeId, Tfrom, Tto,Percentage,Amount" )] Discount discount)
        {        
            return base.BaseSave<Discount>(discount, discount.DiscountId>0);         
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
