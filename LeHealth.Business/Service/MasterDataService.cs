using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Service.ServiceInterface;
using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;

namespace LeHealth.Service.Service
{
    public class MasterDataService : IMasterDataService
    {
        private readonly IMasterDataManager masterdataManager;
        private readonly IFileUploadService fileUploadService;
        public MasterDataService(IMasterDataManager _masterdataManager, IFileUploadService _fileUploadService)
        {
            masterdataManager = _masterdataManager;
            fileUploadService = _fileUploadService;
        }
        public List<CommonMasterFieldModel> GetCommonMasterItem(CommonMasterFieldModelAll masterItem)
        {
            List<CommonMasterFieldModel> returnvalue = new List<CommonMasterFieldModel>();
            switch (masterItem.MasterFieldType)
            {
                case "DrugType":
                    returnvalue = masterdataManager.GetDrugType(masterItem);
                    break;
                case "Container":
                    returnvalue = masterdataManager.GetContainer(masterItem);
                    break;
                case "VaccineType":
                    returnvalue = masterdataManager.GetVaccineType(masterItem);
                    break;
                case "CPTCode":
                    returnvalue = masterdataManager.GetCPTCode(masterItem);
                    break;
                case "Company":
                    returnvalue = masterdataManager.GetCompany(masterItem);
                    break;
                case "CommissionRule":
                    returnvalue = masterdataManager.GetCommissionRule(masterItem);
                    break;
                case "Sign":
                    returnvalue = masterdataManager.GetSign(masterItem);
                    break;
                case "Tenderness":
                    returnvalue = masterdataManager.GetTendern(masterItem);
                    break;
                case "Movement":
                    returnvalue = masterdataManager.GetMovement(masterItem);
                    break;
                case "Salutation":
                    returnvalue = masterdataManager.GetSalutation(masterItem);
                    break;
                case "MarketStatus":
                    returnvalue = masterdataManager.GetMarketStatus(masterItem);
                    break;
                    //default:
                    //    returnvalue = masterdataManager.GetCPTCode(masterItem);
                    //    break;
            }
            return returnvalue;
        }

        public string InsertUpdateCommonMasterItem(CommonMasterFieldModelAll masterItem)
        {
            string returnvalue;
            switch (masterItem.MasterFieldType)
            {
                case "CPTCode":
                    returnvalue = masterdataManager.InsertUpdateCPTCode(masterItem);
                    break;
                case "Symptom":
                    returnvalue = masterdataManager.InsertUpdateSymptom(masterItem);
                    break;
                case "Profession":
                    returnvalue = masterdataManager.InsertUpdateProfession(masterItem);
                    break;
                case "Company":
                    returnvalue = masterdataManager.InsertUpdateCompany(masterItem);
                    break;
                case "Sign":
                    returnvalue = masterdataManager.InsertUpdateSign(masterItem);
                    break;
                case "Tenderness":
                    returnvalue = masterdataManager.InsertUpdateTendern(masterItem);
                    break;
                case "Movement":
                    returnvalue = masterdataManager.InsertUpdateMovement(masterItem);
                    break;
                case "Salutation":
                    returnvalue = masterdataManager.InsertUpdateSalutation(masterItem);
                    break;
                default:
                    returnvalue = masterdataManager.InsertUpdateSalutation(masterItem);
                    break;
            }
            return returnvalue;
        }

