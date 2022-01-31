using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public class DepartmentModel
    {
        public Int32 DeptId { get; set; }
        public String DeptName { get; set; }
        public String DeptCode { get; set; }
        public String Description { get; set; }
        public int TimeSlice { get; set; }
        public int Active { get; set; }
        public int BranchId { get; set; }
        public String BlockReason { get; set; }
        public int UserId { get; set; } 


    }
}
