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
    public class ClaimModelAll:ClaimModel
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int AgentId { get; set; }
        public int ConsultantId { get; set; }
    }
}
