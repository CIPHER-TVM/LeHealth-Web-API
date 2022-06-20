using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.Service
{
    public class SponsorService :ISponsorService
    {
        private readonly ISponsorManager sponsermanager;

        
        public SponsorService(ISponsorManager _sponsermanager)
        {
            sponsermanager = _sponsermanager;
        }
        //public SponsorModel GetSponserById(Int32 SponsorId)
        //{
        //    return sponsermanager.GetSponserById(SponsorId);
        //}

        public SponserConsentModelAll GetSponserConsentById(Int32 ContentId)
        {
            return sponsermanager.GetSponserConsentById(ContentId);
        }
        public List<SponserConsentModel> GetSponsorConsent(Int32 Branchid)
        {
            return sponsermanager.GetSponsorConsent(Branchid);
        }
        public List<SponsorTypeModel> GetSponsorTypes()
        {
            return sponsermanager.GetSponsorTypes();
        }
        public List<SponsorFormModel> GetSponsorForms()
        {
            return sponsermanager.GetSponsorForms();
        }

        public string InsertUpdateSponsor(SponsorMasterModelAll obj)
        {
            return sponsermanager.InsertUpdateSponsor(obj);
        }

        public string DeleteAgentSponsor(SponsorModel obj)
        {
            return sponsermanager.DeleteAgentSponsor(obj);
        }

        public string InsertAgentSponsor(SponsorModel obj)
        {
            return sponsermanager.InsertAgentSponsor(obj);
        }

        

        public List<SponsorMasterModelAll> GetAllSponsors(Int32 Branchid)
        {
            return sponsermanager.GetAllSponsors(Branchid);
        }
        
        public string InsertUpdateSponsorConsent(SponserConsentModelAll obj)
        {
            return sponsermanager.InsertUpdateSponsorConsent(obj);
        }

    }
}