        public string DeleteCommonMasterItem(CommonMasterFieldModelAll masterItem)
        {
            string returnvalue;
            switch (masterItem.MasterFieldType)
            {
                case "Sign":
                    returnvalue = masterdataManager.DeleteSign(masterItem);
                    break;
                case "VitalSign":
                    returnvalue = masterdataManager.DeleteVitalSign(masterItem);
                    break;
                case "Symptom":
                    returnvalue = masterdataManager.DeleteSymptom(masterItem);
                    break;
                case "Tendern":
                    returnvalue = masterdataManager.DeleteTendern(masterItem);
                    break;
                case "Movement":
                    returnvalue = masterdataManager.DeleteMovement(masterItem);
                    break;
                case "Salutation":
                    returnvalue = masterdataManager.DeleteSalutation(masterItem);
                    break;
                case "ICDCategory":
                    returnvalue = masterdataManager.DeleteICDCategory(masterItem);
                    break;
                default:
                    returnvalue = masterdataManager.InsertUpdateSalutation(masterItem);
                    break;
            }
            return returnvalue;
        }
        public List<ServiceConfigModel> GetServiceItem(AvailableServiceModel ccm)
        {
            return masterdataManager.GetServiceItem(ccm);
        } 
        public List<RateModel> GetItemRateAmountById(AvailableServiceModel ccm)
        {
            return masterdataManager.GetItemRateAmountById(ccm);
        }
        public List<ItemRateModel> GetStandardRate(RateGroupModelAll ccm)
        {
            return masterdataManager.GetStandardRate(ccm);
        }
        public string InsertUpdateServiceItem(ServiceConfigModelAll serviceitem)
        {
            return masterdataManager.InsertUpdateServiceItem(serviceitem);
        }
        public string DeleteServiceItem(ServiceItemModel serviceitem)
        {
            return masterdataManager.DeleteServiceItem(serviceitem);
        }
        public string InsertUpdateServiceItemGroup(ServiceConfigModel serviceitemGroup)
        {
            return masterdataManager.InsertUpdateServiceItemGroup(serviceitemGroup);
        }
        public CommunicationConfigurationModel GetCommunicationConfiguration(CommunicationConfigurationModel ngm)
        {
            return masterdataManager.GetCommunicationConfiguration(ngm);
        }
        public List<NationalityGroupModel> GetNationalityGroup(NationalityGroupModelAll ngm)
        {
            return masterdataManager.GetNationalityGroup(ngm);
        }
        public string InsertUpdateNationalityGroup(NationalityGroupModelAll ngm)
        {
            return masterdataManager.InsertUpdateNationalityGroup(ngm);
        }
        public string DeleteNationalityGroup(NationalityGroupModelAll ngm)
        {
            return masterdataManager.DeleteNationalityGroup(ngm);
        }
        public List<CardTypeModel> GetCardType(CardTypeModelAll ngm)
        {
            return masterdataManager.GetCardType(ngm);
        }
        public string InsertUpdateCardType(CardTypeModelAll ngm) 
        {
            return masterdataManager.InsertUpdateCardType(ngm);
        }
        public string DeleteCardType(CardTypeModelAll ngm)
        {
            return masterdataManager.DeleteCardType(ngm);
        }
        public string InsertUpdateCommunicationConfiguration(CommunicationConfigurationModel ccm)
        {
            return masterdataManager.InsertUpdateCommunicationConfiguration(ccm);
        }
        public string DeleteCPTCode(CPTCodeModel ccm)
        {
            return masterdataManager.DeleteCPTCode(ccm);
        }
        public List<CPTModifierModel> GetCPTModifier(CPTModifierAll ccm)
        {
            return masterdataManager.GetCPTModifier(ccm);
        }
        public string InsertUpdateCPTModifier(CPTModifierAll ccm)
        {
            return masterdataManager.InsertUpdateCPTModifier(ccm);
        }
        public string DeleteCPTModifier(CPTModifierAll ccm)
        {
            return masterdataManager.DeleteCPTModifier(ccm);
        }
        public List<RateGroupModel> GetRateGroup(RateGroupModelAll rm)
        {
            return masterdataManager.GetRateGroup(rm);
        }
        public string InsertUpdateRateGroup(RateGroupModelAll RateGroup)
        {
            return masterdataManager.InsertUpdateRateGroup(RateGroup);
        }
        public string DeleteRateGroup(RateGroupModel ccm)
        {
            return masterdataManager.DeleteRateGroup(ccm);
        }
        public List<PackageModel> GetPackage(PackageModelAll pm)
        {
            return masterdataManager.GetPackage(pm);
        }
        public string InsertUpdatePackage(PackageModelAll movement)
        {
            return masterdataManager.InsertUpdatePackage(movement);
        }
        public string DeletePackage(PackageModel movement)
        {
            return masterdataManager.DeletePackage(movement);
        }
        public List<DepartmentModel> GetDepartment(DepartmentModelAll Dept)
        {
            return masterdataManager.GetDepartment(Dept);
        }
        public string InsertUpdateDepartment(DepartmentModelAll Dept)
        {
            return masterdataManager.InsertUpdateDepartment(Dept);
        }
        public string DeleteDepartment(DepartmentModel Dept)
        {
            return masterdataManager.DeleteDepartment(Dept);
        }
        public List<SymptomModel> GetSymptom(SymptomModelAll symptom)
        {
            return masterdataManager.GetSymptom(symptom);
        }
        public List<LocationModel> GetLocation(LocationAll location)
        {
            return masterdataManager.GetLocation(location);
        }
        public string InsertUpdateLocation(LocationAll location)
        {
            return masterdataManager.InsertUpdateLocation(location);
        }
        public string DeleteLocation(LocationModel location)
        {
            return masterdataManager.DeleteLocation(location);
        }
        public List<LocationModel> GetAssociativeLocationById(LocationAll location)
        {
            return masterdataManager.GetAssociativeLocationById(location);
        }
        public List<CountryModel> GetCountry(CountryModel country)
        {
            return masterdataManager.GetCountry(country);
        }
        public string InsertUpdateCountry(CountryModel country)
        {
            return masterdataManager.InsertUpdateCountry(country);
        }
        public string DeleteCountry(CountryModel country)
        {
            return masterdataManager.DeleteCountry(country);
        }
        public List<StateModel> GetState(StateModel state)
        {
            return masterdataManager.GetState(state);
        }
        public string InsertUpdateState(StateModel state)
        {
            return masterdataManager.InsertUpdateState(state);
        }
        public string DeleteState(StateModel state)
        {
            return masterdataManager.DeleteState(state);
        }
        public string DeleteCompany(CompanyModel cmp)
        {
            return masterdataManager.DeleteCompany(cmp);
        }
        public List<ProfessionModel> GetProfession(ProfessionModelAll prof)
        {
            return masterdataManager.GetProfession(prof);
        }
        public string DeleteProfession(ProfessionModel prof)
        {
            return masterdataManager.DeleteProfession(prof);
        }
        public List<CityModel> GetCity(CityModelAll city)
        {
            return masterdataManager.GetCity(city);
        }
        public string InsertUpdateCity(CityModelAll city)
        {
            return masterdataManager.InsertUpdateCity(city);
        }
        public string DeleteCity(CityModel city)
        {
            return masterdataManager.DeleteCity(city);
        }
        public List<VitalSignModel> GetVitalSign(VitalSignModelAll vitalsign)
        {
            return masterdataManager.GetVitalSign(vitalsign);
        }
        public string InsertUpdateVitalSign(VitalSignModelAll vitalsign)
        {
            return masterdataManager.InsertUpdateVitalSign(vitalsign);
        }
        public List<LedgerHeadModel> GetLedgerHead(LedgerHeadModelAll ledgerHead)
        {
            return masterdataManager.GetLedgerHead(ledgerHead);
        }
        public string InsertUpdateLedgerHead(LedgerHeadModelAll ledgerHead)
        {
            return masterdataManager.InsertUpdateLedgerHead(ledgerHead);
        }
        public string DeleteLedgerHead(LedgerHeadModelAll ledgerHead)
        {
            return masterdataManager.DeleteLedgerHead(ledgerHead);
        }
        public List<BodyPartModelReturn> GetBodyPart(BodyPartModel bodypart)
        {
            return masterdataManager.GetBodyPart(bodypart);
        }
        public string InsertUpdateBodyPart(BodyPartRegModel bodypart)
        {
            if (bodypart.BodyPartImgFile != null)
            {
                bodypart.BodyPartImageLocation = fileUploadService.SaveFile(bodypart.BodyPartImgFile, "bodyparts");
            }
            return masterdataManager.InsertUpdateBodyPart(bodypart);
        }
        public string DeleteBodyPart(BodyPartModel bodypart)
        {
            return masterdataManager.DeleteBodyPart(bodypart);
        }
        public List<SketchIndicatorModel> GetSketchIndicators(SketchIndicatorModelAll sketch)
        {
            return masterdataManager.GetSketchIndicators(sketch);
        }
        public string InsertUpdateSketchIndicator(SketchIndicatorRegModel sketch)
        {
            if (sketch.IndicatorFile != null)
            {
                sketch.ImageUrl = fileUploadService.SaveFile(sketch.IndicatorFile, "sketchindicators");
            }
            return masterdataManager.InsertUpdateSketchIndicator(sketch);
        }
        public string DeleteSketchIndicator(SketchIndicatorModelAll sketch)
        {
            return masterdataManager.DeleteSketchIndicator(sketch);
        }
        public List<RegSchemeModel> GetRegScheme(RegSchemeModelAll RegSchemeId)
        {
            return masterdataManager.GetRegScheme(RegSchemeId);
        }
        public List<CommonMasterFieldModel> GetSalutation(CommonMasterFieldModelAll salutation)
        {
            return masterdataManager.GetSalutation(salutation);
        }
        public List<MaritalStatusModel> GetMaritalStatus(MaritalStatusModelAll msma)
        {
            return masterdataManager.GetMaritalStatus(msma);
        }
        public string InsertUpdateMaritalStatus(MaritalStatusModelAll maritalstatus)
        {
            return masterdataManager.InsertUpdateMaritalStatus(maritalstatus);
        }
        public string DeleteMaritalStatus(MaritalStatusModelAll maritalStatus)
        {
            return masterdataManager.DeleteMaritalStatus(maritalStatus);
        }
        public List<CommunicationTypeModel> GetCommunicationType(CommunicationTypeModelAll ctype)
        {
            return masterdataManager.GetCommunicationType(ctype);
        }
        public string InsertUpdateCommunicationType(CommunicationTypeModelAll ctype)
        {
            return masterdataManager.InsertUpdateCommunicationType(ctype);
        }
        public string DeleteCommunicationType(CommunicationTypeModelAll ctype)
        {
            return masterdataManager.DeleteCommunicationType(ctype);
        }
        public List<VisaTypeModel> GetVisaType(VisaTypeModelAll visatype)
        {
            return masterdataManager.GetVisaType(visatype);
        }
        public string InsertUpdateVisaType(VisaTypeModelAll visatype)
        {
            return masterdataManager.InsertUpdateVisaType(visatype);
        }
        public string DeleteVisaType(VisaTypeModelAll visatype)
        {
            return masterdataManager.DeleteVisaType(visatype);
        }
        public List<ReligionModel> GetReligion(ReligionModelAll religion)
        {
            return masterdataManager.GetReligion(religion);
        }
        public string InsertUpdateReligion(ReligionModelAll religion)
        {
            return masterdataManager.InsertUpdateReligion(religion);
        }
        public string DeleteReligion(ReligionModelAll religion)
        {
            return masterdataManager.DeleteReligion(religion);
        }
        public List<LeadAgentModel> GetLeadAgent(LeadAgentModelAll la)
        {
            return masterdataManager.GetLeadAgent(la);
        }
        public string InsertUpdateLeadAgent(LeadAgentModelAll la)
        {
            return masterdataManager.InsertUpdateLeadAgent(la);
        }
        public string DeleteLeadAgent(LeadAgentModelAll la)
        {
            return masterdataManager.DeleteLeadAgent(la);
        }
        public List<QuestionModel> GetQuestionareEMR(QuestionModel ccm)
        {
            return masterdataManager.GetQuestionareEMR(ccm);
        }
        public string InsertUpdateDeleteQuestionareEMR(QuestionModel serviceitem)
        {
            return masterdataManager.InsertUpdateDeleteQuestionareEMR(serviceitem);
        }
        public List<SponsorMasterModel> GetSponsor(SponsorMasterModelAll sponsor)
        {
            return masterdataManager.GetSponsor(sponsor);
        }
        public string InsertUpdateSponsor(SponsorMasterModelAll sponsor)
        {
            return masterdataManager.InsertUpdateSponsor(sponsor);
        }
        public string DeleteSponsor(SponsorMasterModelAll sponsor)
        {
            return masterdataManager.DeleteSponsor(sponsor);
        }
        public List<SponsorTypeModel> GetSponsorType(Int32 id)
        {
            return masterdataManager.GetSponsorType(id);
        }
        public string InsertUpdateSponsorType(SponsorTypeModel stype)
        {
            return masterdataManager.InsertUpdateSponsorType(stype);
        }
        public List<TaxModel> GetTax(TaxModelAll tax)
        {
            return masterdataManager.GetTax(tax);
        }
        public string InsertUpdateTax(TaxModelAll tax)
        {
            return masterdataManager.InsertUpdateTax(tax);
        }
        public string DeleteTax(TaxModelAll tax)
        {
            return masterdataManager.DeleteTax(tax);
        }
        public List<ItemGroupTypeModel> GetItemGroupType(ItemGroupTypeModel tax)
        {
            return masterdataManager.GetItemGroupType(tax);
        }
        public List<CurrencyModel> GetCurrency(CurrencyModelAll tax)
        {
            return masterdataManager.GetCurrency(tax);
        }
        public string InsertUpdateCurrency(CurrencyModelAll tax)
        {
            return masterdataManager.InsertUpdateCurrency(tax);
        }
        public string DeleteCurrency(CurrencyModelAll tax)
        {
            return masterdataManager.DeleteCurrency(tax);
        }
        /////////////////////////////////////////////////////////////////////////////

