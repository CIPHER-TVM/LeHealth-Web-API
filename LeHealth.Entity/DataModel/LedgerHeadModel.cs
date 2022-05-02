using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class LedgerHeadModel
    {
        public int MyProperty { get; set; }
     
    }
    public class LedgerHeadModelAll : LedgerHeadModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
