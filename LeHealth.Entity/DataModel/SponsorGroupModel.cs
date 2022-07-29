using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class SponsorGroupModel
    {
        public List<SponsorRuleGroupModel> SponsorRuleGroupList { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string RuleCategory { get; set; }
        public float DiscPcnt { get; set; }
        public float DiscAmount { get; set; }
        public int SponsorId { get; set; }
        public int RuleId { get; set; }
        public int DedGroup { get; set; }
        public int CoPayGroup { get; set; }
        public float DedAmt { get; set; }
        public float DedPer { get; set; }
        public float CoPayAmt { get; set; }
        public float CopayPer { get; set; }
       
    }
    
}
