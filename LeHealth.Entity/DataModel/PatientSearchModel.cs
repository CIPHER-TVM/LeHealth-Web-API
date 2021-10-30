using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PatientSearchModel
    {
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string PIN { get; set; }
        public string PolicyNo { get; set; }
        public string RegNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string IdentityNo { get; set; }
        public string EmiratesId { get; set; } 
        public string RegDateFrom { get; set; } 
        public string RegDateTo { get; set; } 
        public int ConsultantId { get; set; }
        public int BranchId { get; set; }

        public string ResNo { get; set; } 
        public string Mode { get; set; } 
    }
}
