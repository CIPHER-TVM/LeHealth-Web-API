using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultantPatientModel
    {

        public int PatientId { get; set; }
        public string RegNo { get; set; }
        public string RegDate { get; set; }
        public string PatientName { get; set; }
        public string AgeInYears { get; set; }
        public int Gender { get; set; }
        public string GenderName { get; set; }
        public string Email { get; set; }
        public string ConsultantId { get; set; }
        public string BranchId { get; set; }
        public string Age { get; set; }
        public string PIN { get; set; }
        public string Consultant { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string SponsorName { get; set; }
        public int SponsorId { get; set; }
        public bool EnableSponsorConsent { get; set; }
        public string PolicyNo { get; set; }
        public string EmiratesID { get; set; }
        public int Active { get; set; }
    }
}
