using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class ItemsController : EAController
    {
        // GET: Clients
        [EAAuthorize(FunctionName = "Item", Writable = false)]
        public ActionResult Index(int? page, ItemTypesEnum Ite, string PropName)
        {
            if (PropName?.Length > 0) page = 1;
            ViewBag.iteName = db.ExecuteScalar<string>("Select ItemTypeName from ItemTypes where ItemTypeId=@0", Ite);
            ViewBag.ite = Ite;
            int ItemTypeId = (int)Ite;
            return View("Index", base.BaseIndex<ItemsVw>(page, "ItemID, ItemName, ItemTypeName as Type, ExpiryDays, UnitName as Unit", $"Items i, Units u, ItemTypes t where i.ItemTypeId=t.ItemTypeId and i.itemTypeId = {ItemTypeId} and i.UnitID=u.UnitID and ItemName like '%" + PropName + "%'"));
        }



        // GET: Clients/Create
        [EAAuthorize(FunctionName = "Item", Writable = true)]
        public ActionResult Manage(int? id, ItemTypesEnum? Ite)
        {
            ViewBag.UnitID = new SelectList(db.Fetch<Unit>("Select UnitID,UnitName from Units"), "UnitID", "UnitName");
            ViewBag.ite = Ite;
            ViewBag.ItemTypeID = new SelectList(db.Fetch<ItemType>("Select ItemTypeID,ItemTypeName from ItemTypes"), "ItemTypeID", "ItemTypeName");
            return View(base.BaseCreateEdit<Item>(id, "ItemID"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Item", Writable = true)]
        public ActionResult Manage([Bind(Include = "ItemID,ItemName,ItemTypeId, ExpiryDays,UnitID")] Item item)
        {
            return base.BaseSave<Item>(item, item.ItemId > 0,new { Ite=item.ItemTypeId});
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
