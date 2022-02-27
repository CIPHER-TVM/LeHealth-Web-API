using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultantModel
    {
        public string ConsultantName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int DeptId { get; set; }
        public string AppType { get; set; }
        public string ConsultantDate { get; set; }
        public string Status { get; set; }
        public string ConsultantCode { get; set; }
        public int ConsultantId { get; set; }
        public int BranchId { get; set; }
        public int IsExternal { get; set; } 
        public string DeptName { get; set; }
    }
}
