using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Service.ServiceInterface;
using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;

namespace LeHealth.Service.Service
{
    public class MasterDataService : IMasterDataService
    {
        private readonly IMasterDataManager masterdataManager;
        private readonly IFileUploadService fileUploadService;
        public MasterDataService(IMasterDataManager _masterdataManager, IFileUploadService _fileUploadService)
        {
            masterdataManager = _masterdataManager;
            fileUploadService = _fileUploadService;
        }

        public List<ProfessionModel> GetProfession(int profid)
        {
            return masterdataManager.GetProfession(profid);
        }
        public string InsertUpdateProfession(ProfessionModel zone)
        {
            return masterdataManager.InsertUpdateProfession(zone);
        }
        public List<SponsorMasterModel> GetSponsor(int profid)
        {
            return masterdataManager.GetSponsor(profid);
        }
        public string InsertUpdateSponsor(SponsorMasterModel zone)
        {
            return masterdataManager.InsertUpdateSponsor(zone);
        }

        public List<SponsorTypeModel> GetSponsorType(int id)
        {
            return masterdataManager.GetSponsorType(id);
        }
        public string InsertUpdateSponsorType(SponsorTypeModel stype)
        {
            return masterdataManager.InsertUpdateSponsorType(stype);
        }

        public List<SponsorFormModel> GetSponsorForm(int id)
        {
            return masterdataManager.GetSponsorForm(id);
        }
        public string InsertUpdateSponsorForm(SponsorFormModel stype)
        {
            return masterdataManager.InsertUpdateSponsorForm(stype);
        }

        public List<CityModel> GetCity(int id)
        {
            return masterdataManager.GetCity(id);
        }
        public string InsertUpdateCity(CityModel city)
        {
            return masterdataManager.InsertUpdateCity(city);
        }
        public List<AppTypeModel> GetAppType()
        {
            return masterdataManager.GetAppType();
        }
        public string InsertUpdateZone(ZoneModel zone)
        {
            return masterdataManager.InsertUpdateZone(zone);
        }

