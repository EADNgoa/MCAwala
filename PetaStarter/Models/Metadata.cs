﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Cavala
{
    public class CustomerMetadata
    {
        [Display(Name = "Name")]
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Name;

        [Display(Name = "Address")]
        [Required]
        [StringLength(350, MinimumLength = 3)]
        public string Address;

        [Display(Name = "Passport No.")]
        [StringLength(20, MinimumLength = 3)]
        public string PassportNo;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Passport Issued ON")]
        public DateTime DateIssue;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Passport Expiry ON")]
        public DateTime DateExpiry;
    }


    public class CardIssueMetadata
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime ExpiresOn;
    }

    public class ReservationMetadata
    {

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RDate;

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Rstart;

        [Required]
        public int ReservationSourceID;

        [Required]
        public int NoOfDays;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-mmm-yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime CheckIn;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-mmm-yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime CheckOut;

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string RoomNo;

    }

    public class ReservationDetailMetadata
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RDdate;

        [Required]
        [StringLength(250, MinimumLength = 3)]
        public string Description;

        [Required]
        [Range(0.0, Double.MaxValue)]
        public decimal Amount;
    }
    public class RecieptMetadata
    {
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Rdate;

        [Required]
        [StringLength(150, MinimumLength = 1)]
        public string PayDetails;


        public int PayMode;

        [Required]
        [Range(0.0, Double.MaxValue)]
        public decimal Amount;
    }

    public class GuestMetadata
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string GuestName;
        [Required]
        [StringLength(250, MinimumLength = 3)]
        public string GuestAddress;
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string GuestCoutry;
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Email;
        [Required]
        [StringLength(15, MinimumLength = 10)]
        public string Phone;
        [Required]
        [StringLength(100)]
        public string PhotoID;

        public string Likes;

        public string Dislikes;

    }

    public class DriverMetadata
    {
        [Required]
        [StringLength(100)]
        public string DriverName;

        [Required]
        [StringLength(15)]
        public string Mobile;

        [Required]
        [StringLength(100)]
        public string IdPicture;

    }

    public class CabReservationMetadata
    {
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Tdate;

        [Required]
        public int GuestID;
        [Required]
        [StringLength(50)]
        public string TFrom;
        [Required]
        [StringLength(50)]
        public string TTo;

        [Required]
        public int ReminderMinutes;


    }

    public class SecurityMetadata
    {
        [Required]
        [StringLength(50)]
        public string AttendanceSystemID;

        [Required]
        [StringLength(100)]
        public string Name;

        [Required]
        [StringLength(350)]
        public string Address;

        [Required]
        [StringLength(50)]
        public string Mobile;

    }

    public class CashierMetadata
    {
     
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Tdate;

        [Required]
        [Range(0.0, Double.MaxValue)]
        public decimal CashInHand;


    }

}

    //public class EmpTypeMetadata


    //{
    //    [DataType(DataType.DateTime)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Order Date")]
    //    public DateTime TDateTime;
    //}

    //public class EmpTypeMetadata
    //{
    //    [Display(Name = "Employee Type")]
    //    public int EmpTypeID;

    //    [Display(Name = "Employee Type")]
    //    [StringLength(50, MinimumLength = 3)]
    //    [Required]
    //    public int EmpType;

    //    [Display(Name = "Has Daily Allowance")]
    //    public bool HasDailyAllowance;
    //}

    //public class EDocTypeMetadata
    //{
    //    [Display(Name = "Employee Document Type")]
    //    public int EDocTypeID;

    //    [Display(Name = "Document Type")]
    //    [StringLength(50, MinimumLength = 3)]
    //    [Required]
    //    public string EDocType;


    //}

    //public class AllowanceTypeMetadata
    //{
    //    [Display(Name = "Allowance Type")]
    //    public int ATID;

    //    [Display(Name = "Allowance Type")]
    //    [StringLength(50, MinimumLength = 3)]
    //    [Required]
    //    public string AllowanceType;
    //}

    //public class EmployeesMetadata
    //{
    //    [Display(Name = "Name")]
    //    [StringLength(250, MinimumLength = 2)]
    //    [Required]
    //    public string Name;

    //    [Display(Name = "Nickname")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string NickName;

    //    [Display(Name = "Job Title")]
    //    [StringLength(150, MinimumLength = 3)]
    //    public string JobTitle;

    //    [Display(Name = "Mobile No.")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string Mobile;

    //    [Display(Name = "Emergency Contact No.")]
    //    [StringLength(50, MinimumLength = 3)]
    //    [Required]
    //    public string EmContactNo;

    //    [Display(Name = "Emergency Contact Name, Address(250 chars)")]
    //    [StringLength(250, MinimumLength = 3)]
    //    public string EmContactName;

    //    [Display(Name = "Relation with Emergency Contact")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string EmContactReln;

    //    [Display(Name = "is HDFC")]
    //    public bool IsHDFC;

    //    [Display(Name = "Category A or B?")]
    //    public string CatAB;


    //    [Display(Name = "HDFC Bank A/c")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string RegBankAc;

    //    [Display(Name = "Non HDFC bank A/c")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string NRegBankAc;

    //    [Display(Name = "Non. HDFC Bank Name")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string NRegBank;

    //    [Display(Name = "Non. HDFC Bank IFSC")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string NRegIFSC;

    //    [Display(Name = "Bonus Pay Month")]
    //    [Required]
    //    [Range(1, 12)]
    //    public int BonusPayMonth;

    //    [Display(Name = "PF No.")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string PFno;

    //    [Display(Name = "ESI No.")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string ESIno;


    //}

    //public class EmpDocsMetadata
    //{
    //    [Display(Name = "Employee")]
    //    public int EmpID;

    //    [Display(Name = "Document Type")]
    //    public int EDocTypeID;

    //    [Display(Name = "Employee")]
    //    public Employees Employees;

    //    [Display(Name = "Document Type")]
    //    public EDocTypes EDocTypes;

    //    [Display(Name = "Hide")]
    //    public bool Renewed;

    //    [Display(Name = "Emergency Contact Name, Address(250 chars)")]
    //    [StringLength(250, MinimumLength = 3)]
    //    public string EmContactName;

    //    [Display(Name = "Relation with Emergency Contact")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string EmContactReln;

    //    [Display(Name = "is HDFC")]
    //    public bool IsHDFC;

    //    [Display(Name = "Category A or B?")]
    //    public string CatAB;

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Expiry Date")]        
    //    public DateTime ExpiryDate;
    //}

    //public class EmploymentHistoryMetadata
    //{
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Join Date")]
    //    [Required]
    //    public DateTime JoinDate;

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Registration Date")]
    //    public DateTime RegistrationDate;

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Exit Date")]
    //    public DateTime ExitDate;

    //    [Display(Name = "Reason for leaving")]
    //    public string ExitReason;
    //}

    //public class LoansMetadata
    //{
    //    [Display(Name = "Loan")]
    //    public int LoanID;


    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Loan Date")]
    //    public DateTime LoanDate;

    //    [Display(Name = "Loan Amount")]
    //    [Required]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal Amount;

    //    [Display(Name = "Payback period (months)")]
    //    [Required]
    //    [Range(1, 48)]
    //    public int PayMonths;
    //}

    //public class LoanSkipMetadata
    //{
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Apply Date")]
    //    public DateTime PayDate;

    //    [Display(Name = "Amount payable (min 0)")]
    //    [Required]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal Amount;
    //}

    //public class WagesMetadata
    //{
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "With Effect From")]
    //    [Required]
    //    public DateTime WEF;

    //    [Display(Name = "Amount payable (min 0)")]
    //    [Required]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal Amount;
    //}

    //public class AllowanceMetadata
    //{
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "With Effect From")]
    //    [Required]
    //    public DateTime WEF;

    //    [Display(Name = "Percentage of Wage")]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal PercOfWage;

    //    [Display(Name = "Amount")]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal Amount;

    //}

    //public class AdvanceMetadata
    //{
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Advance taken on")]
    //    [Required]
    //    public DateTime AdvDate;

    //    [Display(Name = "Amount")]
    //    [Required]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal Amount;
    //}

    //public class BonusMetadata
    //{
    //    [Display(Name = "System Bonus")]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal SysBonus;

    //    [Display(Name = "Manual Override")]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal UsrBonus;
    //}

    //public class PayrollMetadata
    //{
    //    [Display(Name = "Days Worked")]        
    //    public int DaysWorked;

    //    [Display(Name = "Loan Amt.")]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal LoanAmt;


    //    [Display(Name = "HDFC Bank A/c")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string RegBankAc;

    //    [Display(Name = "Non HDFC bank A/c")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string NRegBankAc;

    //    [Display(Name = "Non. HDFC Bank Name")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string NRegBank;

    //    [Display(Name = "Non. HDFC Bank IFSC")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string NRegIFSC;

    //    [Display(Name = "Bonus Pay Month")]
    //    [Required]
    //    [Range(1, 12)]
    //    public int BonusPayMonth;

    //    [Display(Name = "PF No.")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string PFno;

    //    [Display(Name = "ESI No.")]
    //    [StringLength(50, MinimumLength = 3)]
    //    public string ESIno;


    //}

    //public class EmpDocsMetadata
    //{
    //    [Display(Name = "Employee")]
    //    public int EmpID;

    //    [Display(Name = "Document Type")]
    //    public int EDocTypeID;

    //    [Display(Name = "Employee")]
    //    public Employees Employees;

    //    [Display(Name = "Document Type")]
    //    public EDocTypes EDocTypes;

    //    [Display(Name = "Hide")]
    //    public bool Renewed;

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Expiry Date")]        
    //    public DateTime ExpiryDate;
    //}

    //public class EmploymentHistoryMetadata
    //{
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Join Date")]
    //    [Required]
    //    public DateTime JoinDate;

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Registration Date")]
    //    public DateTime RegistrationDate;

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Exit Date")]
    //    public DateTime ExitDate;

    //    [Display(Name = "Reason for leaving")]
    //    public string ExitReason;
    //}

    //public class LoansMetadata
    //{
    //    [Display(Name = "Loan")]
    //    public int LoanID;


    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Loan Date")]
    //    public DateTime LoanDate;

    //    [Display(Name = "Loan Amount")]
    //    [Required]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal Amount;

    //    [Display(Name = "Payback period (months)")]
    //    [Required]
    //    [Range(1, 48)]
    //    public int PayMonths;
    //}

    //public class LoanSkipMetadata
    //{
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Apply Date")]
    //    public DateTime PayDate;

    //    [Display(Name = "Amount payable (min 0)")]
    //    [Required]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal Amount;
    //}

    //public class WagesMetadata
    //{
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "With Effect From")]
    //    [Required]
    //    public DateTime WEF;

    //    [Display(Name = "Amount payable (min 0)")]
    //    [Required]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal Amount;
    //}

    //public class AllowanceMetadata
    //{
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "With Effect From")]
    //    [Required]
    //    public DateTime WEF;

    //    [Display(Name = "Percentage of Wage")]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal PercOfWage;

    //    [Display(Name = "Amount")]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal Amount;

    //}

    //public class AdvanceMetadata
    //{
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Display(Name = "Advance taken on")]
    //    [Required]
    //    public DateTime AdvDate;

    //    [Display(Name = "Amount")]
    //    [Required]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal Amount;
    //}

    //public class BonusMetadata
    //{
    //    [Display(Name = "System Bonus")]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal SysBonus;

    //    [Display(Name = "Manual Override")]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal UsrBonus;
    //}

    //public class PayrollMetadata
    //{
    //    [Display(Name = "Days Worked")]        
    //    public int DaysWorked;

    //    [Display(Name = "Loan Amt.")]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal LoanAmt;

    //    [Display(Name = "Loan")]
    //    public String LoanCmt;

    //    [Display(Name = "Bank")]
    //    public String BankName;

    //    [Display(Name = "Account")]
    //    public String BankAccount;

    //    [Display(Name = "Adjustment")]
    //    [Range(0.0, Double.MaxValue)]
    //    public decimal AdjAmt;

    //    [Display(Name = "Reason")]
    //    public String AdjRemark;
    //}

