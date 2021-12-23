using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;


namespace LeHealth.Core.Interface
{
    public interface IMasterDataManager
    {

        List<ProfessionModel> GetProfession(int profid);
        string InsertUpdateProfession(ProfessionModel prof);
        string DeleteProfession(int profid);
        
        //Zone Management starts
        string InsertZone(ZoneModel zone);
        string DeleteZone(int zoneId);
        List<ZoneModel> GetZoneById(int zoneId);
        List<ZoneModel> GetAllZone();
        //Zone Management ends

        //Rate Group management starts
        string InsertRateGroup(RateGroupModel RateGroup);
        string UpdateRateGroup(RateGroupModel RateGroup);
        string DeleteRateGroup(int RateGroupId);
        List<RateGroupModel> GetRateGroupById(int RateGroupId);
        List<RateGroupModel> GetAllRateGroup();
        //Rate Group management ends
        //Operator Management Starts
        string InsertOperator(OperatorModel Operator);
        string UpdateOperator(OperatorModel Operator);
        string DeleteOperator(int OperatorId);
        List<OperatorModel> GetOperatorById(int OperatorId);
        List<OperatorModel> GetAllOperator();
        //Operator Management Ends

        //Scheme management Starts
        string InsertRegScheme(RegSchemeModel RegScheme);
        string UpdateRegScheme(RegSchemeModel RegScheme);
        string DeleteRegScheme(int RegSchemeId);
        List<RegSchemeModel> GetRegSchemeById(int RegSchemeId);
        List<RegSchemeModel> GetAllRegScheme();
        //Scheme management Ends
        //Hospital Managemnt Starts
        List<HospitalModel> GetUserHospitals(int id);
        string InsertUpdateUserHospital(HospitalRegModel hm);
        string DeleteUserHospital(int id);
        //Hospital Managemnt Ends
        //Lead Agent Management Starts
        List<LeadAgentModel> GetLeadAgent(int la);
        string InsertUpdateLeadAgent(LeadAgentModel la);
        string DeleteLeadAgent(int la);
        //Lead Agent Management Ends
        //Company Management Starts
        List<CompanyModel> GetCompany(int Id);
        string InsertUpdateCompany(CompanyModel cmp);
        string DeleteCompany(int Id);
        //Company Management Ends


        //DEPARTMENT MANAGEMENT STARTS
        List<DepartmentModel> GetDepartments(int DeptId);
        string InsertUpdateDepartment(DepartmentModel Dept);
        string DeleteDepartment(int DeptId);
        //DEPARTMENT MANAGEMENT ENDS

        //Consent Management starts
        List<ConsentPreviewModel> GetConsentPreviewConsent(int consentId); 
        List<ConsentContentModel> GetConsent(int consentId); 
        string InsertUpdateConsent(ConsentContentModel consent);
        string DeleteConsent(int consentId);

        //Consent Management ends

        List<CountryModel> GetCountry(int countryDetails);
        string InsertUpdateCountry(CountryModel countryDetails);
        string DeleteCountry(int countryDetails);

        List<AppTypeModel> GetAppType();
        List<ReligionModel> GetReligion();
    }
}
