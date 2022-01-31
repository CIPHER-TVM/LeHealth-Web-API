using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;


namespace LeHealth.Service.ServiceInterface
{
    public interface IMasterDataService
    {
        List<ProfessionModel> GetProfession(int profid);
        String InsertUpdateProfession(ProfessionModel prof);
        List<SponsorMasterModel> GetSponsor(int sponsorid);
        String InsertUpdateSponsor(SponsorMasterModel sponsor);
        List<HospitalModel> GetUserHospitals(int id);
        String InsertUpdateUserHospitals(HospitalRegModel hm);
        String ConsentFormDataSave(ConsentFormRegModel hm);
        List<ConsentPreviewModel> GetConsentPreviewConsent(int id);
        List<ConsentContentModel> GetConsent(int id);
        String InsertUpdateConsent(ConsentContentModel hm);
        List<AppTypeModel> GetAppType();
        List<FormValidationModel> GetFormFields(int Id);
        List<FormValidationModel> GetFormMaster();
        List<ReligionModel> GetReligion();
        String InsertUpdateZone(ZoneModel zone);
        List<ZoneModel> GetZone(int zoneId);
        String InsertUpdateRateGroup(RateGroupModel RateGroup);
        List<RateGroupModel> GetRateGroup(int Id);
        String InsertUpdateOperator(OperatorModel Operator);
        List<OperatorModel> GetOperator(int OperatorId);
        String InsertUpdateRegScheme(RegSchemeModel RegScheme);
        List<RegSchemeModel> GetRegScheme(int RegSchemeId);
        List<DepartmentModel> GetDepartments(int DeptId);
        List<DepartmentModel> GetDepartmentByHospital(int HospId);
        String InsertUpdateDepartment(DepartmentModel Dept);
        List<LeadAgentModel> GetLeadAgent(int la);
        String InsertUpdateLeadAgent(LeadAgentModel la);
        List<CompanyModel> GetCompany(int Id);
        String InsertUpdateCompany(CompanyModel cmp);
        List<CountryModel> GetCountry(int countryDetail);
        String InsertUpdateCountry(CountryModel countryDetail);
        List<StateModel> GetState(int stateDetail);
        String InsertUpdateState(StateModel stateDetail);
        List<SalutationModel> GetSalutation(int stateDetail);
        String InsertUpdateSalutation(SalutationModel stateDetail);
        List<BodyPartModel> GetBodyPart(int stateDetail);
        String InsertUpdateBodyPart(BodyPartModel stateDetail);
        List<SponsorTypeModel> GetSponsorType(int sponsorType);
        String InsertUpdateSponsorType(SponsorTypeModel sponsorType);
        List<SponsorFormModel> GetSponsorForm(int sponsorForm);
        String InsertUpdateSponsorForm(SponsorFormModel sponsorForm);
        List<CityModel> GetCity(int city);
        String InsertUpdateCity(CityModel city);

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

        String InsertUpdateSymptom(SymptomModel symptom); 
        List<VisaTypeModel> GetVisaType();
        List<StateModel> GetStateByCountryId(int countryId);
        List<SymptomModel> GetActiveSymptoms();
        List<ItemsByTypeModel> GetItemsByType(ItemsByTypeModel ibt);
        List<ConsentTypeModel> GetConsentType();
        List<GetNumberModel> GetNumber(String nid);
        List<ConsultantModel> ConsultantSearchWithDept(GetScheduleInputModel drsearch);
        String UpdateNumberTable(GetNumberModel sname);
    }
}
