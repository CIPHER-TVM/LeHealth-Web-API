using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class SponsorGropuServiceItemModel
    {
            public int RuleId { get; set; }
            public int ItemId { get; set; }
            public int SponsorId { get; set; }
            public int GroupId { get; set; }
            public string ItemName { get; set; }
            public string NewName { get; set; }
            public string CPTCode { get; set; }
            public float Rate { get; set; }
            public float DiscPcnt { get; set; }
            public float DiscAmount { get; set; }
            public float StdRate { get; set; }
            public int DedItem { get; set; }
            public int CoPayItem { get; set; }
            public int AuthReq { get; set; }
            public string RuleCategory { get; set; }
            public string ItemCode { get; set; }
        
    }
}
