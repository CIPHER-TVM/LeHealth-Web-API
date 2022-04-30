using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class CompanyModel
    {
        public int CmpId { get; set; }
        public string CmpName { get; set; }
        public int UserId { get; set; } 
    }
    public class CompanyModelAll : CompanyModel
    {
        public int BranchId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
