using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class AllPatientModel
    {
        public int PatientId { get; set; }
        public List<RegDocLocationModel> RegDocLocation { get; set; }
        public String RegNo { get; set; }
        public String RegDate { get; set; }
        public String PatientName { get; set; }
        public int Gender { get; set; }
        public String GenderName { get; set; }
        public String Age { get; set; }
        public String AgeInYears { get; set; }
        public String Mobile { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
        public String SponsorName { get; set; }
        public String Consultant { get; set; }
        public String PolicyNo { get; set; }
        public String EmiratesId { get; set; }
        public String SponsorId { get; set; }
        public String Pin { get; set; }
        public int Active { get; set; }
    }
}
