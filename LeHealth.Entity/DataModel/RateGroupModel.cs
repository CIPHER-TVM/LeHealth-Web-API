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
        public int Active { get; set; } 
        public int UserId { get; set; } 
        public string BlockReason { get; set; }  
    }
}
