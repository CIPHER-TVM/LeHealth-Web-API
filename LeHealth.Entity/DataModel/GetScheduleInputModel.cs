using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class GetScheduleInputModel 
    {
        public List<int> Consultant { get; set; }
        public Int32 BranchId { get; set; } 
        public string DateValue { get; set; }
        public List<int> Departments { get; set; }
        public string ConsultantName { get; set; }
    }
}
