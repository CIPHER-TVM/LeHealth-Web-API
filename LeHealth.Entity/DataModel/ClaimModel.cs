using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ClaimModel
    {
        public int ClaimId { get; set; }
        public int Branchid { get; set; }
        public int SponsorId { get; set; }
        public string SponsorName { get; set; }
        public string AgentName { get; set; }
        public string ClaimDate { get; set; }
        public string RefNo { get; set; }
        public float ClaimAmount { get; set; }
        public string Status { get; set; }
        public string PeriodFrom { get; set; }
        public string PeriodTo { get; set; }
        public string Remarks { get; set; }
        public string Consultant { get; set; }
        public bool BillSelect { get; set; }
        public string AsoapNo { get; set; }
        public int EncounterType { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int TransId { get; set; }
        public string BillDate { get; set; }
        public string BillNo { get; set; }
        public int CreditId { get; set; }
        public float TotalAmount { get; set; }
        public float BillAmount { get; set; }
        public string CardNo { get; set; }
        public float ClaimAmt { get; set; }
        public float CoPay { get; set; }
        public float Discount { get; set; }
        public int ConsultationId { get; set; }
        public string AprovalNo { get; set; }
        public int RuleId { get; set; }

        public string Rule { get; set; }


    }
    public class ClaimModelAll : ClaimModel
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CancelReason { get; set; }
        public int AgentId { get; set; }
        public int ConsultantId { get; set; }
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public int ShowAll { get; set; }
        public List<ClaimDetailsModel> ClaimDetailList { get; set; }
    }
    public class ClaimDetailsModel
    {
        public int Claimid { get; set; }
        public int TransId { get; set; }
        public int CreditId { get; set; }
        public int UserId { get; set; }
        public string AsoapNo { get; set; }
        public string AprovalNo { get; set; }
        public string EncounterType { get; set; }
        public int SessionId { get; set; }
    }

    public class ClaimReceiptModel:ClaimModel
    {
       public int ReceiptId { get; set; }
       public int RecType { get; set; }
       public int HeadId { get; set; }
       public int ClaimRecId { get; set; }
       public int Mode { get; set; }
       public int ClaimReceiptId { get; set; }
       public int Active { get; set; }

        public string ReceiptNo { get; set; }
        public string RecDate { get; set; }
         public string ChqDate { get; set; }
         public string ChqNo { get; set; }
         public string ClaimNo { get; set; }
         public string BillPeriodTo { get; set; }
         public string CardType { get; set; }
         public string ReceiptRemarks { get; set; }
         public string Card { get; set; }
         public string BillPeriod { get; set; }
         public string PaymentMode { get; set; }
         public string ChqBranch { get; set; }
         public string HeadDesc { get; set; }

         public float TotRecAmt { get; set; }
         public float TotDeniedAmt { get; set; }
         public float InvoiceAmount { get; set; }
         public float Collectedamount { get; set; }
         public float ReceivedAmount { get; set; }
         public float RecAmt { get; set; }
         public float DeniedAmt { get; set; }
         public float OutStanding { get; set; }
         public float ClaimedAmount { get; set; }
         public float Amount { get; set; }
         public float BalanceAmount { get; set; }
    }
    
    



}
