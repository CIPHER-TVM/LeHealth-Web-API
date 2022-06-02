using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class LedgerHeadModel
    {
        public int HeadId { get; set; }
        public string HeadDesc { get; set; }
        public int HeadType { get; set; }
        public string State { get; set; }
        public bool IsDisplayed { get; set; }
    }
    public class LedgerHeadModelAll : LedgerHeadModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        
    }
}
