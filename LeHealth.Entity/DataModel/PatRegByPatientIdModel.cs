using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PatRegByPatientIdModel
    {
        public int RegId { get; set; }
        public string RegDate { get; set; }
        public int PatientId { get; set; }
        public int ItemId { get; set; }
        public int RegAmount { get; set; }
        public string ExpiryDate { get; set; }
        public string ItemName { get; set; }
        public int ExpiryVisits { get; set; }
        public int VisitsMade { get; set; }
        public int Emergency { get; set; }
        public string ConsultDate { get; set; }
        public string ConsultFee { get; set; }
        public bool IsRegistrationExpired { get; set; } 
        public bool IsConsultationExpired { get; set; }  
    }
}
