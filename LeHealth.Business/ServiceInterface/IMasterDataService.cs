using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;


namespace LeHealth.Service.ServiceInterface
{
    public interface IMasterDataService
    {
        List<ProfessionModel> GetProfession(int profid);
        string InsertUpdateProfession(ProfessionModel prof);
        string DeleteProfession(int profId);  
        List<HospitalModel> GetUserHospitals(int id);
        string InsertUpdateUserHospitals(HospitalRegModel hm);
        string DeleteUserHospital(int id);

        List<AppTypeModel> GetAppType();
        List<ReligionModel> GetReligion();
        //string SendAddPatientInformation(int patientId);
        string InsertZone(ZoneModel zone);
        string DeleteZone(int zoneId);
        List<ZoneModel> GetZoneById(int zoneId);
        List<ZoneModel> GetAllZone();

        string InsertRateGroup(RateGroupModel RateGroup);
        string UpdateRateGroup(RateGroupModel RateGroup);
        string DeleteRateGroup(int RateGroupId);
        List<RateGroupModel> GetRateGroupById(int RateGroupId);
        List<RateGroupModel> GetAllRateGroup();
         string InsertOperator(OperatorModel Operator);
        string UpdateOperator(OperatorModel Operator);
        string DeleteOperator(int OperatorId);
        List<OperatorModel> GetOperatorById(int OperatorId);
        List<OperatorModel> GetAllOperator();

        string InsertRegScheme(RegSchemeModel RegScheme);
        string UpdateRegScheme(RegSchemeModel RegScheme);
        string DeleteRegScheme(int RegSchemeId);
        List<RegSchemeModel> GetRegSchemeById(int RegSchemeId);
        List<RegSchemeModel> GetAllRegScheme(); 
        List<DepartmentModel> GetDepartments(int DeptId);
        string InsertUpdateDepartment(DepartmentModel Dept);
        string DeleteDepartment(int DeptId);

        List<LeadAgentModel> GetLeadAgent(int la);
        string InsertUpdateLeadAgent(LeadAgentModel la);
        string DeleteLeadAgent(int la);

        List<CompanyModel> GetCompany(int Id);
        string DeleteCompany(int Id);
        string InsertUpdateCompany(CompanyModel cmp); 

    }
}
