using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class SymptomSignModel
    {
        public List<int> Symptoms { get; set; }
        public List<int> Signs { get; set; }
        public int BranchId { get; set; } 
    }
}
