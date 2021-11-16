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
        public bool IsRegistrationExpired { get; set; } 
    }
}
