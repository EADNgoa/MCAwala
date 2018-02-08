using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class AutoEmailController : EAController
    {
   


        // GET: Clients/Create
        [EAAuthorize(FunctionName = "ThankYou Letter", Writable = true)]
        public ActionResult Manage(int? id)
        {
            return View(base.BaseCreateEdit<AutoEmail>(id, "AutoID"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "ThankYou Letter", Writable = true)]
        public ActionResult Manage([Bind(Include = "AutoID,GuestID,Salutation,Body,Closing,LuckyDraw")] AutoEmail auto)
        {
             base.BaseSave<AutoEmail>(auto, auto.AutoID > 0);
            return View();
        }

        [EAAuthorize(FunctionName = "ThankYou Letter", Writable = true)]
        public ActionResult SendEmail(int? id)
        {
            var ThankYouLet = db.FirstOrDefault<AutoEmail>("Select * From AutoEmail");
            var customerEmail = "erryl1@hotmail.com";
            var Body = ThankYouLet.Body;
            var errorMessage = "";
            var debuggingFlag = false;
            try
            {
                // Initialize WebMail helper
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 25;
                WebMail.UserName = "diptesh naik";
                WebMail.Password = " ";
                WebMail.From = "diptesh03@gmail.com";

                // Send email
                WebMail.Send(to: customerEmail,
                    subject: "ThankYou Letter ",
                    body: Body
                );
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
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
