using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class GetScheduleInputModel
    {
        public Int32?[] Consultant { get; set; }
        public Int32 BranchId { get; set; } 
        public string DateValue { get; set; } 
    }
}
