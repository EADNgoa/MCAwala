using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class CustomerController : EAController
    {
        // GET: Clients
        public ActionResult Index(int? page, string PropName)
        {
            if (PropName?.Length > 0) page = 1;
            return View("Index", base.BaseIndex<Customer>(page, "Customer where Name like '%" + PropName + "%'"));
        }



        // GET: Clients/Create
        public ActionResult Manage(int? id)
        {
            return View(base.BaseCreateEdit<Customer>(id, "CustomerID"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage([Bind(Include = "CustomerID,Name,Address, PassportNo, DateIssue,DateExpiry")] Customer customer)
        {
            return base.BaseSave<Customer>(customer, customer.CustomerID > 0);
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
