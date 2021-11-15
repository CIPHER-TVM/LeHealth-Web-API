using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class CompanyModel
    {
        public int CmpId { get; set; }
        public String CmpName { get; set; }
        public int Active { get; set; }
        public String BlockReason { get; set; }
    }
}
