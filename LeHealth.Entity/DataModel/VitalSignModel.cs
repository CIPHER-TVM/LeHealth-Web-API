using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class VitalSignModel
    {
        public int SignId { get; set; }
        public string SignName { get; set; }
        public string Mandatory { get; set; } 
        public string SignCode { get; set; }
        public string SignUnit { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public int SortOrder { get; set; }
    }
    public class VitalSignModelAll : VitalSignModel 
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
