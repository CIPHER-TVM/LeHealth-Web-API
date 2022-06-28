using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class VitalSignEMRModel
    {
        public int Eid { get; set; }
        public int VisitId { get; set; }

        public string VisitDate { get; set; } 
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int PatientId { get; set; }
        public List<VitalSignEMRData> VitalSignDataList { get; set; }
    }
    public class VitalSignEMRData
    {
        public int VitalSignId { get; set; }
        public string VitalSignName { get; set; }
        public string VitalSignValue { get; set; }  
        public int Eid { get; set; }   
    } 

    public class VitalSignEMRAll
    {
        public int Eid { get; set; } 
        public string CreatedDate { get; set; } 
        public List<VitalSignEMRData> VitalSignData { get; set; }
    }
}
