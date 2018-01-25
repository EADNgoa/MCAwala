using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetaPoco;
//using System.Web.Mvc; for dynamic roles
//using Microsoft.AspNet.Identity;for dynamic roles
//using Cavala.Models;for dynamic roles
//using Microsoft.AspNet.Identity.EntityFramework;for dynamic roles

namespace Cavala.Models
{
 

    public class GuestViewModel
    {
        public int GuestID { get; set; }
        public int ReservationID { get; set; }
        public string GuestName { get; set; }
        public string GuestAddress { get; set; }
        public string GuestCountry { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Likes { get; set; }
        public string Dislikes { get; set; }
        public string PhotoID { get; set; }

    }

    
}