using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class NarrativeDiagnosisICDModel 
    {
        public int Nid { get; set; } 
        public string NarrativeDiagnosis { get; set; }  
        public int VisitId { get; set; } 
        public int PatientId { get; set; } 
        public int ShowAll { get; set; }  
        public int UserId { get; set; }
        public string VisitDate { get; set; }
        public string CatgDesc { get; set; }
        public List<ICDModel> IcdLabelList { get; set; } 
    }
}
