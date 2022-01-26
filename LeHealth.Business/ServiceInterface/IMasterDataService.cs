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
        List<SponsorMasterModel> GetSponsor(int sponsorid);
        string InsertUpdateSponsor(SponsorMasterModel sponsor);
        List<HospitalModel> GetUserHospitals(int id);
        string InsertUpdateUserHospitals(HospitalRegModel hm);
        string ConsentFormDataSave(ConsentFormRegModel hm);
        List<ConsentPreviewModel> GetConsentPreviewConsent(int id);
        List<ConsentContentModel> GetConsent(int id);
        string InsertUpdateConsent(ConsentContentModel hm);
        List<AppTypeModel> GetAppType();
        List<FormValidationModel> GetFormFields(int Id);
        List<FormValidationModel> GetFormMaster();
        List<ReligionModel> GetReligion();
        string InsertUpdateZone(ZoneModel zone);
        List<ZoneModel> GetZone(int zoneId);
        string InsertUpdateRateGroup(RateGroupModel RateGroup);
        List<RateGroupModel> GetRateGroup(int Id);
        string InsertUpdateOperator(OperatorModel Operator);
        List<OperatorModel> GetOperator(int OperatorId);
        string InsertUpdateRegScheme(RegSchemeModel RegScheme);
        List<RegSchemeModel> GetRegScheme(int RegSchemeId);
        List<DepartmentModel> GetDepartments(int DeptId);
        List<DepartmentModel> GetDepartmentByHospital(int HospId);
        string InsertUpdateDepartment(DepartmentModel Dept);
        List<LeadAgentModel> GetLeadAgent(int la);
        string InsertUpdateLeadAgent(LeadAgentModel la);
        List<CompanyModel> GetCompany(int Id);
        string InsertUpdateCompany(CompanyModel cmp);
        List<CountryModel> GetCountry(int countryDetail);
        string InsertUpdateCountry(CountryModel countryDetail);
        List<StateModel> GetState(int stateDetail);
        string InsertUpdateState(StateModel stateDetail);
        List<SalutationModel> GetSalutation(int stateDetail);
        string InsertUpdateSalutation(SalutationModel stateDetail);
        List<BodyPartModel> GetBodyPart(int stateDetail);
        string InsertUpdateBodyPart(BodyPartModel stateDetail);
        List<SponsorTypeModel> GetSponsorType(int sponsorType);
        string InsertUpdateSponsorType(SponsorTypeModel sponsorType);
        List<SponsorFormModel> GetSponsorForm(int sponsorForm);
        string InsertUpdateSponsorForm(SponsorFormModel sponsorForm);
        List<CityModel> GetCity(int city);
        string InsertUpdateCity(CityModel city);

        List<VitalSignModel> GetVitalSign(int vitalsign);
        string InsertUpdateVitalSign(VitalSignModel vitalsign);
        List<MovementModel> GetMovement(int movement);
        string InsertUpdateMovement(MovementModel movement);

        List<PackageModel> GetPackage(int package);
        string InsertUpdatePackage(PackageModel package);

        List<LocationModel> GetLocation(int location); 
        string InsertUpdateLocation(LocationModel package);

        List<ScientificNameModel> GetScientificName(int sname);
        string InsertUpdateScientificName(ScientificNameModel sname);

        List<TendernModel> GetTendern(int sname);
        string InsertUpdateTendern(TendernModel sname); 

        string InsertUpdateSymptom(SymptomModel symptom); 
        List<VisaTypeModel> GetVisaType();
        List<StateModel> GetStateByCountryId(int countryId);
        List<SymptomModel> GetActiveSymptoms();
        List<ItemsByTypeModel> GetItemsByType(ItemsByTypeModel ibt);
        List<ConsentTypeModel> GetConsentType();
        List<GetNumberModel> GetNumber(String nid);
        List<ConsultantModel> ConsultantSearchWithDept(GetScheduleInputModel drsearch);
        string UpdateNumberTable(GetNumberModel sname);
    }
}
