using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class CreditModel
    {
        public float AdvBal { get; set; }
        public float Amount { get; set; }
        public string Credit { get; set; }
        public int CreditId { get; set; }
        public string CreditRefNo { get; set; }
        public int CreditType { get; set; }
        public string OpenDate { get; set; }
        public int SponsorId { get; set; }
        public int PatientId { get; set; }
        public int AgentId { get; set; }
        public float CreditLimit { get; set; }
        public float CreditAvailed { get; set; }
        public string ValidUpto { get; set; }
       
        public float DedAmount { get; set; }
        public float CoPayPcnt { get; set; }
        public float MaxLimit { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
       
        public string PolicyNo { get; set; }
        public string PayerId { get; set; }
        public string CertificateNo { get; set; }
        public int DependantNo { get; set; }
        public string PolicyDate { get; set; }
        public string BlockReason { get; set; }
        public string ExpiryDate { get; set; }
        public int RuleId { get; set; }
        public int Active { get; set; }
        public int ImageId { get; set; }
        public Byte[] Image { get; set; }
        public int ClientID { get; set; }
        public int IsDisplayed { get; set; }
        public int IsDeleted { get; set; }
        public int BranchId { get; set; }
        public string Date { get; set; }
        public string RefNo { get; set; }
        public string RegNo { get; set; }
        public string PatientName { get; set; }
        public string Age { get; set; }
        public string SponsorName { get; set; }
        public float Limit { get; set; }
        public float Balance { get; set; }
    }
    public class CreditModelAll:CreditModel
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int SessionId { get; set; }
        public int UserId { get; set; }

    }
}
