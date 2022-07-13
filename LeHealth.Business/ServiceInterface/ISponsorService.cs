using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;

namespace LeHealth.Service.ServiceInterface
{
    public interface ISponsorService
    {
        List<SponsorFormModel> GetSponsorForm(SponsorFormModel itm);

        string InsertUpdateSponsorForms(SponsorFormModel frm);
        string InsertSponsorRuleGroup(SponsorGroupModel grp);
        string DeleteSponsorRuleItem(SponsorGropuServiceItemModel itm);
        string InsertSponsorRuleItem(SponsorGropuServiceItemModel itm);

        List<SponsorGropuServiceItemModel> GetSponsorItemForRule(SponsorGropuServiceItemModel itm);

        List<SponsorGroupModel> GetSponsorGroupForRule(SponsorGroupModel grp);

        List<SponsorRuleModel> GetRuleDescription(SponsorRuleModel ruledesc);

        string DeleteConsultantReduction(ConsultantReductionModel creduction);

        string InsertConsultantReduction(ConsultantReductionModel creduction);
        List<ConsultantReductionModel> GetConsultantReduction(ConsultantReductionModel creduction);
        string DeleteSponsorRuleDrugList(DrugModelAll drug);
        string InsertSponsorRuleDrugList(DrugModelAll drug);

        List<DrugModelAll> GetDrugBySponsorRule(DrugModelAll drug);
        List<SponsorRuleModel> GetSponsorRule(SponsorRuleModel sponsor);
        //List<SponsorMasterModel> GetSponsorById(SponsorMasterModelAll sponsor);
        List<SponsorMasterModel> GetSponsor(SponsorMasterModelAll sponsor);
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
