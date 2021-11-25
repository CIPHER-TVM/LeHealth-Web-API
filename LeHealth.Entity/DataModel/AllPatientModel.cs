using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class AllPatientModel
    {
        public int PatientId { get; set; }
        public string RegNo { get; set; }
        public DateTime RegDate { get; set; } 
        public string PatientName { get; set; }
        public string RegisteredDate { get; set; } 
        public string Gender { get; set; } 
        public string Age { get; set; }
        public string AgeInYears { get; set; } 
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string SponsorName { get; set; }
        public string Consultant { get; set; }
        public string PolicyNo { get; set; }
        public string EmiratesId { get; set; }
        public string SponsorId { get; set; }
        public int Active { get; set; } 
    }
}
