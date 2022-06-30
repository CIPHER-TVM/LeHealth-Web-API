using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PaymentModel
    {

        public int PaymentId { get; set; }
        public string PaymentNo { get; set; }
        public string PayDate { get; set; }
        public int PayType { get; set; }
        public int HeadId { get; set; }
        public int PatientId { get; set; }
        public int CreditId { get; set; }
        public int Mode { get; set; }
        public float Amount { get; set; }
        public string Remarks { get; set; }
        public string CardType { get; set; }
        public string CardNo { get; set; }
        public string ChqNo { get; set; }
        public string ChqDate { get; set; }
        public string ChqBranch { get; set; }
        public int LocationId { get; set; }
        public string Status { get; set; }
        public string CancelReason { get; set; }
        public int ShiftId { get; set; }
        public int TransId { get; set; }
        public int SponsorId { get; set; }
        public int BranchId { get; set; }
        public int IsDisplayed { get; set; }
        public int IsDeleted { get; set; }
        
    }
    public class PaymentModelAll:PaymentModel
    {
        public int UserId { get; set; }
        public int SessionId { get; set; }
    }
}