        public List<ConsultantMasterModel> GetConsultant(ConsultantMasterModel consultant)
        {
            return masterdataManager.GetConsultant(consultant);
        }
        public string DeleteConsultant(ConsultantMasterModel consultant)
        {
            return masterdataManager.DeleteConsultant(consultant);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public string InsertUpdateMenuGroupMap(MenuGroupModel mgm)
        {
            return masterdataManager.InsertUpdateMenuGroupMap(mgm);
        }
        public List<SponsorFormModel> GetSponsorForm(Int32 id)
        {
            return masterdataManager.GetSponsorForm(id);
        }
        public string InsertUpdateSponsorForm(SponsorFormModel stype)
        {
            return masterdataManager.InsertUpdateSponsorForm(stype);
        }
        public List<AppTypeModel> GetAppType()
        {
            return masterdataManager.GetAppType();
        }
        public List<FormValidationModel> GetFormMaster()
        {
            return masterdataManager.GetFormMaster();
        }
        public List<FormValidationModel> GetFormFields(Int32 Id)
        {
            return masterdataManager.GetFormFields(Id);
        }

        public string InsertUpdateDeleteZone(ZoneModelAll zone)
        {
            return masterdataManager.InsertUpdateDeleteZone(zone);
        }

        public List<ZoneModel> GetZone(ZoneModelAll zoneId)
        {
            return masterdataManager.GetZone(zoneId);
        }
        public List<ConsultantDrugModel> GetDrugs(ConsultantDrugModel cm)
        {
            return masterdataManager.GetDrugs(cm);
        }
        public List<RouteModel> GetRoute(RouteModel rm)
        {
            return masterdataManager.GetRoute(rm);
        }
        public List<PendingItemModel> GetPendingServiceItemsByPatient(PendingItemInputData dm)
        {
            return masterdataManager.GetPendingServiceItemsByPatient(dm);
        }
        public List<HospitalModel> GetUserHospitals(Int32 id)
        {
            return masterdataManager.GetUserHospitals(id);
        }
        public string InsertUpdateUserHospitals(HospitalRegModel hm)
        {
            if (hm.LogoFile != null)
            {
                hm.Logo = fileUploadService.SaveFile(hm.LogoFile, "documents");
            }
            if (hm.ReportLogoFile != null)
            {
                hm.ReportLogo = fileUploadService.SaveFile(hm.LogoFile, "documents");
            }
            return masterdataManager.InsertUpdateUserHospital(hm);
        }
        public string ConsentFormDataSave(ConsentFormRegModel hm)
        {

            if (hm.SignFile != null)
            {
                hm.Sign = fileUploadService.SaveFile(hm.SignFile, "documents");
            }
            return masterdataManager.ConsentFormDataSave(hm);
        }



        public string InsertUpdateOperator(OperatorModel Operator)
        {
            return masterdataManager.InsertUpdateOperator(Operator);
        }
        public List<OperatorModel> GetOperator(Int32 OperatorId)
        {
            return masterdataManager.GetOperator(OperatorId);
        }
        public List<ConsultantModel> GetConsultantByHospital(ConsultantModel cmodel)
        {
            return masterdataManager.GetConsultantByHospital(cmodel);
        }
        public List<ConsentPreviewModel> GetConsentPreviewConsent(Int32 patientId)
        {
            return masterdataManager.GetConsentPreviewConsent(patientId);
        }
        public List<ConsentContentModel> GetConsent(Int32 patientId)
        {
            return masterdataManager.GetConsent(patientId);
        }
        public string InsertUpdateConsent(ConsentContentModel consent)
        {
            return masterdataManager.InsertUpdateConsent(consent);
        }

        public List<ScientificNameModel> GetScientificName(ScientificNameModelAll scientificName)
        {
            return masterdataManager.GetScientificName(scientificName);
        }
        public string InsertUpdateScientificName(ScientificNameModelAll scientificName)
        {
            return masterdataManager.InsertUpdateScientificName(scientificName);
        }
        public List<StateModel> GetStateByCountryId(Int32 countryid)
        {
            return masterdataManager.GetStateByCountryId(countryid);
        }

        public List<ItemsByTypeModel> GetItemsByType(ItemsByTypeModel ibt)
        {
            return masterdataManager.GetItemsByType(ibt);
        }
        public List<ConsentTypeModel> GetConsentType()
        {
            return masterdataManager.GetConsentType();
        }

        public List<GetNumberModel> GetNumber(string numid)
        {
            return masterdataManager.GetNumber(numid);
        }
        public string UpdateNumberTable(GetNumberModel la)
        {
            return masterdataManager.UpdateNumberTable(la);
        }
        public List<GenderModel> GetGender()
        {
            return masterdataManager.GetGender();
        }
        public List<KinRelationModel> GetKinRelation()
        {
            return masterdataManager.GetKinRelation();
        }
        public List<HospitalModel> GetUserSpecificHospitals(int UserId)
        {
            return masterdataManager.GetUserSpecificHospitals(UserId);
        }
        public List<LocationModel> GetUserSpecificHospitalLocations(int userId, int branch)
        {

            return masterdataManager.GetUserSpecificHospitalLocations(userId, branch);
        }


        public string InsertUpdateICDGroup(ICDGroupModelAll icdGroup)
        {
            return masterdataManager.InsertUpdateICDGroup(icdGroup);
        }
        public List<ICDGroupModel> GetICDGroup(ICDGroupModelAll group)
        {
            return masterdataManager.GetICDGroup(group);
        }
        public string DeleteICDGroup(ICDGroupModelAll icdGroup)
        {
            return masterdataManager.DeleteICDGroup(icdGroup); 
        }

        public string InsertUpdateICDCategory(ICDCategoryModelAll icdCateg)
        {
            return masterdataManager.InsertUpdateICDCategory(icdCateg);
        }
        public List<ICDCategoryModel> GetICDCategory(ICDCategoryModelAll icdCateg)
        {
            return masterdataManager.GetICDCategory(icdCateg);
        }


        public string InsertUpdateICDLabel(ICDLabelModelAll icdLabel)
        {
            return masterdataManager.InsertUpdateICDLabel(icdLabel);
        }
        public string DeleteICDLabel(ICDLabelModelAll icdLabel)
        {
            return masterdataManager.DeleteICDLabel(icdLabel);
        }
        public List<ICDLabelModel> GetICDLabel(ICDLabelModelAll label)
        {
            return masterdataManager.GetICDLabel(label);
        }
        public string InsertUpdateProfile(ProfileModelAll profile)
        {
            return masterdataManager.InsertUpdateProfile(profile);
        }
        public List<ProfileModel> GetProfile(ProfileModelAll profile)
        {
            return masterdataManager.GetProfile(profile);
        }
        public string DeleteProfile(ProfileModelAll profile)
        {
            return masterdataManager.DeleteProfile(profile);
        }
        public List<ProfileItemModel> GetItemForProfile(int patientId)
        {
            return masterdataManager.GetItemForProfile(patientId);
        }
        public List<LocationModel> GetLocationByType(LocationAll location)
        {
            return masterdataManager.GetLocationByType(location);
        }
        public string InsertAssociateLocation(LocationAssociateModel locationAssociate)
        {
            return masterdataManager.InsertAssociateLocation(locationAssociate);
        }
        public string InsertUpdateServicePoint(ServicePointModel servicePoint)
        {
            return masterdataManager.InsertUpdateServicePoint(servicePoint);
        }
        public List<ServicePointModel> GetServicePoint(ServicePointModelAll sPoint)
        {
            return masterdataManager.GetServicePoint(sPoint);
        }
        public string DeleteServicePoint(ServicePointModel servicePoint)
        {
            return masterdataManager.DeleteServicePoint(servicePoint);
        }
        public string InsertUpdateDeleteTradeName(TradeNameModelAll tradeName)
        {
            return masterdataManager.InsertUpdateDeleteTradeName(tradeName);
        }
        public List<TradeNameModel> GetTradeName(TradeNameModelAll tradeName)
        {
            return masterdataManager.GetTradeName(tradeName);
        }
        public string InsertUpdateDeleteDrug(DrugModelAll drug)
        {
            return masterdataManager.InsertUpdateDeleteDrug(drug);
        }
        public List<DrugModel> GetDrug(DrugModelAll drug)
        {
            return masterdataManager.GetDrug(drug);
        }
        public string InsertUpdateDeleteInformedConsent(InformedConsentModelAll informedConsent)
        {
            return masterdataManager.InsertUpdateDeleteInformedConsent(informedConsent);
        }
        public List<InformedConsentModel> GetInformedConsent(InformedConsentModelAll informedConsent)
        {
            return masterdataManager.GetInformedConsent(informedConsent);
        }
        public string InsertUpdateDeletePatientConsent(PatientConsentModelAll patientConsent)
        {
            return masterdataManager.InsertUpdateDeletePatientConsent(patientConsent);
        }
        public List<PatientConsentModel> GetPatientConsent(PatientConsentModelAll patientConsent)
        {
            return masterdataManager.GetPatientConsent(patientConsent);
        }
        public string InsertUpdateDeleteSponserConsent(SponserConsentModelAll sponserConsent)
        {
            return masterdataManager.InsertUpdateDeleteSponserConsent(sponserConsent);
        }
        public List<SponserConsentModel> GetSponserConsent(SponserConsentModelAll sponserConsent)
        {
            return masterdataManager.GetSponserConsent(sponserConsent);
        }
        public List<DosageModel> GetDosage(DosageModelAll dosageModel)
        {
            return masterdataManager.GetDosage(dosageModel);
        }
        public string InsertUpdateDeleteDosage(DosageModelAll dosageModel)
        {
            return masterdataManager.InsertUpdateDeleteDosage(dosageModel);
        }
        public List<FrequencyModel> GetFrequency(FrequencyModelAll frequency)
        {
            return masterdataManager.GetFrequency(frequency);
        }
        public string InsertUpdateDeleteFrequency(FrequencyModelAll frequency)
        {
            return masterdataManager.InsertUpdateDeleteFrequency(frequency);
        }
        public List<ConsentGroupModel> GetConsentGroup()
        {
            return masterdataManager.GetConsentGroup();
        }
    }
}
