using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ProfileModel
    {
        public int ProfileId { get; set; }
        public String ProfileDesc { get; set; }
        public String Remarks { get; set; }
        public int Active { get; set; }
        public String BlockReason { get; set; } 
        public List<int> ProfileIds { get; set; } 
    } 
}
