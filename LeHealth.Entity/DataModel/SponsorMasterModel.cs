using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class SponsorMasterModel
    {

       
        public int SponsorId { get; set; }
        public string SponsorName { get; set; }
        public int SponsorType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }       
		
        public string Street { get; set; }
        public string PlacePo { get; set; }
        public string Pin { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int CountryId { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string ContactPerson { get; set; }
        public float DedAmount { get; set; }      
		public Double CoPayPcnt { get; set; }
        public string Remarks { get; set; }
        public int SFormId { get; set; }
        public Double SponsorLimit { get; set; }
        public string DhaNo { get; set; }
        public int EnableSponsorLimit { get; set; }  		
        public int EnableSponsorConsent { get; set; }        
        public string AuthorizationMode { get; set; }
        public string URL { get; set; }
        public int SortOrder { get; set; }        
        public int PartyId { get; set; }
        public int UnclaimedId { get; set; }
       
        //public int HeadId { get; set; }

    }
    public class SponsorMasterModelAll : SponsorMasterModel
    {
        public List<AgentforSponsorModel> AgentforSponsorList { get; set; }
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
        public int SessionId { get; set; }
    }
    public class AgentforSponsorModel
    {
         public int Agentid { get; set; }
    }
}
