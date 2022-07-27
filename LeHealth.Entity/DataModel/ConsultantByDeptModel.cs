using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultantByDeptModel
    {
        //public string DeptId { get; set; }
        public int DeptId { get; set; }
        //public int ShowExternal { get; set; } 
        public bool ShowExternal { get; set; } 
        public int BranchId { get; set; }
    }
}
