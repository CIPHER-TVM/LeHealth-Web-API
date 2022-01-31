using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultantModel
    {
        public String ConsultantName { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public int DeptId { get; set; }
        public String AppType { get; set; }
        public String ConsultantDate { get; set; }
        public String Status { get; set; }
        public String ConsultantCode { get; set; }
        public int ConsultantId { get; set; }
        public int BranchId { get; set; }
        public String DeptName { get; set; }
    }
}
