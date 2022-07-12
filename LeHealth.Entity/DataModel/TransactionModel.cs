using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class TransactionModel
    {
        public int TransId { get; set; }
        public string TransDate { get; set; }
        public string TransNo { get; set; }
        public int TransFlag { get; set; }
        public int PatientId { get; set; }
        public string Remarks { get; set; }
        public float TotalAmount { get; set; }
        public float TotalDiscount { get; set; }
        public float TotalTax { get; set; }
        public float SpdiscPcnt { get; set; }
        public float SpdiscAmount { get; set; }
        public float NetAmount { get; set; }
        public float TotalDeduction { get; set; }
        public float TotalCoPay { get; set; }
        public float TotalSponsored { get; set; }
        public float TotalNonInsured { get; set; }
        public float DeductionSurplus { get; set; }
        public string Status { get; set; }
        public string CancelReason { get; set; }
        public string CancelSettleReason { get; set; }
        public int Duplicate { get; set; }
        public int LocationId { get; set; }
        public int ConsultantId { get; set; }
        public int RGroupId { get; set; }
        public int PackId { get; set; }
        public int ShiftId { get; set; }
        public string SplDiscRemarks { get; set; }
        public string ItemDiscRemarks { get; set; }
        public string ItmDiscRemarks { get; set; }
        public string AprovalNo { get; set; }
        public int ConsultationId { get; set; }
        public int BranchId { get; set; }
        public string Date { get; set; }
        public string BillNo { get; set; }
        public string Location { get; set; }
        public string PatientName { get; set; }
        public string RegNo { get; set; }
        public float Amount { get; set; }

        public string BillDate { get; set; }
        public string ConsultantName { get; set; }
        public string SettledUser { get; set; }
        public string SponsorName { get; set; }
       
        public float DueAmt { get; set; }
        public float BillAmount { get; set; }
        public int ExtLabId { get; set; }
        public int Externalstatus { get; set; }
        public int TransDetId { get; set; }
        public int ItemId { get; set; }
        public float Qty { get; set; }
        public float Rate { get; set; }
        public float ActualRate { get; set; }
        public float DiscPcnt { get; set; }
        public float DiscAmount { get; set; }
        public int OrderDetId { get; set; }
        public int PostId { get; set; }
        public int CreditId { get; set; }
        public int PhysioDetId { get; set; }
        public int SerialNo { get; set; }
        public float DeductionAmount { get; set; }
        public float CoPayAmount { get; set; }
        public float SponsoredAmount { get; set; }
        public float AppliedDed { get; set; }
        public float AppliedCoPay { get; set; }
        public string Category { get; set; }
        public float Copay { get; set; }
        public float Deduction { get; set; }
        public float CopayPer { get; set; }
        public float CopayAmt { get; set; }
        public float DedPer { get; set; }
        public float DedAmt { get; set; }
        public int TaxId { get; set; }
        public float TaxPcnt { get; set; }
        public float TaxAmount { get; set; }

    }
    public class TransactionModelAll :TransactionModel
    {
        public int ShowAll { get; set; }
        public int UserId { get; set; }
       
        public int SessionId { get; set; }
        public string TransFromDate { get; set; }
        public string TransToDate { get; set; }
       
        public string OrderDate { get; set; }
    }
}
