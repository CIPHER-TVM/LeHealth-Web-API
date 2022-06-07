using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;


namespace LeHealth.Core.Interface
{
    public interface IMasterDataManager
    {
        string InsertUpdateCommonMasterItem(CommonMasterFieldModelAll masterItem);
        string InsertUpdateServiceItem(ServiceItemModel serviceitem);
        string DeleteServiceItem(ServiceItemModel serviceitem);
        string InsertUpdateCPTCode(CommonMasterFieldModelAll ccm);
        string DeleteCPTCode(CPTCodeModel ccm);
        List<CPTModifierModel> GetCPTModifier(CPTModifierAll ccm);
        List<AvailableServiceModel> GetServiceItem(AvailableServiceModel ccm);
        string InsertUpdateCPTModifier(CPTModifierAll ccm);
        string DeleteCPTModifier(CPTModifierAll ccm);
        List<NationalityGroupModel> GetNationalityGroup(NationalityGroupModelAll ngm);
        string InsertUpdateNationalityGroup(NationalityGroupModelAll ngm);
        string DeleteNationalityGroup(NationalityGroupModelAll ngm); 
        List<RateGroupModel> GetRateGroup(RateGroupModelAll RateGroup);
        string InsertUpdateRateGroup(RateGroupModelAll RateGroup);
        string DeleteRateGroup(RateGroupModel RateGroup);
        List<CardTypeModel> GetCardType(CardTypeModelAll ct);
        string InsertUpdateCardType(CardTypeModelAll ct);
        string DeleteCardType(CardTypeModelAll ct);
        List<CurrencyModel> GetCurrency(CurrencyModelAll ct);
        string InsertUpdateCurrency(CurrencyModelAll ct);
        string DeleteCurrency(CurrencyModelAll ct);
        List<PackageModel> GetPackage(PackageModelAll pm);
        CommunicationConfigurationModel GetCommunicationConfiguration(CommunicationConfigurationModel pm); 
        List<PackageModel> GetPackageItemRate(PackageModelAll pm); 
        string InsertUpdatePackage(PackageModelAll package);
        string DeletePackage(PackageModel package);
        string InsertUpdateCommunicationConfiguration(CommunicationConfigurationModel ccm); 
        List<DepartmentModel> GetDepartment(DepartmentModelAll department);
        string InsertUpdateDepartment(DepartmentModelAll Dept);
        string DeleteDepartment(DepartmentModel Dept);
        List<SymptomModel> GetSymptom(SymptomModelAll symptom);
        string InsertUpdateSymptom(CommonMasterFieldModelAll symptom);
        string DeleteSymptom(CommonMasterFieldModelAll symptom);
        string DeleteSign(CommonMasterFieldModelAll symptom); 
        List<LocationModel> GetLocation(LocationAll location);
        string InsertUpdateLocation(LocationAll location);
        string DeleteLocation(LocationModel location);
        List<CountryModel> GetCountry(CountryModel country);
        string InsertUpdateCountry(CountryModel country);
        string DeleteCountry(CountryModel country);
        List<StateModel> GetState(StateModel state);
        string InsertUpdateState(StateModel state);
        string DeleteState(StateModel state);
        List<CommonMasterFieldModel> GetCompany(CommonMasterFieldModelAll cmp);
        string InsertUpdateCompany(CommonMasterFieldModelAll cmp);
        string DeleteCompany(CompanyModel cmp);
        List<ProfessionModel> GetProfession(ProfessionModelAll prof);
        string InsertUpdateProfession(CommonMasterFieldModelAll prof);
        string DeleteProfession(ProfessionModel prof);
        List<CityModel> GetCity(CityModelAll city);
        string InsertUpdateCity(CityModelAll city);
        string DeleteCity(CityModel city);
        List<VitalSignModel> GetVitalSign(VitalSignModelAll vitalsign);
        string InsertUpdateVitalSign(VitalSignModelAll vitalsign);
        string DeleteVitalSign(CommonMasterFieldModelAll vitalsign);
        List<LedgerHeadModel> GetLedgerHead(LedgerHeadModelAll ledgerhead);
        string InsertUpdateLedgerHead(LedgerHeadModelAll ledgerHead);
        string DeleteLedgerHead(LedgerHeadModelAll ledgerHead);
        List<BodyPartModelReturn> GetBodyPart(BodyPartModel bodypart);
        string InsertUpdateBodyPart(BodyPartRegModel bodypart);
        string DeleteBodyPart(BodyPartModel bodypart);
        List<SketchIndicatorModel> GetSketchIndicators(SketchIndicatorModelAll sketch);
        string InsertUpdateSketchIndicator(SketchIndicatorRegModel sketch);
        string DeleteSketchIndicator(SketchIndicatorModelAll sketch);
        List<RegSchemeModel> GetRegScheme(RegSchemeModelAll RegSchemeId);
        List<CommonMasterFieldModel> GetSalutation(CommonMasterFieldModelAll salutationDetails);
        string InsertUpdateSalutation(CommonMasterFieldModelAll salutationDetails);
        string DeleteSalutation(CommonMasterFieldModelAll salutationDetails);
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
        string DeleteReligion(ReligionModelAll reigion);
        List<LeadAgentModel> GetLeadAgent(LeadAgentModelAll la);
        string InsertUpdateLeadAgent(LeadAgentModelAll la);
        string DeleteLeadAgent(LeadAgentModelAll la);
        List<SponsorMasterModel> GetSponsor(SponsorMasterModelAll sponsorid);
        string InsertUpdateSponsor(SponsorMasterModelAll sponsor);
        string DeleteSponsor(SponsorMasterModelAll sponsor);
        List<CommonMasterFieldModel> GetDrugType(CommonMasterFieldModelAll ccm);
        List<CommonMasterFieldModel> GetContainer(CommonMasterFieldModelAll ccm); 
        List<CommonMasterFieldModel> GetVaccineType(CommonMasterFieldModelAll ccm);
        List<CommonMasterFieldModel> GetCPTCode(CommonMasterFieldModelAll ccm);
        List<TaxModel> GetTax(TaxModelAll tax);
        string InsertUpdateTax(TaxModelAll tax);
        string DeleteTax(TaxModelAll tax);
        //////////////////////////////////////////////////
        List<ConsultantMasterModel> GetConsultant(ConsultantMasterModel ledgerhead);
        string DeleteConsultant(ConsultantMasterModel consultant);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////


