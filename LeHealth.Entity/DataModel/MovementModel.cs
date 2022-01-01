using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class MovementModel
    {
        public int MovementId { get; set; }
        public string MovementDesc { get; set; } 
        public int UserId { get; set; }
        public int Active { get; set; }
        public string BlockReason { get; set; }
    }
}
