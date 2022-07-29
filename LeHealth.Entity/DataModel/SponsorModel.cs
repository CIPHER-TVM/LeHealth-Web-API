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
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public List<SponsorRuleGroupModel> SponsorRuleGroupList { get; set; }
        public List<SponsorRuleItemModel> SponsorRuleItemList { get; set; }
    }
    public class SponsorRuleModelAll :SponsorRuleModel
    {        
        public int UserId { get; set; }
        public int SessionId { get; set; }
    }
    public class SponsorRuleGroupModel
    {
        public int RuleId { get; set; }
        public int SponsorId { get; set; }
        public int GroupId { get; set; }
        public float DiscPcnt { get; set; }
        public float DiscAmount { get; set; }
        public int DedGroup { get; set; }
        public int CoPayGroup { get; set; }
        public float DedAmt { get; set; }
        public float DedPer { get; set; }
        public float CoPayAmt { get; set; }
        public float CopayPer { get; set; }
        
                    
                    
    }
    public class SponsorRuleItemModel
    {
        public int ItemId { get; set; }
        public string NewName { get; set; }
        public float Rate { get; set; }
        public float DiscPcnt { get; set; }
        public float DiscAmount { get; set; }
        public int CoPayItem { get; set; }
        public int DedItem { get; set; }
        public int AuthReq { get; set; }
        
	
    }




}
