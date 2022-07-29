using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface ISponsorManager
    {
        //
        List<SponsorTypeModel> GetSponsorTypeByID(SponsorTypeModel details);
        string InsertUpdateSponsorRule(SponsorRuleModel details);
        List<SponsorFormModel> GetSponsorForm(SponsorFormModel frm);

        string InsertUpdateSponsorForms(SponsorFormModel frm);
        string InsertSponsorRuleGroup(SponsorGroupModel itm);
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
        List<SponsorRuleModel> GetSponsorRule(SponsorRuleModel sponsorruleid);
       // List<SponsorMasterModel> GetSponsorById(SponsorMasterModelAll sponsorid);
        List<SponsorMasterModel> GetSponsor(SponsorMasterModelAll sponsorid);
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
