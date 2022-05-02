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

        public string InsertUpdateServiceItem(ServiceItemModel serviceitem)
        {
            return masterdataManager.InsertUpdateServiceItem(serviceitem);
        }
        public string BlockUnblockServiceItem(ServiceItemModel serviceitem)
        {
            return masterdataManager.BlockUnblockServiceItem(serviceitem);
        }
        public List<CPTCodeModel> GetCPTCode(CPTCodeModelAll ccm)
        {
            return masterdataManager.GetCPTCode(ccm);
        }
        public string InsertUpdateCPTCode(CPTCodeModelAll ccm)
        {
            return masterdataManager.InsertUpdateCPTCode(ccm);
        }
        public string DeleteCPTCode(CPTCodeModel ccm)
        {
            return masterdataManager.DeleteCPTCode(ccm);
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
        //public List<DepartmentModel> GetDepartmentByHospital(Int32 HospId)
        //{
        //    return masterdataManager.GetDepartmentByHospital(HospId);
        //}
        public string DeleteDepartment(DepartmentModel Dept)
        {
            return masterdataManager.DeleteDepartment(Dept);
        }
        public List<SymptomModel> GetSymptom(SymptomModelAll symptom)
        {
            return masterdataManager.GetSymptom(symptom);
        }
        public string InsertUpdateSymptom(SymptomModelAll la)
        {
            return masterdataManager.InsertUpdateSymptom(la);
        }
        public string DeleteSymptom(SymptomModel la)
        {
            return masterdataManager.DeleteSymptom(la);
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
        public List<CompanyModel> GetCompany(CompanyModelAll cmp)
        {
            return masterdataManager.GetCompany(cmp);
        }
        public string InsertUpdateCompany(CompanyModelAll cmp)
        {
            return masterdataManager.InsertUpdateCompany(cmp);
        }
        public string DeleteCompany(CompanyModel cmp)
        {
            return masterdataManager.DeleteCompany(cmp);
        }
        public List<ProfessionModel> GetProfession(ProfessionModelAll prof)
        {
            return masterdataManager.GetProfession(prof);
        }
        public string InsertUpdateProfession(ProfessionModelAll prof)
        {
            return masterdataManager.InsertUpdateProfession(prof);
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
        public string DeleteVitalSign(VitalSignModelAll vitalsign)
        {
            return masterdataManager.DeleteVitalSign(vitalsign);
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
        public List<SponsorMasterModel> GetSponsor(Int32 profid)
        {
            return masterdataManager.GetSponsor(profid);
        }
        public string InsertUpdateSponsor(SponsorMasterModel zone)
        {
            return masterdataManager.InsertUpdateSponsor(zone);
        }
        public List<SponsorTypeModel> GetSponsorType(Int32 id)
        {
            return masterdataManager.GetSponsorType(id);
        }
        public string InsertUpdateSponsorType(SponsorTypeModel stype)
        {
            return masterdataManager.InsertUpdateSponsorType(stype);
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

        public string InsertUpdateZone(ZoneModel zone)
        {
            return masterdataManager.InsertUpdateZone(zone);
        }

        public List<ZoneModel> GetZone(Int32 zoneId)
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
        public List<DosageModel> GetDosage(DosageModel dm)
        {
            return masterdataManager.GetDosage(dm);
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
                hm.Logo = fileUploadService.SaveFile(hm.LogoFile);
            }
            if (hm.ReportLogoFile != null)
            {
                hm.ReportLogo = fileUploadService.SaveFile(hm.LogoFile);
            }
            return masterdataManager.InsertUpdateUserHospital(hm);
        }
        public string ConsentFormDataSave(ConsentFormRegModel hm)
        {

            if (hm.SignFile != null)
            {
                hm.Sign = fileUploadService.SaveFile(hm.SignFile);
            }
            return masterdataManager.ConsentFormDataSave(hm);
        }
        public string InsertUpdateRegScheme(RegSchemeModel RegScheme)
        {
            return masterdataManager.InsertUpdateRegScheme(RegScheme);
        }
        public List<RegSchemeModel> GetRegScheme(Int32 RegSchemeId)
        {
            return masterdataManager.GetRegScheme(RegSchemeId);
        }

        public string InsertUpdateOperator(OperatorModel Operator)
        {
            return masterdataManager.InsertUpdateOperator(Operator);
        }
        public List<OperatorModel> GetOperator(Int32 OperatorId)
        {
            return masterdataManager.GetOperator(OperatorId);
        }
        public List<ReligionModel> GetReligion()
        {
            return masterdataManager.GetReligion();
        }
        public List<LeadAgentModel> GetLeadAgent(Int32 la)
        {
            return masterdataManager.GetLeadAgent(la);
        }
        public string InsertUpdateLeadAgent(LeadAgentModel la)
        {
            return masterdataManager.InsertUpdateLeadAgent(la);
        }
        public List<BodyPartModel> GetBodyPart(BodyPartModelAll bodypart)
        {
            return masterdataManager.GetBodyPart(bodypart);
        }
        public string InsertUpdateBodyPart(BodyPartModelAll bodypart)
        {
            return masterdataManager.InsertUpdateBodyPart(bodypart);
        }
        public string DeleteBodyPart(BodyPartModelAll bodypart)
        {
            return masterdataManager.DeleteBodyPart(bodypart);
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

        public List<SalutationModel> GetSalutation(Int32 stateDetails)
        {
            return masterdataManager.GetSalutation(stateDetails);
        }
        public string InsertUpdateSalutation(SalutationModel state)
        {
            return masterdataManager.InsertUpdateSalutation(state);
        }



        public List<MovementModel> GetMovement(Int32 movement)
        {
            return masterdataManager.GetMovement(movement);
        }
        public string InsertUpdateMovement(MovementModel movement)
        {
            return masterdataManager.InsertUpdateMovement(movement);
        }


        public List<ScientificNameModel> GetScientificName(Int32 movement)
        {
            return masterdataManager.GetScientificName(movement);
        }
        public string InsertUpdateScientificName(ScientificNameModel movement)
        {
            return masterdataManager.InsertUpdateScientificName(movement);
        }
        public List<TendernModel> GetTendern(Int32 movement)
        {
            return masterdataManager.GetTendern(movement);
        }
        public string InsertUpdateTendern(TendernModel movement)
        {
            return masterdataManager.InsertUpdateTendern(movement);
        }
        public List<VisaTypeModel> GetVisaType()
        {
            return masterdataManager.GetVisaType();
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
        public List<MaritalStatusModel> GetMaritalStatus()
        {
            return masterdataManager.GetMaritalStatus();
        }
        public List<CommunicationTypeModel> GetCommunicationType()
        {
            return masterdataManager.GetCommunicationType();
        }
        public List<HospitalModel> GetUserSpecificHospitals(int UserId)
        {
            return masterdataManager.GetUserSpecificHospitals(UserId);
        }
        public List<LocationModel> GetUserSpecificHospitalLocations(int userId, int branch)
        {

            return masterdataManager.GetUserSpecificHospitalLocations(userId, branch);
        }



    }
}
