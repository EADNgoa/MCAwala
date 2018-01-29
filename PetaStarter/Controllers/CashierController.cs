using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class CashierController : EAController
    {
        // GET: Clients
        [EAAuthorize(FunctionName ="Cashier",Writable =false)]
        public ActionResult Index(int? page ,DateTime? dt)
        {
            var uid = User.Identity.GetUserId();
            page = 1;
            var dets = db.Fetch<CashierShiftChange>("Select * from CashierShiftChanges where UserID =@0 Order By Tdate Desc",uid);
            if (dt != null)
            {
                dets = dets.Where(a => a.Tdate.Value.Date == dt).ToList();
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
        
            return View(dets.ToPagedList(pageNumber, pageSize));
          
        }



        // GET: Clients/Create
        [EAAuthorize(FunctionName = "Cashier", Writable = true)]
        public ActionResult Manage(int? id)
        {
            return View(base.BaseCreateEdit<CashierShiftChange>(id, "CashierID"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Cashier", Writable = true)]
        public ActionResult Manage([Bind(Include = "CashierID,UserID,Tdate,CashInHand")] CashierShiftChange cashier)
        {
            cashier.UserID = User.Identity.GetUserId();
            cashier.Tdate = DateTime.Now;
            return base.BaseSave<CashierShiftChange>(cashier, cashier.CashierID > 0);
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
