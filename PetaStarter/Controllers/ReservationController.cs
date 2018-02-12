using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cavala.Controllers
{
    public class ReservationController : EAController
    {
        
        // GET: Clients
        [EAAuthorize(FunctionName = "Reservation", Writable = false)]
        public ActionResult Index(int? page,string PropName,DateTime? rd)
        {
     
         
           page = 1;
            var res = db.Fetch<ReservationDets>("Select * from Reservation r inner join ReservationSource rs on r.ReservationSourceID = rs.ReservationSourceID where ReservationID > 0 Order By ReservationID Desc");
            if (rd != null) res = res.Where(a => a.Rstart == rd).ToList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
          
            return View(res.ToPagedList(pageNumber, pageSize));
        }



        // GET: Clients/Create
        [EAAuthorize(FunctionName = "Reservation", Writable = true)]
        public ActionResult Manage(int? id)
        {
            
            ViewBag.ReservationSourceID = new SelectList(db.Fetch<ReservationSource>("Select ReservationSourceID,ReservationSouceName from ReservationSource"), "ReservationSourceID", "ReservationSouceName");
            return View(base.BaseCreateEdit<Reservation>(id, "ReservationID"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Reservation", Writable = true)]
        public ActionResult Manage([Bind(Include = "ReservationID,RDate,ReservationSourceID,Rstart,NoOfDays,CheckIn,CheckOut,RoomNo,CformNo,GuestComment,CavalaReply")] Reservation reservation)
        {
            if(reservation.ReservationID==0) reservation.RDate = DateTime.Now;

            return base.BaseSave<Reservation>(reservation, reservation.ReservationID > 0);
        }

        // GET: Clients
        [EAAuthorize(FunctionName = "Reservation", Writable = false)]
        public ActionResult ResIndex(int? page, string PropName)
        {
            if (PropName?.Length > 0) page = 1;


            return View("ResIndex", db.Fetch<ReservationSource>("Select * From ReservationSource where ReservationSouceName like '%" + PropName + "%'"));

        }



        // GET: Clients/Create
        [EAAuthorize(FunctionName = "Reservation", Writable = true)]
        public ActionResult ResManage(int? id)
        {

            return View(base.BaseCreateEdit<ReservationSource>(id, "ReservationSourceID"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Reservation", Writable = true)]
        public ActionResult ResManage([Bind(Include = "ReservationSourceID,ReservationSouceName")] ReservationSource reservation)
        {
           base.BaseSave<ReservationSource>(reservation, reservation.ReservationSourceID > 0);
            return RedirectToAction("ResIndex");
        }
        [EAAuthorize(FunctionName = "Reservation", Writable = true)]
        public ActionResult ReserveDetails(int? Eid,int? id)
        {
            ViewBag.ite = ChargeTypeEnum.Reservation;
            ViewBag.ResDet = db.FirstOrDefault<Reservation>("Select * From Reservation Where ReservationID = @0",id);
            ViewBag.Dets = db.Fetch<ReservationDetail>("Select * from ReservationDetails where ChargeID = @0 and ChargeType = @1",id,(int) ChargeTypeEnum.Reservation);
            return View(base.BaseCreateEdit<ReservationDetail>(Eid, "ReservationDetailID"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Reservation", Writable = true)]
        public ActionResult ReserveDetails([Bind(Include = "ReservationDetailID,RDate,Description,Amount,ChargeID,ChargeType")] ReservationDetail detail)
        {
            detail.RDdate = DateTime.Now;
            base.BaseSave<ReservationDetail>(detail, detail.ReservationDetailID > 0);
            return RedirectToAction("ReserveDetails",new {id=detail.ChargeID,ite=detail.ChargeType });
            
        }

       
    
  

        [EAAuthorize(FunctionName = "Reservation", Writable = true)]
        public ActionResult AddGuests(int? id,int? EID)
        {
            ViewBag.GuestID = new SelectList(db.Fetch<Guest>("Select * From Guests g inner join Reservation_Guest rg on g.GuestID= rg.GuestID inner join Reservation r on r.ReservationID =rg.ReservationID Where rg.ReservationID = @0", id), "GuestID", "GuestName");
            ViewBag.IsLead = db.FirstOrDefault<string>("Select GuestName From Guests g inner join Reservation_Guest rg on g.GuestID= rg.GuestID inner join Reservation r on r.ReservationID =rg.ReservationID Where rg.ReservationID = @0 and  rg.Islead =@1", id, true);

            ViewBag.ResDet = db.FirstOrDefault<Reservation>("Select * From Reservation Where ReservationID = @0",id);
            ViewBag.Dets = db.Fetch<Guest>("Select * From Guests g inner join Reservation_Guest rg on g.GuestID= rg.GuestID inner join Reservation r on r.ReservationID =rg.ReservationID Where rg.ReservationID = @0", id);
            var rec = base.BaseCreateEdit<Guest>(EID, "GuestID");
            if (EID != null)
            {
                GuestsDets ci = new GuestsDets()
                {
                    GuestAddress=rec.GuestAddress,
                    GuestCountry=rec.GuestCountry,
                    GuestID=rec.GuestID,
                    GuestName=rec.GuestName,
                    Dislikes=rec.Dislikes,
                    Email=rec.Email,
                    Likes=rec.Likes,
                    Phone=rec.Phone,
                    PhotoID=rec.PhotoID
                   
                };
                return View(ci);
            }
            else
            {
                GuestsDets ci = new GuestsDets() {  };
                return View(ci);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Reservation", Writable = true)]

        public ActionResult AddGuests([Bind(Include = "GuestID,GuestName,GuestAddress,GuestCountry,Email,Phone,UploadedFile,Likes,Dislikes")] GuestsDets guest, int? RID,int? GuestIDD)
        { 
            using (var transaction = db.GetTransaction())
            {
                try
                {
                    if (GuestIDD != null && RID != null )
                    {
                        var resguest = db.FirstOrDefault<Reservation_Guest>("Select * from Reservation_Guest Where ReservationID=@0 and GuestID =@1", RID, GuestIDD);
                      

                       var UpdateRec= db.Execute("update Reservation_Guest set IsLead=1 Where GuestID=@0 and ReservationID =@1",GuestIDD,RID);
                        
                        //var item = new Reservation_Guest { ReservationID=(int)RID,GuestID=(int)GuestID,IsLead=true };
                        //db.Save(item);
                        transaction.Complete();                       
                        return RedirectToAction("AddGuests");
                    }
                    Guest res = new Guest
                    {
                        GuestAddress = guest.GuestAddress,
                        GuestCountry = guest.GuestCountry,
                        GuestID = guest.GuestID,
                        GuestName = guest.GuestName,
                        Dislikes = guest.Dislikes,
                        Email = guest.Email,
                        Likes = guest.Likes,
                        Phone = guest.Phone,
                        PhotoID = guest.PhotoID
                    };

                    if (guest.UploadedFile != null)
                    {
                        string fn = guest.UploadedFile.FileName.Substring(guest.UploadedFile.FileName.LastIndexOf('\\') + 1);
                        fn = guest.GuestName + "_" + fn;
                        string SavePath = System.IO.Path.Combine(Server.MapPath("~/Images"), fn);
                        guest.UploadedFile.SaveAs(SavePath);

                        //System.Drawing.Bitmap upimg = new System.Drawing.Bitmap(siteTransaction.UploadedFile.InputStream);
                        //System.Drawing.Bitmap svimg = MyExtensions.CropUnwantedBackground(upimg);
                        //svimg.Save(System.IO.Path.Combine(Server.MapPath("~/Images"), fn));

                        res.PhotoID = fn;
                    }
                    else
                    {
                        res.PhotoID = guest.PhotoID;
                    }
                    base.BaseSave<Guest>(res, guest.GuestID > 0);
                    if (guest.GuestID==0)
                    {
                        var res_guest = new Reservation_Guest { GuestID = res.GuestID, ReservationID = (int)RID, IsLead = false };
                        db.Insert(res_guest);
                    }
                    transaction.Complete();
                    return RedirectToAction("AddGuests");
                }
                catch (Exception ex)
                 {
                    db.AbortTransaction();
                    throw ex;
                }
            }
        }

        [HttpPost]
        public ActionResult AddPreviousGuest(int RID, IEnumerable<int> GID)
        {
            foreach (var g in GID)
            {
                    var item = new Reservation_Guest { GuestID = g, ReservationID = (int)RID, IsLead = false };
                    db.Insert(item);
            }
            return RedirectToAction("AddGuests", new { id = RID });
        }
        public ActionResult ExistingGuestRec(string Ph)
        {

         var recs = db.Fetch<Cavala.Models.GuestViewModel>($"Select * from Guests Where Phone like '%{Ph}%'");

            return PartialView("GuestSearchPartial",recs);
        }

        [EAAuthorize(FunctionName = "Reservation", Writable = true)]
        public ActionResult AddReciepts(int? Eid, int? id)
        {
            var EnumValues= from PayTypeEnum c in Enum.GetValues(typeof(PayTypeEnum)) select new { ID = c, Name = c.ToString() };
            ViewBag.PayMode = new SelectList(EnumValues, "ID", "Name");
            ViewBag.ite = ChargeTypeEnum.Reservation;
            ViewBag.ResDet = db.FirstOrDefault<Reservation>("Select * From Reservation Where ReservationID = @0", id);
            ViewBag.Dets = db.Fetch<Reciept>("Select * from Reciept where ChargeID = @0 and ChargeType = @1", id, (int)ChargeTypeEnum.Reservation);
            return View(base.BaseCreateEdit<Reciept>(Eid, "RecieptID"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [EAAuthorize(FunctionName = "Reservation", Writable = true)]
        public ActionResult AddReciepts([Bind(Include = "RecieptID,Rdate,ChargeID,ChargeType,Amount,PayDetails")] Reciept detail,PayTypeEnum? PayMode)
        {
            detail.Rdate = DateTime.Now;
            detail.PayMode = (int)PayMode;
            base.BaseSave<Reciept>(detail, detail.RecieptID > 0);
            return RedirectToAction("AddReciepts", new { id = detail.ChargeID, ite = detail.ChargeType });
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
