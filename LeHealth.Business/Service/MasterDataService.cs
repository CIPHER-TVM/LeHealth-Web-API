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
        public string DeleteProfession(int zone)
        {
            return masterdataManager.DeleteProfession(zone);
        }


        public List<AppTypeModel> GetAppType()
        {
            return masterdataManager.GetAppType();
        }
        public string InsertZone(ZoneModel zone)
        {
            return masterdataManager.InsertZone(zone);
        }
        public string DeleteZone(int zoneId)
        {
            return masterdataManager.DeleteZone(zoneId);
        }
        public List<ZoneModel> GetZoneById(int zoneId)
        {
            return masterdataManager.GetZoneById(zoneId);
        }
        public List<ZoneModel> GetAllZone()
        {
            return masterdataManager.GetAllZone();
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
        public string DeleteUserHospital(int id)
        {
            return masterdataManager.DeleteUserHospital(id);
        }


        public string InsertRegScheme(RegSchemeModel RegScheme)
        {
            return masterdataManager.InsertRegScheme(RegScheme);
        }
        public string UpdateRegScheme(RegSchemeModel RegScheme)
        {
            return masterdataManager.UpdateRegScheme(RegScheme);
        }
        public string DeleteRegScheme(int RegSchemeId)
        {
            return masterdataManager.DeleteRegScheme(RegSchemeId);
        }
        public List<RegSchemeModel> GetRegSchemeById(int RegSchemeId)
        {
            return masterdataManager.GetRegSchemeById(RegSchemeId);
        }
        public List<RegSchemeModel> GetAllRegScheme()
        {
            return masterdataManager.GetAllRegScheme();
        }
        //

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
        //

        //Operator Starts Now
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
        //Operator Ends Now

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
        public string DeleteLeadAgent(int la)
        {
            return masterdataManager.DeleteLeadAgent(la);
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
        /// <summary>
        ///Returns  all departments from the hospital as Generic List. Step two in code execution flow
        /// </summary>
        public List<DepartmentModel> GetDepartments(int DeptId)
        {
            return masterdataManager.GetDepartments(DeptId);
        }
        public string InsertUpdateDepartment(DepartmentModel Dept)
        {
            return masterdataManager.InsertUpdateDepartment(Dept);
        }
        public string DeleteDepartment(int DeptId)
        {
            return masterdataManager.DeleteDepartment(DeptId);
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
        public string DeleteConsent(int patientId)
        {
            return masterdataManager.DeleteConsent(patientId);
        }

        public List<CountryModel> GetCountry(int countryDetails)
        {
            return masterdataManager.GetCountry(countryDetails);
        }
        public string InsertUpdateCountry(CountryModel country)
        {
            return masterdataManager.InsertUpdateCountry(country);
        }
        public string DeleteCountry(int patientId)
        {
            return masterdataManager.DeleteCountry(patientId);
        }

    }
}
