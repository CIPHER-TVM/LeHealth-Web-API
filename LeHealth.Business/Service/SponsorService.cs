using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;

namespace LeHealth.Service.Service
{
    public class SponsorService :ISponsorService
    {
        private readonly ISponsorManager sponsermanager;
        public SponsorService(ISponsorManager _sponsermanager)
        {
            sponsermanager = _sponsermanager;
        }

        public List<SponsorFormModel> GetSponsorForm(SponsorFormModel frm)
        {
            return sponsermanager.GetSponsorForm(frm);
        }
        public string InsertUpdateSponsorForms(SponsorFormModel frm)
        {
            return sponsermanager.InsertUpdateSponsorForms(frm);
        }

        public string InsertSponsorRuleGroup(SponsorGroupModel grp)
        {
            return sponsermanager.InsertSponsorRuleGroup(grp);
        }
        public string DeleteSponsorRuleItem(SponsorGropuServiceItemModel itm)
        {
            return sponsermanager.DeleteSponsorRuleItem(itm);
        }
        public string InsertSponsorRuleItem(SponsorGropuServiceItemModel itm)
        {
            return sponsermanager.InsertSponsorRuleItem(itm);
        }

      

        public List<SponsorGropuServiceItemModel> GetSponsorItemForRule(SponsorGropuServiceItemModel itm)
        {
            return sponsermanager.GetSponsorItemForRule(itm);
        }

        public List<SponsorGroupModel> GetSponsorGroupForRule(SponsorGroupModel grp)
        {
            return sponsermanager.GetSponsorGroupForRule(grp);
        }


        public List<SponsorRuleModel> GetRuleDescription(SponsorRuleModel ruledesc)
        {
            return sponsermanager.GetRuleDescription(ruledesc);
        }

        public string DeleteConsultantReduction(ConsultantReductionModel creduction)
        {
            return sponsermanager.DeleteConsultantReduction(creduction);
        }

        public string InsertConsultantReduction(ConsultantReductionModel creduction)
        {
            return sponsermanager.InsertConsultantReduction(creduction);
        }
        public List<ConsultantReductionModel> GetConsultantReduction(ConsultantReductionModel creduction)
        {
            return sponsermanager.GetConsultantReduction(creduction);
        }
        public string DeleteSponsorRuleDrugList(DrugModelAll drug)
        {
            return sponsermanager.DeleteSponsorRuleDrugList(drug);
        }
        public string InsertSponsorRuleDrugList(DrugModelAll drug)
        {
            return sponsermanager.InsertSponsorRuleDrugList(drug);
        }
        public List<DrugModelAll> GetDrugBySponsorRule(DrugModelAll drug)
        {
            return sponsermanager.GetDrugBySponsorRule(drug);
        }

        public List<SponsorRuleModel> GetSponsorRule(SponsorRuleModel sponsorrule)
        {
            return sponsermanager.GetSponsorRule(sponsorrule);
        }

        public List<SponsorMasterModel> GetSponsorById(SponsorMasterModelAll sponsor)
        {
            return sponsermanager.GetSponsorById(sponsor);
        }


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