        public List<ZoneModel> GetZone(int zoneId)
        {
            return masterdataManager.GetZone(zoneId);
        }
        //
        /// <summary>
        /// To list of all hospital details .Step two in code execution flow
        /// </summary>
        public List<HospitalModel> GetUserHospitals(int id)
        {
            return masterdataManager.GetUserHospitals(id);
        }
        public string InsertUpdateUserHospitals(HospitalRegModel hm)
        {
            if (hm.LogoFile != null)
            {
                hm.Logo = fileUploadService.SaveFile(hm.LogoFile);
            }
            if (hm.ReportLogoFile != null)
            {
                hm.ReportLogo = fileUploadService.SaveFile(hm.LogoFile);
            }
            return masterdataManager.InsertUpdateUserHospital(hm);
        }
        public string InsertUpdateRegScheme(RegSchemeModel RegScheme)
        {
            return masterdataManager.InsertUpdateRegScheme(RegScheme);
        }
        public string DeleteRegScheme(int RegSchemeId)
        {
            return masterdataManager.DeleteRegScheme(RegSchemeId);
        }
        public List<RegSchemeModel> GetRegScheme(int RegSchemeId)
        {
            return masterdataManager.GetRegScheme(RegSchemeId);
        }
        public List<RegSchemeModel> GetAllRegScheme()
        {
            return masterdataManager.GetAllRegScheme();
        }
        public string InsertRateGroup(RateGroupModel RateGroup)
        {
            return masterdataManager.InsertRateGroup(RateGroup);
        }
        public string UpdateRateGroup(RateGroupModel RateGroup)
        {
            return masterdataManager.UpdateRateGroup(RateGroup);
        }
        public string DeleteRateGroup(int RateGroupId)
        {
            return masterdataManager.DeleteRateGroup(RateGroupId);
        }
        public List<RateGroupModel> GetRateGroupById(int RateGroupId)
        {
            return masterdataManager.GetRateGroupById(RateGroupId);
        }
        public List<RateGroupModel> GetAllRateGroup()
        {
            return masterdataManager.GetAllRateGroup();
        }
        public string InsertOperator(OperatorModel Operator)
        {
            return masterdataManager.InsertOperator(Operator);
        }
        public string UpdateOperator(OperatorModel Operator)
        {
            return masterdataManager.UpdateOperator(Operator);
        }
        public string DeleteOperator(int OperatorId)
        {
            return masterdataManager.DeleteOperator(OperatorId);
        }
        public List<OperatorModel> GetOperatorById(int OperatorId)
        {
            return masterdataManager.GetOperatorById(OperatorId);
        }
        public List<OperatorModel> GetAllOperator()
        {
            return masterdataManager.GetAllOperator();
        }
        public List<ReligionModel> GetReligion()
        {
            return masterdataManager.GetReligion();
        }
        public List<LeadAgentModel> GetLeadAgent(int la)
        {
            return masterdataManager.GetLeadAgent(la);
        }
        public string InsertUpdateLeadAgent(LeadAgentModel la)
        {
            return masterdataManager.InsertUpdateLeadAgent(la);
        }
        public List<CompanyModel> GetCompany(int Id)
        {
            return masterdataManager.GetCompany(Id);
        }
        public string InsertUpdateCompany(CompanyModel cmp)
        {
            return masterdataManager.InsertUpdateCompany(cmp);
        }
        public string DeleteCompany(int Id)
        {
            return masterdataManager.DeleteCompany(Id);
        }
        public List<BodyPartModel> GetBodyPart(int Id)
        {
            return masterdataManager.GetBodyPart(Id);
        }
        public string InsertUpdateBodyPart(BodyPartModel cmp)
        {
            return masterdataManager.InsertUpdateBodyPart(cmp);
        }
        public List<DepartmentModel> GetDepartments(int DeptId)
        {
            return masterdataManager.GetDepartments(DeptId);
        }
        public string InsertUpdateDepartment(DepartmentModel Dept)
        {
            return masterdataManager.InsertUpdateDepartment(Dept);
        }
        public List<ConsentPreviewModel> GetConsentPreviewConsent(int patientId)
        {
            return masterdataManager.GetConsentPreviewConsent(patientId);
        }
        public List<ConsentContentModel> GetConsent(int patientId)
        {
            return masterdataManager.GetConsent(patientId);
        }
        public string InsertUpdateConsent(ConsentContentModel consent)
        {
            return masterdataManager.InsertUpdateConsent(consent);
        }
        public List<CountryModel> GetCountry(int countryDetails)
        {
            return masterdataManager.GetCountry(countryDetails);
        }
        public string InsertUpdateCountry(CountryModel country)
        {
            return masterdataManager.InsertUpdateCountry(country);
        }
        public List<StateModel> GetState(int stateDetails)
        {
            return masterdataManager.GetState(stateDetails);
        }
        public string InsertUpdateState(StateModel state)
        {
            return masterdataManager.InsertUpdateState(state);
        }
        public List<SalutationModel> GetSalutation(int stateDetails)
        {
            return masterdataManager.GetSalutation(stateDetails);
        }
        public string InsertUpdateSalutation(SalutationModel state)
        {
            return masterdataManager.InsertUpdateSalutation(state);
        }
        public List<VisaTypeModel> GetVisaType()
        {
            return masterdataManager.GetVisaType();
        }
        public List<StateModel> GetStateByCountryId(int countryid)
        {
            return masterdataManager.GetStateByCountryId(countryid);
        }
        public List<SymptomModel> GetActiveSymptoms()
        {
            return masterdataManager.GetActiveSymptoms();
        }
        public List<ItemsByTypeModel> GetItemsByType(ItemsByTypeModel ibt)
        {
            return masterdataManager.GetItemsByType(ibt);
        }
        public List<ConsentTypeModel> GetConsentType()
        {
            return masterdataManager.GetConsentType();
        }
    }
}
