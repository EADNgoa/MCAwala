using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        public ActionResult Manage([Bind(Include = "AutoID,GuestID,Body,LuckyDraw")] AutoEmail auto)
        {
             base.BaseSave<AutoEmail>(auto, auto.AutoID > 0);
            return View();
        }

        [EAAuthorize(FunctionName = "ThankYou Letter", Writable = true)]
        public ActionResult SendEmail(int? id)
        {
            var ThankYouLet = db.FirstOrDefault<AutoEmail>("Select * From AutoEmail");
            var customerEmail = "sarlekar41@gmail.com";
            var Body = ThankYouLet.Body;
            var lw = ThankYouLet.LuckyDraw;
            var errorMessage = "";
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            try
            {

                MailAddress fromAddress = new MailAddress("diptesh03@gmail.com","Diptesh Naik");
                smtpClient.Host = "localhost";
                smtpClient.Port = 25;
                smtpClient.Host = "smtp.gmail.com";
                message.From = fromAddress;
                message.To.Add(customerEmail);
                message.Subject = "Thank You Letter";
                message.IsBodyHtml = false;
                message.Body = Body+"\n\n\n"+lw;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("diptesh03@gmail.com", "  ");
                smtpClient.EnableSsl = true;
                smtpClient.Send(message);

            }
            catch (System.Net.Mail.SmtpException ex)
            {
                Response.Write(ex.ToString());
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
