using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public  class PatientListModel
    {
        public int PatientId { get; set; }
        public string Patient { get; set; }
        public string Salutation { get; set; } 
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Status { get; set; }
        public int Age { get; set; }
        public string RegNo { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Sponsor { get; set; }
        public string Consultant { get; set; }
        public string PolicyNo { get; set; }
        public string EmiratesId { get; set; }
        public string Email { get; set; }
        public string EmirateID { get; set; }
        public string SponsorId { get; set; }
        public string TextForSearch { get; set; }
        public int Active { get; set; }
        public string BlockReason { get; set; } 


    }
}
