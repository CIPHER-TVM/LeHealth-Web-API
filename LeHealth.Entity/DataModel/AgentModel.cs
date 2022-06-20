using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class AgentModel
    {
        public int AgentId { get; set; }
        public int SponsorId { get; set; }

        public string AgentName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Street { get; set; }
        public string city { get; set; }
        public string PlacePO { get; set; }
        public string PIN { get; set; }
        public string State { get; set; }

        public int CountryId { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string ContactPerson { get; set; }
        public string Remarks { get; set; }
        //public int Active { get; set; }
        //public string BlockReason { get; set; }
        public string DHANo { get; set; }
        public string PayerId { get; set; }
        public int HospitalId { get; set; }
        public int IsDisplayed { get; set; }
        public int IsDeleted { get; set; }
        public int ShowAll { get; set; }
    }
    public class AgentSponsorModel
    {
        public int AgentId { get; set; }
        public string AgentName { get; set; }
    }
}
