using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PatRegByPatientIdModel
    {
        public int RegId { get; set; }
        public String RegDate { get; set; }
        public int PatientId { get; set; }
        public int ItemId { get; set; }
        public int RegAmount { get; set; }
        public String ExpiryDate { get; set; }
        public String ItemName { get; set; }
        public int ExpiryVisits { get; set; }
        public int VisitsMade { get; set; }
        public int Emergency { get; set; }
        public String ConsultDate { get; set; }
        public String ConsultFee { get; set; }
        public bool IsRegistrationExpired { get; set; } 
        public bool IsConsultationExpired { get; set; }  
    }
}
