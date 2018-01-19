using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class MenuController : EAController
    {
        // GET: Clients
        [EAAuthorize(FunctionName ="Menu",Writable =false)]
        public ActionResult Index(int? page, string PropName)
        {
            if (PropName?.Length > 0) page = 1;
            return View("Index", base.BaseIndex<MenuVw>(page,"m.ItemId,ItemName,m.LocationId,LocationName,Price", "Menu m, Items i,Location l where m.locationId=l.LocationId and m.itemId=i.itemId and ItemName like '%" + PropName + "%'"));
        }

        public ActionResult AutoCompleteItems(string term)
        {
            var filteredItems = db.Fetch<Item>($"Select * from Items where ItemTypeId in ({(int)ItemTypesEnum.Menu}, {(int)ItemTypesEnum.RawMaterial}, {(int)ItemTypesEnum.Drinks},{(int)ItemTypesEnum.ReadyToServe}) and ItemName like '%{term}%'").Select(c => new { id = c.ItemId, value = c.ItemName });
            return Json(filteredItems, JsonRequestBehavior.AllowGet);
        }


        // GET: Clients/Create
        [EAAuthorize(FunctionName = "Menu", Writable = true)]
        public ActionResult Manage(int? Itemid,int? LocationId)
        {
            ViewBag.LocationID = MyExtensions.GetLocations(LocationTypesEnum.Restaurant, db);
            if (Itemid.HasValue && Itemid>0 && LocationId.HasValue) //is edit            
            {
                ViewBag.ItemName = MyExtensions.GetItemName(Itemid, db);
                return View(db.SingleOrDefault<Menu>($"where itemId=@0 and LocationId=@1", Itemid, LocationId));
            }
            else
                return View(default(Menu));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Menu", Writable = true)]
        public ActionResult Manage([Bind(Include = "LocationID,itemId, Price")] Menu menu)
        {
            if ((menu.ItemId != null && menu.ItemId>0) && menu.LocationId != null)
                return base.BaseSave<Menu>(menu, db.Exists<Menu>("where itemId=@0 and LocationId=@1", menu.ItemId, menu.LocationId));
            else
                return RedirectToAction("Manage", new { ItemId = menu.ItemId, LocationId = menu.LocationId });

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
