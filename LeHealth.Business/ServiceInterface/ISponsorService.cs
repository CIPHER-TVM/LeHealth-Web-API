using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface ISponsorService
    {
        List<SponsorTypeModel> GetSponsorTypes();
        List<SponsorFormModel> GetSponsorForms();
        List<SponsorMasterModelAll> GetAllSponsors(Int32 BranchId);
        string InsertUpdateSponsor(SponsorMasterModelAll obj);
        string DeleteAgentSponsor(SponsorModel obj);
        string InsertAgentSponsor(SponsorModel obj);

        string InsertUpdateSponsorConsent(SponserConsentModelAll obj);
        List<SponserConsentModel> GetSponsorConsent(Int32 Branchid);

        SponserConsentModelAll GetSponserConsentById(Int32 ContentId);

    }
}
