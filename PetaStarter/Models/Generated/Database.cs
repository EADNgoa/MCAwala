




















// This file was automatically generated by the PetaPoco T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `DefaultConnection`
//     Provider:               `System.Data.SqlClient`
//     Connection String:      `Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=CavalaDB;Integrated Security=True`
//     Schema:                 ``
//     Include Views:          `False`



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace Cavala
{

	public partial class Repository : Database
	{
		public Repository() 
			: base("DefaultConnection")
		{
			CommonConstruct();
		}

		public Repository(string connectionStringName) 
			: base(connectionStringName)
		{
			CommonConstruct();
		}
		
		partial void CommonConstruct();
		
		public interface IFactory
		{
			Repository GetInstance();
		}
		
		public static IFactory Factory { get; set; }
        public static Repository GetInstance()
        {
			if (_instance!=null)
				return _instance;
				
			if (Factory!=null)
				return Factory.GetInstance();
			else
				return new Repository();
        }

		[ThreadStatic] static Repository _instance;
		
		public override void OnBeginTransaction()
		{
			if (_instance==null)
				_instance=this;
		}
		
		public override void OnEndTransaction()
		{
			if (_instance==this)
				_instance=null;
		}
        

	}
	



    

	[TableName("dbo.__MigrationHistory")]



	[PrimaryKey("MigrationId", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class __MigrationHistory  
    {



		[Column] public string MigrationId { get; set; }





		[Column] public string ContextKey { get; set; }





		[Column] public byte[] Model { get; set; }





		[Column] public string ProductVersion { get; set; }



	}

    

	[TableName("dbo.__RefactorLog")]



	[PrimaryKey("OperationKey", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class __RefactorLog  
    {



		[Column] public Guid OperationKey { get; set; }



	}

    

	[TableName("dbo.AspNetRoles")]



	[PrimaryKey("Id", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class AspNetRole  
    {



		[Column] public string Id { get; set; }





		[Column] public string Name { get; set; }



	}

    

	[TableName("dbo.AspNetUserClaims")]



	[PrimaryKey("Id")]




	[ExplicitColumns]

    public partial class AspNetUserClaim  
    {



		[Column] public int Id { get; set; }





		[Column] public string UserId { get; set; }





		[Column] public string ClaimType { get; set; }





		[Column] public string ClaimValue { get; set; }



	}

    

	[TableName("dbo.AspNetUserLogins")]



	[PrimaryKey("LoginProvider", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class AspNetUserLogin  
    {



		[Column] public string LoginProvider { get; set; }





		[Column] public string ProviderKey { get; set; }





		[Column] public string UserId { get; set; }



	}

    

	[TableName("dbo.AspNetUserRoles")]



	[PrimaryKey("UserId", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class AspNetUserRole  
    {



		[Column] public string UserId { get; set; }





		[Column] public string RoleId { get; set; }



	}

    

	[TableName("dbo.AspNetUsers")]



	[PrimaryKey("Id", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class AspNetUser  
    {



		[Column] public string Id { get; set; }





		[Column] public string Email { get; set; }





		[Column] public bool EmailConfirmed { get; set; }





		[Column] public string PasswordHash { get; set; }





		[Column] public string SecurityStamp { get; set; }





		[Column] public string PhoneNumber { get; set; }





		[Column] public bool PhoneNumberConfirmed { get; set; }





		[Column] public bool TwoFactorEnabled { get; set; }





		[Column] public DateTime? LockoutEndDateUtc { get; set; }





		[Column] public bool LockoutEnabled { get; set; }





		[Column] public int AccessFailedCount { get; set; }





		[Column] public string UserName { get; set; }





		[Column] public DateTime DateCreated { get; set; }





		[Column] public bool Disabled { get; set; }





		[Column] public DateTime? LastLogin { get; set; }





		[Column] public DateTime? BirthDate { get; set; }



	}

    

	[TableName("dbo.CabReservation")]



	[PrimaryKey("CabReservationID", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class CabReservation  
    {



		[Column] public int CabReservationID { get; set; }





		[Column] public DateTime? Tdate { get; set; }





		[Column] public int? GuestID { get; set; }





		[Column] public string TFrom { get; set; }





		[Column] public string TTo { get; set; }





		[Column] public int? ReminderMinutes { get; set; }



	}

    

	[TableName("dbo.CardIssue")]



	[PrimaryKey("CardIssueId", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class CardIssue  
    {



		[Column] public int CardIssueId { get; set; }





		[Column] public int? CardId { get; set; }





		[Column] public DateTime? IssuedOn { get; set; }





		[Column] public DateTime? ReturnedOn { get; set; }





		[Column] public DateTime? ExpiresOn { get; set; }





		[Column] public string ToPerson { get; set; }





		[Column] public string ContactDetails { get; set; }





		[Column] public decimal? DepositAmt { get; set; }



	}

    

	[TableName("dbo.CardTransaction")]




	[ExplicitColumns]

    public partial class CardTransaction  
    {



		[Column] public int CardId { get; set; }





		[Column] public int? CardIssueId { get; set; }





		[Column] public DateTime? TDateTime { get; set; }





		[Column] public decimal? AmountBanked { get; set; }





		[Column] public decimal? AmountSpent { get; set; }





		[Column] public int? OTID { get; set; }



	}

    

	[TableName("dbo.CashCard")]



	[PrimaryKey("CardId")]




	[ExplicitColumns]

    public partial class CashCard  
    {



		[Column] public int CardId { get; set; }





		[Column] public string CardName { get; set; }





		[Column] public decimal? Amount { get; set; }



	}

    

	[TableName("dbo.Config")]



	[PrimaryKey("TableReservationTime", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class Config  
    {



		[Column] public DateTime TableReservationTime { get; set; }





		[Column] public int? CardExpiryDays { get; set; }



	}

    

	[TableName("dbo.Course")]



	[PrimaryKey("CourseId")]




	[ExplicitColumns]

    public partial class Course  
    {



		[Column] public int CourseId { get; set; }





		[Column] public string CourseName { get; set; }



	}

    

	[TableName("dbo.Customer")]



	[PrimaryKey("CustomerID")]




	[ExplicitColumns]

    public partial class Customer  
    {



		[Column] public int CustomerID { get; set; }





		[Column] public string Name { get; set; }





		[Column] public string Address { get; set; }





		[Column] public string PassportNo { get; set; }





		[Column] public DateTime? DateIssue { get; set; }





		[Column] public DateTime? DateExpiry { get; set; }





		[Column] public string PhotograghID { get; set; }



	}

    

	[TableName("dbo.Discounts")]



	[PrimaryKey("DiscountId")]




	[ExplicitColumns]

    public partial class Discount  
    {



		[Column] public int DiscountId { get; set; }





		[Column] public int? ItemId { get; set; }





		[Column] public DateTime? Tfrom { get; set; }





		[Column] public DateTime? Tto { get; set; }





		[Column] public decimal? Percentage { get; set; }





		[Column] public decimal? Amount { get; set; }



	}

    

	[TableName("dbo.Drivers")]



	[PrimaryKey("DriverID", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class Driver  
    {



		[Column] public int DriverID { get; set; }





		[Column] public string DriverName { get; set; }





		[Column] public string Mobile { get; set; }





		[Column] public string IdPicture { get; set; }



	}

    

	[TableName("dbo.FoodStock")]



	[PrimaryKey("FoodStockId")]




	[ExplicitColumns]

    public partial class FoodStock  
    {



		[Column] public int FoodStockId { get; set; }





		[Column] public DateTime TDate { get; set; }





		[Column] public int? InventoryTransactionId { get; set; }





		[Column] public int ItemId { get; set; }





		[Column] public decimal Qty { get; set; }





		[Column] public decimal Size { get; set; }





		[Column] public int UnitId { get; set; }





		[Column] public int LocationId { get; set; }



	}

    

	[TableName("dbo.FunctionGroups")]



	[PrimaryKey("FunctionID", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class FunctionGroup  
    {



		[Column] public int FunctionID { get; set; }





		[Column] public int GroupID { get; set; }





		[Column] public bool Writable { get; set; }



	}

    

	[TableName("dbo.Groups")]



	[PrimaryKey("GroupID")]




	[ExplicitColumns]

    public partial class Group  
    {



		[Column] public int GroupID { get; set; }





		[Column] public string GroupName { get; set; }



	}

    

	[TableName("dbo.Guests")]



	[PrimaryKey("GuestID", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class Guest  
    {



		[Column] public int GuestID { get; set; }





		[Column] public string GuestName { get; set; }





		[Column] public string GuestAddress { get; set; }





		[Column] public byte[] GuestCountry { get; set; }





		[Column] public string Email { get; set; }





		[Column] public string Phone { get; set; }





		[Column] public int? PhotoID { get; set; }





		[Column] public string Likes { get; set; }





		[Column] public string Dislikes { get; set; }



	}

    

	[TableName("dbo.InventoryTransaction")]



	[PrimaryKey("InventoryTransactionId")]




	[ExplicitColumns]

    public partial class InventoryTransaction  
    {



		[Column] public int InventoryTransactionId { get; set; }





		[Column] public DateTime TDate { get; set; }





		[Column] public int ItemId { get; set; }





		[Column] public decimal? QtyAdded { get; set; }





		[Column] public decimal? QtyRemoved { get; set; }





		[Column] public int? FromLocationId { get; set; }





		[Column] public int? ToLocationId { get; set; }





		[Column] public string RecvdByUserId { get; set; }





		[Column] public string ChkByUserId { get; set; }





		[Column] public int UnitId { get; set; }





		[Column] public int? FoodStockId { get; set; }



	}

    

	[TableName("dbo.Items")]



	[PrimaryKey("ItemId")]




	[ExplicitColumns]

    public partial class Item  
    {



		[Column] public int ItemId { get; set; }





		[Column] public string ItemName { get; set; }





		[Column] public int? ItemTypeId { get; set; }





		[Column] public int? ExpiryDays { get; set; }





		[Column] public int? UnitId { get; set; }



	}

    

	[TableName("dbo.ItemTypes")]



	[PrimaryKey("ItemTypeId")]




	[ExplicitColumns]

    public partial class ItemType  
    {



		[Column] public int ItemTypeId { get; set; }





		[Column] public string ItemTypeName { get; set; }



	}

    

	[TableName("dbo.Location")]



	[PrimaryKey("LocationId")]




	[ExplicitColumns]

    public partial class Location  
    {



		[Column] public int LocationId { get; set; }





		[Column] public string LocationName { get; set; }





		[Column] public int? LocationTypeId { get; set; }



	}

    

	[TableName("dbo.LocationTypes")]



	[PrimaryKey("LocationTypeId")]




	[ExplicitColumns]

    public partial class LocationType  
    {



		[Column] public int LocationTypeId { get; set; }





		[Column] public string LocationTypeName { get; set; }



	}

    

	[TableName("dbo.Menu")]



	[PrimaryKey("LocationId", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class Menu  
    {



		[Column] public int LocationId { get; set; }





		[Column] public int ItemId { get; set; }





		[Column] public decimal? Price { get; set; }



	}

    

	[TableName("dbo.OrderTicketDetails")]



	[PrimaryKey("OTdetailsId")]




	[ExplicitColumns]

    public partial class OrderTicketDetail  
    {



		[Column] public int OTdetailsId { get; set; }





		[Column] public int? OTID { get; set; }





		[Column] public int? ItemId { get; set; }





		[Column] public int? Qty { get; set; }





		[Column] public decimal? Price { get; set; }





		[Column] public int? CourseId { get; set; }





		[Column] public bool? NC { get; set; }





		[Column] public string NCtext { get; set; }





		[Column] public string NCUserId { get; set; }



	}

    

	[TableName("dbo.OrderTickets")]



	[PrimaryKey("OTID")]




	[ExplicitColumns]

    public partial class OrderTicket  
    {



		[Column] public int OTID { get; set; }





		[Column] public int? LocationId { get; set; }





		[Column] public DateTime? TDateTime { get; set; }





		[Column] public string RoomNo { get; set; }





		[Column] public string TableId { get; set; }





		[Column] public int? CardId { get; set; }





		[Column] public string WaiterId { get; set; }





		[Column] public bool? IsServed { get; set; }





		[Column] public bool? IsPaid { get; set; }





		[Column] public string EditedBy { get; set; }





		[Column] public bool? IsVoid { get; set; }





		[Column] public string VoidedBy { get; set; }





		[Column] public string VoidedReason { get; set; }



	}

    

	[TableName("dbo.Reciept")]



	[PrimaryKey("RecieptID", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class Reciept  
    {



		[Column] public int RecieptID { get; set; }





		[Column] public DateTime? Rdate { get; set; }





		[Column] public int? ChargeID { get; set; }





		[Column] public int? ChargeType { get; set; }





		[Column] public decimal? Amount { get; set; }





		[Column] public int? PayMode { get; set; }





		[Column] public string PayDetails { get; set; }



	}

    

	[TableName("dbo.Reservation")]



	[PrimaryKey("ReservationID", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class Reservation  
    {



		[Column] public int ReservationID { get; set; }





		[Column] public DateTime? RDate { get; set; }





		[Column] public int? ReservationSourceID { get; set; }





		[Column] public DateTime? Rstart { get; set; }





		[Column] public int? NoOfDays { get; set; }





		[Column] public DateTime? CheckIn { get; set; }





		[Column] public DateTime? CheckOut { get; set; }





		[Column] public int? RoomNo { get; set; }





		[Column] public string GuestComment { get; set; }





		[Column] public string CavalaReply { get; set; }



	}

    

	[TableName("dbo.Reservation_Guest")]




	[ExplicitColumns]

    public partial class Reservation_Guest  
    {



		[Column] public int ReservationID { get; set; }





		[Column] public int GuestID { get; set; }





		[Column] public bool? IsLead { get; set; }



	}

    

	[TableName("dbo.ReservationDetails")]



	[PrimaryKey("ReservationDetailID", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class ReservationDetail  
    {



		[Column] public int ReservationDetailID { get; set; }





		[Column] public DateTime? RDdate { get; set; }





		[Column] public byte[] Description { get; set; }





		[Column] public decimal? Amount { get; set; }





		[Column] public int? ChargeID { get; set; }





		[Column] public int? ChargeType { get; set; }





		[Column] public int? ReservationID { get; set; }



	}

    

	[TableName("dbo.ReservationSource")]



	[PrimaryKey("ReservationSourceID")]




	[ExplicitColumns]

    public partial class ReservationSource  
    {



		[Column] public int ReservationSourceID { get; set; }





		[Column] public string ReservationSouceName { get; set; }



	}

    

	[TableName("dbo.Stock")]



	[PrimaryKey("ItemId", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class Stock  
    {



		[Column] public int ItemId { get; set; }





		[Column] public decimal? Quantity { get; set; }





		[Column] public int? UnitId { get; set; }





		[Column] public int? LocationId { get; set; }



	}

    

	[TableName("dbo.TableReservation")]



	[PrimaryKey("TableReservationId")]




	[ExplicitColumns]

    public partial class TableReservation  
    {



		[Column] public int TableReservationId { get; set; }





		[Column] public DateTime? TDateTime { get; set; }





		[Column] public int? TableId { get; set; }





		[Column] public string PersonName { get; set; }





		[Column] public string Contact { get; set; }





		[Column] public int? NoOfPax { get; set; }



	}

    

	[TableName("dbo.Tables")]



	[PrimaryKey("TableId")]




	[ExplicitColumns]

    public partial class Table  
    {



		[Column] public int TableId { get; set; }





		[Column] public string TableName { get; set; }





		[Column] public int? LocationId { get; set; }



	}

    

	[TableName("dbo.UnitConversion")]



	[PrimaryKey("UCId")]




	[ExplicitColumns]

    public partial class UnitConversion  
    {



		[Column] public int UCId { get; set; }





		[Column] public int AUnitOfId { get; set; }





		[Column] public decimal IsJust { get; set; }





		[Column] public int OfUnitId { get; set; }



	}

    

	[TableName("dbo.Units")]



	[PrimaryKey("UnitId")]




	[ExplicitColumns]

    public partial class Unit  
    {



		[Column] public int UnitId { get; set; }





		[Column] public string UnitName { get; set; }



	}

    

	[TableName("dbo.UserFunctions")]



	[PrimaryKey("FunctionID")]




	[ExplicitColumns]

    public partial class UserFunction  
    {



		[Column] public int FunctionID { get; set; }





		[Column] public string FunctionName { get; set; }





		[Column] public string Module { get; set; }



	}

    

	[TableName("dbo.UserGroups")]



	[PrimaryKey("UserID", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class UserGroup  
    {



		[Column] public string UserID { get; set; }





		[Column] public int GroupID { get; set; }



	}


}
