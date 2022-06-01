using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;


namespace LeHealth.Service.ServiceInterface
{
    public interface IMasterDataService
    {
        string InsertUpdateCommonMasterItem(CommonMasterFieldModelAll masterItem);
        string DeleteCommonMasterItem(CommonMasterFieldModelAll masterItem);
        List<CommonMasterFieldModel> GetCommonMasterItem(CommonMasterFieldModelAll ccm); 
        List<AvailableServiceModel> GetServiceItem(AvailableServiceModel ccm); 
        string InsertUpdateServiceItem(ServiceItemModel serviceitem);
        string DeleteServiceItem(ServiceItemModel serviceitem);
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
        List<LocationModel> GetLocation(LocationAll location);
        string InsertUpdateLocation(LocationAll location);
        string DeleteLocation(LocationModel location);
        List<CountryModel> GetCountry(CountryModel country);
        string InsertUpdateCountry(CountryModel country);
        string DeleteCountry(CountryModel country);
        List<StateModel> GetState(StateModel state);
        string InsertUpdateState(StateModel state);
        string DeleteState(StateModel state);
        string DeleteCompany(CompanyModel cmp);
        List<ProfessionModel> GetProfession(ProfessionModelAll profid);
        string DeleteProfession(ProfessionModel prof);
        List<CityModel> GetCity(CityModelAll city);
        string InsertUpdateCity(CityModelAll city);
        string DeleteCity(CityModel city);
        List<VitalSignModel> GetVitalSign(VitalSignModelAll vitalsign);
        string InsertUpdateVitalSign(VitalSignModelAll vitalsign);
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
        List<MaritalStatusModel> GetMaritalStatus(MaritalStatusModelAll MaritalStatus);
        string InsertUpdateMaritalStatus(MaritalStatusModelAll MaritalStatus);
        string DeleteMaritalStatus(MaritalStatusModelAll MaritalStatus);
        List<CommunicationTypeModel> GetCommunicationType(CommunicationTypeModelAll ctype);
        string InsertUpdateCommunicationType(CommunicationTypeModelAll ctype);
        string DeleteCommunicationType(CommunicationTypeModelAll ctype);
        List<VisaTypeModel> GetVisaType(VisaTypeModelAll visatype);
        string InsertUpdateVisaType(VisaTypeModelAll visatype);
        string DeleteVisaType(VisaTypeModelAll visatype);

        List<ReligionModel> GetReligion(ReligionModelAll religion);
        string InsertUpdateReligion(ReligionModelAll religion);
        string DeleteReligion(ReligionModelAll religion);
        List<LeadAgentModel> GetLeadAgent(LeadAgentModelAll la);
        string InsertUpdateLeadAgent(LeadAgentModelAll la);
        string DeleteLeadAgent(LeadAgentModelAll la);
        List<SponsorMasterModel> GetSponsor(SponsorMasterModelAll sponsor);
        string InsertUpdateSponsor(SponsorMasterModelAll sponsor);
        string DeleteSponsor(SponsorMasterModelAll sponsor);
        List<TaxModel> GetTax(TaxModelAll tax);
        string InsertUpdateTax(TaxModelAll tax);
        string DeleteTax(TaxModelAll tax);

        /////////////////////////////////////////////
        List<ConsultantMasterModel> GetConsultant(ConsultantMasterModel consultant);
        string DeleteConsultant(ConsultantMasterModel consultant);
        ////////////////////////////////////////////////////////////////////////////////////////

        string InsertUpdateMenuGroupMap(MenuGroupModel mgm);
        List<HospitalModel> GetUserHospitals(Int32 id);
        string InsertUpdateUserHospitals(HospitalRegModel hm);
        string ConsentFormDataSave(ConsentFormRegModel hm);
        List<ConsentPreviewModel> GetConsentPreviewConsent(Int32 id);
        List<ConsentContentModel> GetConsent(Int32 id);
        string InsertUpdateConsent(ConsentContentModel hm);
        List<AppTypeModel> GetAppType();
        List<FormValidationModel> GetFormFields(Int32 Id);
        List<FormValidationModel> GetFormMaster();
        string InsertUpdateZone(ZoneModel zone);
        List<ZoneModel> GetZone(Int32 zoneId);
        List<ConsultantDrugModel> GetDrugs(ConsultantDrugModel cm);
        List<DosageModel> GetDosage(DosageModel dm);
        List<RouteModel> GetRoute(RouteModel rm);
        List<PendingItemModel> GetPendingServiceItemsByPatient(PendingItemInputData rm);
        string InsertUpdateOperator(OperatorModel Operator);
        List<OperatorModel> GetOperator(Int32 OperatorId);
        List<ConsultantModel> GetConsultantByHospital(ConsultantModel cmodel);
        List<SponsorTypeModel> GetSponsorType(Int32 sponsorType);
        string InsertUpdateSponsorType(SponsorTypeModel sponsorType);
        List<SponsorFormModel> GetSponsorForm(Int32 sponsorForm);
        string InsertUpdateSponsorForm(SponsorFormModel sponsorForm);
        List<ScientificNameModel> GetScientificName(ScientificNameModelAll scientificName);
        string InsertUpdateScientificName(ScientificNameModelAll scientificName);
        List<StateModel> GetStateByCountryId(Int32 countryId);
        List<ItemsByTypeModel> GetItemsByType(ItemsByTypeModel ibt);
        List<ConsentTypeModel> GetConsentType();
        List<GetNumberModel> GetNumber(string nid);
        string UpdateNumberTable(GetNumberModel sname);
        List<GenderModel> GetGender();
        List<KinRelationModel> GetKinRelation();
        List<HospitalModel> GetUserSpecificHospitals(int UserId);
        List<LocationModel> GetUserSpecificHospitalLocations(int userId, int branch);
        string InsertUpdateICDGroup(ICDGroupModelAll icdGroup);
        List<ICDGroupModel> GetICDGroup(ICDGroupModelAll group);
        string InsertUpdateICDLabel(ICDLabelModelAll icdLabel);
        string DeleteICDLabel(ICDLabelModelAll icdLabel);
        List<ICDLabelModel> GetICDLabel(ICDLabelModelAll label);

        string InsertUpdateProfile(ProfileModelAll profile);
        List<ProfileModel> GetProfile(ProfileModelAll profile);
        string DeleteProfile(ProfileModelAll profile);
        List<ProfileItemModel> GetItemForProfile(int patientId);
        List<LocationModel> GetLocationByType(LocationAll location);
        string InsertAssociateLocation(LocationAssociateModel locationAssociate);
        string InsertUpdateServicePoint(ServicePointModel servicePoint);
        List<ServicePointModel> GetServicePoint(ServicePointModelAll sPoint);
        string DeleteServicePoint(ServicePointModel servicePoint);
        string InsertUpdateDeleteTradeName(TradeNameModelAll tradeName);
        List<TradeNameModel> GetTradeName(TradeNameModelAll tradeName);
    }
}
