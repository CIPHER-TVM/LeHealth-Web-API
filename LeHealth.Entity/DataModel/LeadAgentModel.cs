using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class LeadAgentModel
    {
        public int LeadAgentId { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public float CommisionPercent { get; set; }
    }
    public class LeadAgentModelAll : LeadAgentModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
