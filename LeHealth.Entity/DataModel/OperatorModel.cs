using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class OperatorModel
    {
        public int Id { get; set; }
        public string OperatorName { get; set; }
        public string OperatorCode { get; set; }
        public string OperatorDescription { get; set; }
        public int Active { get; set; } 
        public string BlockReason { get; set; }  
    }
}