        string InsertUpdateMenuGroupMap(MenuGroupModel mgm);
        string InsertUpdateZone(ZoneModel zone);
        List<ZoneModel> GetZone(Int32 zoneId);
        List<ConsultantDrugModel> GetDrugs(ConsultantDrugModel cm);
        List<RouteModel> GetRoute(RouteModel dm);
        List<PendingItemModel> GetPendingServiceItemsByPatient(PendingItemInputData dm);
        string InsertUpdateOperator(OperatorModel Operator);
        List<OperatorModel> GetOperator(Int32 OperatorId);
        List<HospitalModel> GetUserHospitals(Int32 id);
        string InsertUpdateUserHospital(HospitalRegModel hm);
        string ConsentFormDataSave(ConsentFormRegModel hm);

        //DEPARTMENT MANAGEMENT STARTS

        List<ConsultantModel> GetConsultantByHospital(ConsultantModel cmodel);

        //DEPARTMENT MANAGEMENT ENDS

        //Consent Management starts
        List<ConsentPreviewModel> GetConsentPreviewConsent(Int32 consentId);
        List<ConsentContentModel> GetConsent(Int32 consentId);
        string InsertUpdateConsent(ConsentContentModel consent);

        //Consent Management ends
        List<SponsorTypeModel> GetSponsorType(Int32 sponsorType);
        string InsertUpdateSponsorType(SponsorTypeModel sponsorType);
        List<SponsorFormModel> GetSponsorForm(Int32 sponsorForm);
        string InsertUpdateSponsorForm(SponsorFormModel sponsorForm);
        List<CommonMasterFieldModel> GetMovement(CommonMasterFieldModelAll movement);
        string InsertUpdateMovement(CommonMasterFieldModelAll movement);
        string DeleteMovement(CommonMasterFieldModelAll movement);
        List<ScientificNameModel> GetScientificName(ScientificNameModelAll scientificName);
        string InsertUpdateScientificName(ScientificNameModelAll scientificName);

