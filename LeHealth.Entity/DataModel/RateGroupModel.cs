using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class RateGroupModel
    {
        public int RGroupId { get; set; }
        public string RGroupName { get; set; }
        public string Description { get; set; }
        public string EffectFrom { get; set; }
        public string EffectTo { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; }
        public int IsDisplayed { get; set; }
    }
    public class RateGroupModelAll : RateGroupModel
    {
        public int ShowAll { get; set; }
    }
}
