using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface ISponsorManager
    {
        
        SponserConsentModelAll GetSponserConsentById(Int32 ContentId);
        List<SponserConsentModel> GetSponsorConsent(Int32 Branchid);
        List<SponsorTypeModel> GetSponsorTypes();
        List<SponsorFormModel> GetSponsorForms();
        string InsertUpdateSponsor(SponsorMasterModelAll obj);
        string DeleteAgentSponsor(SponsorModel obj);
        string InsertAgentSponsor(SponsorModel obj);

        List<SponsorMasterModelAll> GetAllSponsors(Int32 Branchid);
        
        string InsertUpdateSponsorConsent(SponserConsentModelAll obj);
    }
}
