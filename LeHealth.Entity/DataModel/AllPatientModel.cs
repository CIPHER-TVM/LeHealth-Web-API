using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class AllPatientModel
    {
        public int PatientId { get; set; }
        public List<RegDocLocationModel> RegDocLocation { get; set; }
        public string RegNo { get; set; }
        public string RegDate { get; set; }
        public string PatientName { get; set; }
        public int Gender { get; set; }
        public string GenderName { get; set; }
        public string Age { get; set; }
        public string AgeInYears { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string SponsorName { get; set; }
        public string Consultant { get; set; }
        public string PolicyNo { get; set; }
        public string EmiratesId { get; set; }
        public string SponsorId { get; set; }
        public string Pin { get; set; }
        public int Active { get; set; }
    }
}
