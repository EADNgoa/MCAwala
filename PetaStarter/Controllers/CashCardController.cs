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
        [EAAuthorize(FunctionName = "CashCard", Writable = true)]
        public ActionResult Manage([Bind(Include = "CardID,CardName,Amount")] CashCard lt)
        {
            return base.BaseSave<CashCard>(lt, lt.CardId > 0);
        }

        [EAAuthorize(FunctionName = "CashCard", Writable = false)]
        public ActionResult LendingIndex(int? page, string PropName)
        {
            if (PropName?.Length > 0) page = 1;
            return View("LendingIndex", base.BaseIndex<CardIssueVw>(page,"ci.*, c.CardName", "CardIssue ci, CashCard c where ci.CardId=c.CardId and CardName like '%" + PropName + "%' order by ci.CardIssueId"));
        }



        // GET: Clients/Create
        [EAAuthorize(FunctionName = "CashCard", Writable = true)]
        public ActionResult LendingManage(int? id)
        {
            ViewBag.CardId = new SelectList(db.Fetch<CashCard>("Select * from CashCard"), "CardID", "CardName");
            return View(base.BaseCreateEdit<CardIssue>(id, "CardIssueID"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "CashCard", Writable = true)]
        public ActionResult LendingManage([Bind(Include = "CardIssueId,CardId,IssuedOn, ReturnedOn,ExpiresOn,ToPerson,ContactDetails,DepositAmt")] CardIssue cardIssue)
        {
            //check if card is already issued
            var preissu = db.SingleOrDefault<CardIssue>("select * from CardIssue where CardId=@0 and CardIssueId<>@1 and " +
                "(@2 between IssuedOn and ReturnedOn OR (@2 > IssuedOn and ReturnedOn IS null))", cardIssue.CardId,cardIssue.CardIssueId,cardIssue.IssuedOn);
            if (preissu!=null)
            {
                ViewBag.preissu = preissu;
                ViewBag.CardId = new SelectList(db.Fetch<CashCard>("Select * from CashCard"), "CardID", "CardName");
                return View(base.BaseCreateEdit<CardIssue>(null, "CardIssueID"));
            }
            return base.BaseSave<CardIssue>(cardIssue, cardIssue.CardIssueId> 0,"LendingIndex",null);
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
