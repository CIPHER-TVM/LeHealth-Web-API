using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;


namespace LeHealth.Service.ServiceInterface
{
    public interface IMasterDataService
    {
        //Profession Management Starts
        List<ProfessionModel> GetProfession(int profid);
        string InsertUpdateProfession(ProfessionModel prof);
        string DeleteProfession(int profId);
        //Profession Management Ends
        //Sponsor Management Starts
        List<SponsorMasterModel> GetSponsor(int sponsorid);
        string InsertUpdateSponsor(SponsorMasterModel sponsor);
        string DeleteSponsor(int sponsorId);
        //Sponsor Management Starts

        List<HospitalModel> GetUserHospitals(int id);
        string InsertUpdateUserHospitals(HospitalRegModel hm);
        string DeleteUserHospital(int id);

        List<ConsentPreviewModel> GetConsentPreviewConsent(int id);
        List<ConsentContentModel> GetConsent(int id);
        string InsertUpdateConsent(ConsentContentModel hm);
        string DeleteConsent(int id);

        List<ConsentContentModel> GetSponsorConsent(int id);
        string InsertUpdateSponsorConsent(ConsentContentModel hm);
        string DeleteSponsorConsent(int id);

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

        List<CountryModel> GetCountry(int countryDetail);
        string InsertUpdateCountry(CountryModel countryDetail);
        string DeleteCountry(int countryDetail);

        List<StateModel> GetState(int stateDetail);
        string InsertUpdateState(StateModel stateDetail);
        string DeleteState(int stateDetail);

        List<SalutationModel> GetSalutation(int stateDetail);
        string InsertUpdateSalutation(SalutationModel stateDetail);
        string DeleteSalutation(int stateDetail);

        List<BodyPartModel> GetBodyPart(int stateDetail);
        string InsertUpdateBodyPart(BodyPartModel stateDetail);
        string DeleteBodyPart(int stateDetail);

        List<SponsorTypeModel> GetSponsorType(int sponsorType);
        string InsertUpdateSponsorType(SponsorTypeModel sponsorType);
        string DeleteSponsorType(int sponsorType);

        List<SponsorFormModel> GetSponsorForm(int sponsorForm);
        string InsertUpdateSponsorForm(SponsorFormModel sponsorForm);
        string DeleteSponsorForm(int sponsorForm);

        List<CityModel> GetCity(int city);
        string InsertUpdateCity(CityModel city);
        string DeleteCity(int cityId); 


        List<VisaTypeModel> GetVisaType();
        List<StateModel> GetStateByCountryId(int countryId);
        List<SymptomModel> GetActiveSymptoms();
        List<ItemsByTypeModel> GetItemsByType(ItemsByTypeModel ibt);
    }
}
