using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class CabReservationController : EAController
    {
        // GET: Clients
        [EAAuthorize(FunctionName = "Cab Reservation", Writable = false)]

        public ActionResult Index(int? page, string PropName)
        {
            if (PropName?.Length > 0) page = 1;
            return View("Index", base.BaseIndex<Driver>(page, "Drivers where DriverName like '%" + PropName + "%'"));
        }



        // GET: Clients/Create
        [EAAuthorize(FunctionName = "Cab Reservation", Writable = true)]
        public ActionResult Manage(int? id)
        {
            
            var rec = base.BaseCreateEdit<Driver>(id, "DriverID");
            if (id != null)
            {
                DriverDets ci = new DriverDets()
                {
                    DriverID=rec.DriverID,
                    DriverName=rec.DriverName,
                    Mobile=rec.Mobile,
                };
                return View(ci);
            }
            else
            {
                DriverDets ci = new DriverDets() { };
                return View(ci);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Cab Reservation", Writable = true)]
        public ActionResult Manage([Bind(Include = "DriverID,DriverName,Mobile,IdPicture,UploadFile")] DriverDets drv)
        {
           
                    Driver d = new Driver
                    {
                        DriverID=drv.DriverID,
                        DriverName=drv.DriverName,
                        Mobile=drv.Mobile,

                    };

                    if (drv.UploadedFile != null)
                    {
                        string fn = drv.UploadedFile.FileName.Substring(drv.UploadedFile.FileName.LastIndexOf('\\') + 1);
                        fn = drv.DriverName + "_" + fn;
                        string SavePath = System.IO.Path.Combine(Server.MapPath("~/Images"), fn);
                        drv.UploadedFile.SaveAs(SavePath);
                        d.IdPicture = fn;
                    }
                    else
                    {
                        d.IdPicture = drv.IdPicture;
                    }
                    base.BaseSave<Driver>(d, drv.DriverID > 0);
                   
                   
                    return RedirectToAction("Index");
              
            
        }

        // GET: Clients
        [EAAuthorize(FunctionName = "Cab Reservation", Writable = false)]
        public ActionResult CabIndex(int? page, string PropName, DateTime? rd)
        {



            var res = db.Fetch<CabReservationDets>("Select * from CabReservation cr inner join Guests g on cr.GuestID = g.GuestID inner join Drivers d on d.DriverID = cr.DriverID where CabReservationID > 0 Order By CabReservationID Desc");
            if (rd != null) res = res.Where(a => a.Tdate.Date == rd.Value.Date).ToList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(res.ToPagedList(pageNumber, pageSize));
        }



        // GET: Clients/Create
        [EAAuthorize(FunctionName = "Cab Reservation", Writable = true)]
        public ActionResult CabManage(int? id)
        {
            if (id > 0) ViewBag.Guest = db.FirstOrDefault<string>("Select GuestName From CabReservation cr inner join Guests g on g.GuestID =cr.GuestID Where CabReservationID = @0",id);
            ViewBag.GuestName = MyExtensions.GetGuestName(db);
            ViewBag.DriverID = new SelectList(db.Fetch<Driver>("Select DriverID,DriverName from Drivers"), "DriverID", "DriverName");
            return View(base.BaseCreateEdit<CabReservation>(id, "CabReservationID"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Cab Reservation", Writable = true)]
        public ActionResult CabManage([Bind(Include = "CabReservationID,Tdate,GuestID,TFrom,TTo,ReminderMinutes,DriverID")] CabReservation reservation)
        {
            reservation.Tdate = DateTime.Now;
            base.BaseSave<CabReservation>(reservation, reservation.CabReservationID > 0);
            return RedirectToAction("CabIndex");
        }
        public ActionResult AutoCompleteGuests(string term)
        {
            var filteredItems = db.Fetch<Guest>($"Select * from Guests Where GuestName like '%{term}%'").Select(c => new { id = c.GuestID, value = c.GuestName });
            return Json(filteredItems, JsonRequestBehavior.AllowGet);
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
