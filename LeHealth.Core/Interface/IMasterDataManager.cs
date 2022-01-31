using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;


namespace LeHealth.Core.Interface
{
    public interface IMasterDataManager
    {

        List<ProfessionModel> GetProfession(int profid);
        String InsertUpdateProfession(ProfessionModel prof);
        List<SponsorMasterModel> GetSponsor(int sponsorid);
        String InsertUpdateSponsor(SponsorMasterModel sponsor);

        //Zone Management starts
        String InsertUpdateZone(ZoneModel zone);
        List<ZoneModel> GetZone(int zoneId);
        //Zone Management ends

        //Rate Group management starts
        String InsertUpdateRateGroup(RateGroupModel RateGroup);
        List<RateGroupModel> GetRateGroup(int RateGroupId);
        //Rate Group management ends
        //Operator Management Starts
        String InsertUpdateOperator(OperatorModel Operator);
        List<OperatorModel> GetOperator(int OperatorId);
        //Operator Management Ends

        //Scheme management Starts
        String InsertUpdateRegScheme(RegSchemeModel RegScheme);
        List<RegSchemeModel> GetRegScheme(int RegSchemeId);
        //Scheme management Ends
        //Hospital Managemnt Starts
        List<HospitalModel> GetUserHospitals(int id);
        String InsertUpdateUserHospital(HospitalRegModel hm);
        String ConsentFormDataSave(ConsentFormRegModel hm);
        //Hospital Managemnt Ends
        //Lead Agent Management Starts
        List<LeadAgentModel> GetLeadAgent(int la);
        String InsertUpdateLeadAgent(LeadAgentModel la);
        //Lead Agent Management Ends
        //Company Management Starts
        List<CompanyModel> GetCompany(int Id);
        String InsertUpdateCompany(CompanyModel cmp);
        //Company Management Ends


        //DEPARTMENT MANAGEMENT STARTS
        List<DepartmentModel> GetDepartments(int DeptId);
        List<DepartmentModel> GetDepartmentByHospital(int HospId);
        String InsertUpdateDepartment(DepartmentModel Dept);
        //DEPARTMENT MANAGEMENT ENDS

        //Consent Management starts
        List<ConsentPreviewModel> GetConsentPreviewConsent(int consentId);
        List<ConsentContentModel> GetConsent(int consentId);
        String InsertUpdateConsent(ConsentContentModel consent);

        //Consent Management ends
        List<CountryModel> GetCountry(int countryDetails);
        String InsertUpdateCountry(CountryModel countryDetails);
        List<StateModel> GetState(int stateDetails);
        String InsertUpdateState(StateModel stateDetails);
        List<SalutationModel> GetSalutation(int salutationDetails);
        String InsertUpdateSalutation(SalutationModel salutationDetails);
        List<BodyPartModel> GetBodyPart(int bodyPartId);
        String InsertUpdateBodyPart(BodyPartModel bodyPart);
        List<SponsorTypeModel> GetSponsorType(int sponsorType);
        String InsertUpdateSponsorType(SponsorTypeModel sponsorType);

        List<SponsorFormModel> GetSponsorForm(int sponsorForm);
        String InsertUpdateSponsorForm(SponsorFormModel sponsorForm);
        List<CityModel> GetCity(int city);
        String InsertUpdateCity(CityModel city);
        String InsertUpdateSymptom(SymptomModel symptom);

        List<VitalSignModel> GetVitalSign(int vitalsign);
        String InsertUpdateVitalSign(VitalSignModel vitalsign);
        List<MovementModel> GetMovement(int movement);
        String InsertUpdateMovement(MovementModel movement);

        List<PackageModel> GetPackage(int package);
        String InsertUpdatePackage(PackageModel package);

        List<LocationModel> GetLocation(int location);
        String InsertUpdateLocation(LocationModel package);

        List<ScientificNameModel> GetScientificName(int sname);
        String InsertUpdateScientificName(ScientificNameModel sname);

        List<TendernModel> GetTendern(int sname);
        String InsertUpdateTendern(TendernModel sname);
        List<AppTypeModel> GetAppType();
        List<FormValidationModel> GetFormFields(int Id);
        List<FormValidationModel> GetFormMaster();
        List<ReligionModel> GetReligion();

        List<VisaTypeModel> GetVisaType();
        List<StateModel> GetStateByCountryId(int countryId);
        List<SymptomModel> GetActiveSymptoms();
        List<ItemsByTypeModel> GetItemsByType(ItemsByTypeModel ibt);
        List<ConsentTypeModel> GetConsentType();
        List<GetNumberModel> GetNumber(String numid);
        List<ConsultantModel> ConsultantSearchWithDept(GetScheduleInputModel drsearch);
        String UpdateNumberTable(GetNumberModel sname);
    }
}
