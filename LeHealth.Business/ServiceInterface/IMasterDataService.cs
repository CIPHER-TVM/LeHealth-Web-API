using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;


namespace LeHealth.Service.ServiceInterface
{
    public interface IMasterDataService
    {
        string InsertUpdateServiceItem(ServiceItemModel serviceitem);
        string BlockUnblockServiceItem(ServiceItemModel serviceitem);
        List<CPTCodeModel> GetCPTCode(CPTCodeModelAll ccm);
        string InsertUpdateCPTCode(CPTCodeModelAll ccm);
        string DeleteCPTCode(CPTCodeModel ccm);
        List<CPTModifierModel> GetCPTModifier(CPTModifierAll ccm);
        string InsertUpdateCPTModifier(CPTModifierAll ccm);
        string DeleteCPTModifier(CPTModifierAll ccm);
        List<RateGroupModel> GetRateGroup(RateGroupModelAll rm);
        string InsertUpdateRateGroup(RateGroupModelAll rm);
        string DeleteRateGroup(RateGroupModel rm);
        List<PackageModel> GetPackage(PackageModelAll pm);
        string InsertUpdatePackage(PackageModelAll package);
        string DeletePackage(PackageModel package);
        List<DepartmentModel> GetDepartment(DepartmentModelAll DeptId);
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
        List<ProfessionModel> GetProfession(ProfessionModelAll profid);
        string InsertUpdateProfession(ProfessionModelAll prof);
        string DeleteProfession(ProfessionModel prof);
        List<CityModel> GetCity(CityModelAll city);
        string InsertUpdateCity(CityModelAll city);
        string DeleteCity(CityModel city);
        List<VitalSignModel> GetVitalSign(VitalSignModelAll vitalsign);
        string InsertUpdateVitalSign(VitalSignModelAll vitalsign);
        string DeleteVitalSign(VitalSignModelAll vitalsign);
        List<LedgerHeadModel> GetLedgerHead(LedgerHeadModelAll vitalsign);
        string InsertUpdateLedgerHead(LedgerHeadModelAll vitalsign);
        string DeleteLedgerHead(LedgerHeadModelAll vitalsign);
        List<BodyPartModelReturn> GetBodyPart(BodyPartModel bodypart);
        string InsertUpdateBodyPart(BodyPartRegModel bodypart);
        string DeleteBodyPart(BodyPartModel bodypart);
        List<SketchIndicatorModel> GetSketchIndicators(SketchIndicatorModelAll sketch);
        string InsertUpdateSketchIndicator(SketchIndicatorRegModel sketch);
        string DeleteSketchIndicator(SketchIndicatorModelAll sketch);
        List<RegSchemeModel> GetRegScheme(RegSchemeModelAll RegScheme);
        List<SalutationModel> GetSalutation(SalutationModelAll salutationDetails);
        string InsertUpdateSalutation(SalutationModelAll salutationDetails);
        string DeleteSalutation(SalutationModelAll salutationDetails);
        List<MaritalStatusModel> GetMaritalStatus(MaritalStatusModelAll MaritalStatus);
        string InsertUpdateMaritalStatus(MaritalStatusModelAll MaritalStatus);
        string DeleteMaritalStatus(MaritalStatusModelAll MaritalStatus);
        /////////////////////////////////////////////
        List<ConsultantMasterModel> GetConsultant(ConsultantMasterModel consultant);
        string DeleteConsultant(ConsultantMasterModel consultant);
        ////////////////////////////////////////////////////////////////////////////////////////

        string InsertUpdateMenuGroupMap(MenuGroupModel mgm);
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
        List<ConsultantDrugModel> GetDrugs(ConsultantDrugModel cm);
        List<DosageModel> GetDosage(DosageModel dm);
        List<RouteModel> GetRoute(RouteModel rm);
        List<PendingItemModel> GetPendingServiceItemsByPatient(PendingItemInputData rm);
        string InsertUpdateOperator(OperatorModel Operator);
        List<OperatorModel> GetOperator(Int32 OperatorId);
        List<ConsultantModel> GetConsultantByHospital(ConsultantModel cmodel);
        List<LeadAgentModel> GetLeadAgent(Int32 la);
        string InsertUpdateLeadAgent(LeadAgentModel la);
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


        List<VisaTypeModel> GetVisaType();
        List<StateModel> GetStateByCountryId(Int32 countryId);

        List<ItemsByTypeModel> GetItemsByType(ItemsByTypeModel ibt);
        List<ConsentTypeModel> GetConsentType();
        List<GetNumberModel> GetNumber(string nid);
        string UpdateNumberTable(GetNumberModel sname);
        List<GenderModel> GetGender();
        List<KinRelationModel> GetKinRelation();
        List<CommunicationTypeModel> GetCommunicationType();
        List<HospitalModel> GetUserSpecificHospitals(int UserId);
        List<LocationModel> GetUserSpecificHospitalLocations(int userId, int branch);
    }
}
