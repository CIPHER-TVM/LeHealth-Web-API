using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class DosageModel
    {
        public int DosageId { get; set; }
        public string DosageDesc { get; set; }
        public bool Active { get; set; }
        public int DosageValue { get; set; }
        public int BranchId { get; set; }
    }
}
