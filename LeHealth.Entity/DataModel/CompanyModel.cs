using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class CompanyModel
    {
        public int CmpId { get; set; }
        public string CmpName { get; set; }
        public int Active { get; set; }
        public string BlockReason { get; set; }
        public int UserId { get; set; } 
    }
}
