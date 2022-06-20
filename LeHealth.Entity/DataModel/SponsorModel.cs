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
    }
    
}
