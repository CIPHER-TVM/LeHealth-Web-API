using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;


namespace LeHealth.Service.ServiceInterface
{
    public interface IMasterDataService
    {
        List<ProfessionModel> GetProfession(Int32 profid);
        string InsertUpdateProfession(ProfessionModel prof);
        List<SponsorMasterModel> GetSponsor(Int32 sponsorid);
        string InsertUpdateSponsor(SponsorMasterModel sponsor);
        List<HospitalModel> GetUserHospitals(Int32 id);
        string InsertUpdateUserHospitals(HospitalRegModel hm);
        string ConsentFormDataSave(ConsentFormRegModel hm);
        List<ConsentPreviewModel> GetConsentPreviewConsent(Int32 id);
        List<ConsentContentModel> GetConsent(Int32 id);
        string InsertUpdateConsent(ConsentContentModel hm);
        List<AppTypeModel> GetAppType();
        List<FormValidationModel> GetFormFields(Int32 Id);
        List<FormValidationModel> GetFormMaster();
        List<ReligionModel> GetReligion();
        string InsertUpdateZone(ZoneModel zone);
        List<ZoneModel> GetZone(Int32 zoneId);
        string InsertUpdateRateGroup(RateGroupModel RateGroup);
        List<RateGroupModel> GetRateGroup(Int32 Id);
        string InsertUpdateOperator(OperatorModel Operator);
        List<OperatorModel> GetOperator(Int32 OperatorId);
        string InsertUpdateRegScheme(RegSchemeModel RegScheme);
        List<RegSchemeModel> GetRegScheme(Int32 RegSchemeId);
        List<DepartmentModel> GetDepartments(Int32 DeptId);
        List<DepartmentModel> GetDepartmentByHospital(Int32 HospId);
        string InsertUpdateDepartment(DepartmentModel Dept);
        List<LeadAgentModel> GetLeadAgent(Int32 la);
        string InsertUpdateLeadAgent(LeadAgentModel la);
        List<CompanyModel> GetCompany(Int32 Id);
        string InsertUpdateCompany(CompanyModel cmp);
        List<CountryModel> GetCountry(Int32 countryDetail);
        string InsertUpdateCountry(CountryModel countryDetail);
        List<StateModel> GetState(Int32 stateDetail);
        string InsertUpdateState(StateModel stateDetail);
        List<SalutationModel> GetSalutation(Int32 stateDetail);
        string InsertUpdateSalutation(SalutationModel stateDetail);
        List<BodyPartModel> GetBodyPart(Int32 stateDetail);
        string InsertUpdateBodyPart(BodyPartModel stateDetail);
        List<SponsorTypeModel> GetSponsorType(Int32 sponsorType);
        string InsertUpdateSponsorType(SponsorTypeModel sponsorType);
        List<SponsorFormModel> GetSponsorForm(Int32 sponsorForm);
        string InsertUpdateSponsorForm(SponsorFormModel sponsorForm);
        List<CityModel> GetCity(Int32 city);
        string InsertUpdateCity(CityModel city);

        List<VitalSignModel> GetVitalSign(Int32 vitalsign);
        string InsertUpdateVitalSign(VitalSignModel vitalsign);
        List<MovementModel> GetMovement(Int32 movement);
        string InsertUpdateMovement(MovementModel movement);

        List<PackageModel> GetPackage(Int32 package);
        string InsertUpdatePackage(PackageModel package);

        List<LocationModel> GetLocation(Int32 location); 
        string InsertUpdateLocation(LocationModel package);

        List<ScientificNameModel> GetScientificName(Int32 sname);
        string InsertUpdateScientificName(ScientificNameModel sname);

        List<TendernModel> GetTendern(Int32 sname);
        string InsertUpdateTendern(TendernModel sname); 

        string InsertUpdateSymptom(SymptomModel symptom); 
        List<VisaTypeModel> GetVisaType();
        List<StateModel> GetStateByCountryId(Int32 countryId);
        List<SymptomModel> GetActiveSymptoms();
        List<ItemsByTypeModel> GetItemsByType(ItemsByTypeModel ibt);
        List<ConsentTypeModel> GetConsentType();
        List<GetNumberModel> GetNumber(string nid);
        List<ConsultantModel> ConsultantSearchWithDept(GetScheduleInputModel drsearch);
        string UpdateNumberTable(GetNumberModel sname);
    }
}
