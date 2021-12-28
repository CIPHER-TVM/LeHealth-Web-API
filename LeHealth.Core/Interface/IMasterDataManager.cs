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
        List<SponsorMasterModel> GetSponsor(int sponsorid);
        string InsertUpdateSponsor(SponsorMasterModel sponsor);

        //Zone Management starts
        string InsertUpdateZone(ZoneModel zone);
        List<ZoneModel> GetZone(int zoneId);
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
        string InsertUpdateRegScheme(RegSchemeModel RegScheme);
        string DeleteRegScheme(int RegSchemeId);
        List<RegSchemeModel> GetRegScheme(int RegSchemeId);
        List<RegSchemeModel> GetAllRegScheme();
        //Scheme management Ends
        //Hospital Managemnt Starts
        List<HospitalModel> GetUserHospitals(int id);
        string InsertUpdateUserHospital(HospitalRegModel hm);
        //Hospital Managemnt Ends
        //Lead Agent Management Starts
        List<LeadAgentModel> GetLeadAgent(int la);
        string InsertUpdateLeadAgent(LeadAgentModel la);
        //Lead Agent Management Ends
        //Company Management Starts
        List<CompanyModel> GetCompany(int Id);
        string InsertUpdateCompany(CompanyModel cmp);
        string DeleteCompany(int Id);
        //Company Management Ends


        //DEPARTMENT MANAGEMENT STARTS
        List<DepartmentModel> GetDepartments(int DeptId);
        string InsertUpdateDepartment(DepartmentModel Dept);
        //DEPARTMENT MANAGEMENT ENDS

        //Consent Management starts
        List<ConsentPreviewModel> GetConsentPreviewConsent(int consentId);
        List<ConsentContentModel> GetConsent(int consentId);
        string InsertUpdateConsent(ConsentContentModel consent);

        //Consent Management ends
        List<CountryModel> GetCountry(int countryDetails);
        string InsertUpdateCountry(CountryModel countryDetails);
        List<StateModel> GetState(int stateDetails);
        string InsertUpdateState(StateModel stateDetails);
        List<SalutationModel> GetSalutation(int salutationDetails);
        string InsertUpdateSalutation(SalutationModel salutationDetails);
        List<BodyPartModel> GetBodyPart(int bodyPartId);
        string InsertUpdateBodyPart(BodyPartModel bodyPart);
        List<SponsorTypeModel> GetSponsorType(int sponsorType);
        string InsertUpdateSponsorType(SponsorTypeModel sponsorType);

        List<SponsorFormModel> GetSponsorForm(int sponsorForm);
        string InsertUpdateSponsorForm(SponsorFormModel sponsorForm);
        List<CityModel> GetCity(int city);
        string InsertUpdateCity(CityModel city);

        List<AppTypeModel> GetAppType();
        List<ReligionModel> GetReligion();

        List<VisaTypeModel> GetVisaType();
        List<StateModel> GetStateByCountryId(int countryId);
        List<SymptomModel> GetActiveSymptoms();
        List<ItemsByTypeModel> GetItemsByType(ItemsByTypeModel ibt);
        List<ConsentTypeModel> GetConsentType();
    }
}
