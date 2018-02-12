using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class SecurityGuardController : EAController
    {
        // GET: Clients
        [EAAuthorize(FunctionName ="Security",Writable =false)]
        public ActionResult Index(int? page, string PropName)
        {
            if (PropName?.Length > 0) page = 1;
            return View("Index", base.BaseIndex<SecurityGuard>(page, "SecurityGuard where Name like '%" + PropName + "%'"));
        }



        // GET: Clients/Create
        [EAAuthorize(FunctionName = "Security", Writable = true)]
        public ActionResult Manage(int? id)
        {
            return View(base.BaseCreateEdit<SecurityGuard>(id, "SecurityGuardID"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Security", Writable = true)]
        public ActionResult Manage([Bind(Include = "SecurityGuardID,AttendanceSystemID,Name,Address,Mobile")] SecurityGuard security)
        {
            return base.BaseSave<SecurityGuard>(security, security.SecurityGuardID > 0);
        }

        [EAAuthorize(FunctionName = "Security", Writable = true)]
        public ActionResult LodgeComplain(int? Eid, int? id)
        {
            ViewBag.SecGuard = db.FirstOrDefault<SecurityGuard>("Select * From SecurityGuard Where SecurityGuardID = @0", id);
            ViewBag.Dets = db.Fetch<SecurityGuardDetail>("Select * from SecurityGuardDetails where SecurityGuardID = @0", id);
            var rec = base.BaseCreateEdit<SecurityGuardDetail>(Eid, "SecurityGuardDetailID");
            if (Eid != null)
            {
               SecurityDets  ci = new SecurityDets()
                {
                   Description=rec.Description,
                   Path=rec.Path,
                   SecurityGuardDetailID=rec.SecurityGuardDetailID,
                   SecurityGuardID=(int)rec.SecurityGuardID,
                   Tdate=(DateTime)rec.Tdate,

                }; return View(ci);

            }
            else
            {
                SecurityDets ci = new SecurityDets() { };
                return View(ci);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Security", Writable = true)]
        public ActionResult LodgeComplain([Bind(Include = "SecurityGuardDetailID,SecurityGuardID,Description,Tdate,Path,UploadedFile")] SecurityDets detail)
        {
            SecurityGuardDetail res = new SecurityGuardDetail()
            {
                Description = detail.Description,
   
                SecurityGuardDetailID = detail.SecurityGuardDetailID,
                SecurityGuardID = detail.SecurityGuardID,
                Tdate = DateTime.Now,

            };

            if (detail.UploadedFile != null)
            {
                string fn = detail.UploadedFile.FileName.Substring(detail.UploadedFile.FileName.LastIndexOf('\\') + 1);
                fn = detail.SecurityGuardID + "_" + fn;
                string SavePath = System.IO.Path.Combine(Server.MapPath("~/Images"), fn);
                detail.UploadedFile.SaveAs(SavePath);

                //System.Drawing.Bitmap upimg = new System.Drawing.Bitmap(siteTransaction.UploadedFile.InputStream);
                //System.Drawing.Bitmap svimg = MyExtensions.CropUnwantedBackground(upimg);
                //svimg.Save(System.IO.Path.Combine(Server.MapPath("~/Images"), fn));

                res.Path = fn;
            }
            else
            {
                res.Path = detail.Path;
            }
            base.BaseSave<SecurityGuardDetail>(res, detail.SecurityGuardDetailID > 0);
            return RedirectToAction("LodgeComplain", new { id = detail.SecurityGuardID });

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
