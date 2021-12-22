using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public class DepartmentModel
    {
        public Int32 DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptCode { get; set; }
        public string Description { get; set; }
        public string TimeSlice { get; set; }
        public int Active { get; set; }
        public int BranchId { get; set; }
        public string BlockReason { get; set; }
        public int UserId { get; set; } 


    }
}
