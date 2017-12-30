using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class CashCardController : EAController
    {
        // GET: Clients
        [EAAuthorize(FunctionName = "CashCard", Writable = false)]
        public ActionResult Index(int? page, string PropName)
        {
            if (PropName?.Length > 0) page = 1;
            return View("Index", base.BaseIndex<CashCard>(page, "CashCard where CardName like '%" + PropName + "%'"));
        }



        // GET: Clients/Create
        [EAAuthorize(FunctionName = "CashCard", Writable = true)]
        public ActionResult Manage(int? id)
        {
            return View(base.BaseCreateEdit<CashCard>(id, "CardID"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage([Bind(Include = "CardID,CardName,Amount")] CashCard lt)
        {
            return base.BaseSave<CashCard>(lt, lt.CardId > 0);
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
