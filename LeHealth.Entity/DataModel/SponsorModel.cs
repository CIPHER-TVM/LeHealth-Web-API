using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class SponsorModel
    {
        public int SponsorId { get; set; }
        public string OpenDate { get; set; }
        public string CreditRefNo { get; set; }
        public string SponsorName { get; set; }
        public string AgentName { get; set; }
        public string PolicyNo { get; set; }
        public string ValidUpto { get; set; }
        public bool IsSponsorExpired { get; set; }
        public int AgentId { get; set; }
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public int BranchId { get; set; }
    }
    public class SponsorRuleModel
    { 	 
        public int RuleId { get; set; }
        public int SponsorId { get; set; }
        public string RuleDesc { get; set; }
        public float DedAmount { get; set; }
        public float CoPayPcnt { get; set; }
        public int RateGroupId { get; set; }
        public int UpfrontDed { get; set; }
        public int CopayBefDisc { get; set; }
        public int IsDisplayed { get; set; }
        public int IsDeleted { get; set; }
        public int ShowAll { get; set; }
        public int BranchId { get; set; }
    }
    public class SponsorRuleModelAll :SponsorRuleModel
    {        
        public int UserId { get; set; }
        public int SessionId { get; set; }
    }
        

    
}
