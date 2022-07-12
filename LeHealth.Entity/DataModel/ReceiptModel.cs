using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ReceiptModel
    {
        public int ReceiptId { get; set; }
        public string ReceiptNo { get; set; }
        public string RecDate { get; set; }
        public int RecType { get; set; }
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
        //public string Status { get; set; }
        public string CancelReason { get; set; }
        public int ShiftId { get; set; }
        public int TransId { get; set; }
        public int SponsorId { get; set; }
        public int BranchId { get; set; }
        public int IsDisplayed { get; set; }
        public int IsDeleted { get; set; }
        public string Status { get; set; }
        public string PatientName { get; set; }
        

    }
    public class ReceiptModelAll:ReceiptModel
    {
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int ShowAll { get; set; }
       
    }
}