        List<CommonMasterFieldModel> GetTendern(CommonMasterFieldModelAll tenderness); 
        string InsertUpdateTendern(CommonMasterFieldModelAll tenderness);
        string DeleteTendern(CommonMasterFieldModelAll tenderness); 
        List<AppTypeModel> GetAppType();
        List<FormValidationModel> GetFormFields(Int32 Id);
        List<FormValidationModel> GetFormMaster();
        List<StateModel> GetStateByCountryId(Int32 countryId);
        List<ItemsByTypeModel> GetItemsByType(ItemsByTypeModel ibt);
        List<ConsentTypeModel> GetConsentType();
        List<GetNumberModel> GetNumber(string numid);
        string UpdateNumberTable(GetNumberModel sname);
        List<GenderModel> GetGender();
        List<KinRelationModel> GetKinRelation();
        List<HospitalModel> GetUserSpecificHospitals(int userId);
        List<LocationModel> GetUserSpecificHospitalLocations(int userId, int branch);
        string InsertUpdateICDCategory(ICDCategoryModelAll icdCategory);
        string DeleteICDCategory(CommonMasterFieldModelAll icdCategory);
        List<ICDCategoryModel> GetICDCategory(ICDCategoryModelAll category); 
        string InsertUpdateICDGroup(ICDGroupModelAll icdGroup);
        string DeleteICDGroup(ICDGroupModelAll icdGroup);
        List<ICDGroupModel> GetICDGroup(ICDGroupModelAll group);
        string InsertUpdateICDLabel(ICDLabelModelAll icdLabel);
        string DeleteICDLabel(ICDLabelModelAll icdLabel);
        List<ICDLabelModel> GetICDLabel(ICDLabelModelAll icdLabel);
        string InsertUpdateProfile(ProfileModelAll profile);
        List<ProfileModel> GetProfile(ProfileModelAll profile);
        string DeleteProfile(ProfileModelAll profile);
        List<ProfileItemModel> GetItemForProfile(int patientId);
        List<CommonMasterFieldModel> GetCommissionRule(CommonMasterFieldModelAll cr);
        string InsertUpdateSign(CommonMasterFieldModelAll commonMaster);
        List<CommonMasterFieldModel> GetSign(CommonMasterFieldModelAll sign);
        List<LocationModel> GetLocationByType(LocationAll location);
        string InsertAssociateLocation(LocationAssociateModel locationAssociate);
        string InsertUpdateServicePoint(ServicePointModel servicePoint);
        List<ServicePointModel> GetServicePoint(ServicePointModelAll sPoint);
        string DeleteServicePoint(ServicePointModel servicePoint);
        string InsertUpdateDeleteTradeName(TradeNameModelAll tradeName);
        List<TradeNameModel> GetTradeName(TradeNameModelAll tradeName);
        string InsertUpdateDeleteDrug(DrugModelAll drug);
        List<DrugModel> GetDrug(DrugModelAll drug);
        string InsertUpdateDeleteInformedConsent(InformedConsentModelAll informedConsent);
        List<InformedConsentModel> GetInformedConsent(InformedConsentModelAll informedConsent);
        string InsertUpdateDeletePatientConsent(PatientConsentModelAll patientConsent);
        List<PatientConsentModel> GetPatientConsent(PatientConsentModelAll patientConsent);
        string InsertUpdateDeleteSponserConsent(SponserConsentModelAll sponserConsent);
        List<SponserConsentModel> GetSponserConsent(SponserConsentModelAll sponserConsent);
        List<DosageModel> GetDosage(DosageModelAll dosageModel);
        string InsertUpdateDeleteDosage(DosageModelAll dosageModel);
        List<FrequencyModel> GetFrequency(FrequencyModelAll frequency);
        string InsertUpdateDeleteFrequency(FrequencyModelAll frequency);
        List<ConsentGroupModel> GetConsentGroup();
    }
}
