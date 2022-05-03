using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;


namespace LeHealth.Core.Interface
{
    public interface IMasterDataManager
    {

        string InsertUpdateServiceItem(ServiceItemModel serviceitem);
        string BlockUnblockServiceItem(ServiceItemModel serviceitem);
        List<CPTCodeModel> GetCPTCode(CPTCodeModelAll ccm);
        string InsertUpdateCPTCode(CPTCodeModelAll ccm);
        string DeleteCPTCode(CPTCodeModel ccm);
        List<RateGroupModel> GetRateGroup(RateGroupModelAll RateGroup);
        string InsertUpdateRateGroup(RateGroupModelAll RateGroup);
        string DeleteRateGroup(RateGroupModel RateGroup);
        List<PackageModel> GetPackage(PackageModelAll pm);
        string InsertUpdatePackage(PackageModelAll package);
        string DeletePackage(PackageModel package);
        List<DepartmentModel> GetDepartment(DepartmentModelAll department);
        //List<DepartmentModel> GetDepartmentByHospital(Int32 HospId);
        string InsertUpdateDepartment(DepartmentModelAll Dept);
        string DeleteDepartment(DepartmentModel Dept);
        List<SymptomModel> GetSymptom(SymptomModelAll symptom);
        string InsertUpdateSymptom(SymptomModelAll symptom);
        string DeleteSymptom(SymptomModel symptom);
        List<LocationModel> GetLocation(LocationAll location);
        string InsertUpdateLocation(LocationAll location);
        string DeleteLocation(LocationModel location);
        List<CountryModel> GetCountry(CountryModel country);
        string InsertUpdateCountry(CountryModel country);
        string DeleteCountry(CountryModel country);
        List<StateModel> GetState(StateModel state);
        string InsertUpdateState(StateModel state);
        string DeleteState(StateModel state);
        List<CompanyModel> GetCompany(CompanyModelAll cmp);
        string InsertUpdateCompany(CompanyModelAll cmp);
        string DeleteCompany(CompanyModel cmp);
        List<ProfessionModel> GetProfession(ProfessionModelAll prof);
        string InsertUpdateProfession(ProfessionModelAll prof);
        string DeleteProfession(ProfessionModel prof);
        List<CityModel> GetCity(CityModelAll city);
        string InsertUpdateCity(CityModelAll city);
        string DeleteCity(CityModel city);


        List<VitalSignModel> GetVitalSign(VitalSignModelAll vitalsign);
        string InsertUpdateVitalSign(VitalSignModelAll vitalsign);
        string DeleteVitalSign(VitalSignModelAll vitalsign);
        List<LedgerHeadModel> GetLedgerHead(LedgerHeadModelAll ledgerhead);
        string InsertUpdateLedgerHead(LedgerHeadModelAll ledgerHead);
        string DeleteLedgerHead(LedgerHeadModelAll ledgerHead);
        List<BodyPartModelReturn> GetBodyPart(BodyPartModel bodypart);
        string InsertUpdateBodyPart(BodyPartRegModel bodypart);
        string DeleteBodyPart(BodyPartModel bodypart);

        //////////////////////////////////////////////////
        List<ConsultantMasterModel> GetConsultant(ConsultantMasterModel ledgerhead);
        string DeleteConsultant(ConsultantMasterModel consultant);
        List<RegSchemeModel> GetRegScheme(RegSchemeModelAll RegSchemeId);
        string InsertUpdateRegScheme(RegSchemeModelAll RegScheme);
        string DeleteRegScheme(RegSchemeModelAll RegScheme);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////


        string InsertUpdateMenuGroupMap(MenuGroupModel mgm);
        List<SponsorMasterModel> GetSponsor(Int32 sponsorid);
        string InsertUpdateSponsor(SponsorMasterModel sponsor);
        string InsertUpdateZone(ZoneModel zone);
        List<ZoneModel> GetZone(Int32 zoneId);
        List<ConsultantDrugModel> GetDrugs(ConsultantDrugModel cm);
        List<RouteModel> GetRoute(RouteModel dm);
        List<DosageModel> GetDosage(DosageModel dm);
        List<PendingItemModel> GetPendingServiceItemsByPatient(PendingItemInputData dm);
        string InsertUpdateOperator(OperatorModel Operator);
        List<OperatorModel> GetOperator(Int32 OperatorId);        
        List<HospitalModel> GetUserHospitals(Int32 id);
        string InsertUpdateUserHospital(HospitalRegModel hm);
        string ConsentFormDataSave(ConsentFormRegModel hm);
        List<LeadAgentModel> GetLeadAgent(Int32 la);
        string InsertUpdateLeadAgent(LeadAgentModel la);



        //DEPARTMENT MANAGEMENT STARTS

        List<ConsultantModel> GetConsultantByHospital(ConsultantModel cmodel);

        //DEPARTMENT MANAGEMENT ENDS

        //Consent Management starts
        List<ConsentPreviewModel> GetConsentPreviewConsent(Int32 consentId);
        List<ConsentContentModel> GetConsent(Int32 consentId);
        string InsertUpdateConsent(ConsentContentModel consent);

        //Consent Management ends
        List<SalutationModel> GetSalutation(Int32 salutationDetails);
        string InsertUpdateSalutation(SalutationModel salutationDetails);
        List<SponsorTypeModel> GetSponsorType(Int32 sponsorType);
        string InsertUpdateSponsorType(SponsorTypeModel sponsorType);
        List<SponsorFormModel> GetSponsorForm(Int32 sponsorForm);
        string InsertUpdateSponsorForm(SponsorFormModel sponsorForm);
        List<MovementModel> GetMovement(Int32 movement);
        string InsertUpdateMovement(MovementModel movement);
        List<ScientificNameModel> GetScientificName(Int32 sname);
        string InsertUpdateScientificName(ScientificNameModel sname);

        List<TendernModel> GetTendern(Int32 sname);
        string InsertUpdateTendern(TendernModel sname);
        List<AppTypeModel> GetAppType();
        List<FormValidationModel> GetFormFields(Int32 Id);
        List<FormValidationModel> GetFormMaster();
        List<ReligionModel> GetReligion();

        List<VisaTypeModel> GetVisaType();
        List<StateModel> GetStateByCountryId(Int32 countryId);

        List<ItemsByTypeModel> GetItemsByType(ItemsByTypeModel ibt);
        List<ConsentTypeModel> GetConsentType();
        List<GetNumberModel> GetNumber(string numid);
        string UpdateNumberTable(GetNumberModel sname);

        List<GenderModel> GetGender();
        List<KinRelationModel> GetKinRelation();
        List<MaritalStatusModel> GetMaritalStatus();
        List<CommunicationTypeModel> GetCommunicationType();
        List<HospitalModel> GetUserSpecificHospitals(int userId);
        List<LocationModel> GetUserSpecificHospitalLocations(int userId, int branch);
    }
}
