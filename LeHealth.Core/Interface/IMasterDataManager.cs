﻿using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;


namespace LeHealth.Core.Interface
{
    public interface IMasterDataManager
    {

        List<ProfessionModel> GetProfession(Int32 profid);
        string InsertUpdateProfession(ProfessionModel prof);
        string InsertUpdateMenuGroupMap(MenuGroupModel mgm);
        List<SponsorMasterModel> GetSponsor(Int32 sponsorid);
        string InsertUpdateSponsor(SponsorMasterModel sponsor);
        string InsertUpdateZone(ZoneModel zone);
        List<ZoneModel> GetZone(Int32 zoneId);
        List<ConsultantDrugModel> GetDrugs(ConsultantDrugModel cm);
        List<RouteModel> GetRoute(RouteModel dm);
        List<DosageModel> GetDosage(DosageModel dm);
        List<PendingItemModel> GetPendingServiceItemsByPatient(PendingItemInputData dm);
        string InsertUpdateRateGroup(RateGroupModel RateGroup);
        List<RateGroupModel> GetRateGroup(Int32 RateGroupId);
        string InsertUpdateOperator(OperatorModel Operator);
        List<OperatorModel> GetOperator(Int32 OperatorId);
        string InsertUpdateRegScheme(RegSchemeModel RegScheme);
        List<RegSchemeModel> GetRegScheme(Int32 RegSchemeId);
        List<HospitalModel> GetUserHospitals(Int32 id);
        string InsertUpdateUserHospital(HospitalRegModel hm);
        string ConsentFormDataSave(ConsentFormRegModel hm);
        List<LeadAgentModel> GetLeadAgent(Int32 la);
        string InsertUpdateLeadAgent(LeadAgentModel la);
        List<CompanyModel> GetCompany(Int32 Id);
        string InsertUpdateCompany(CompanyModel cmp);


        //DEPARTMENT MANAGEMENT STARTS
        List<DepartmentModel> GetDepartments(Int32 DeptId);
        List<DepartmentModel> GetDepartmentByHospital(Int32 HospId);
        List<ConsultantModel> GetConsultantByHospital(ConsultantModel cmodel);
        string InsertUpdateDepartment(DepartmentModel Dept); 
        //DEPARTMENT MANAGEMENT ENDS

        //Consent Management starts
        List<ConsentPreviewModel> GetConsentPreviewConsent(Int32 consentId);
        List<ConsentContentModel> GetConsent(Int32 consentId);
        string InsertUpdateConsent(ConsentContentModel consent);

        //Consent Management ends
        List<CountryModel> GetCountry(Int32 countryDetails);
        string InsertUpdateCountry(CountryModel countryDetails);
        List<StateModel> GetState(Int32 stateDetails);
        string InsertUpdateState(StateModel stateDetails);
        List<SalutationModel> GetSalutation(Int32 salutationDetails);
        string InsertUpdateSalutation(SalutationModel salutationDetails);
        List<BodyPartModel> GetBodyPart(Int32 bodyPartId);
        string InsertUpdateBodyPart(BodyPartModel bodyPart);
        List<SponsorTypeModel> GetSponsorType(Int32 sponsorType);
        string InsertUpdateSponsorType(SponsorTypeModel sponsorType);

        List<SponsorFormModel> GetSponsorForm(Int32 sponsorForm);
        string InsertUpdateSponsorForm(SponsorFormModel sponsorForm);
        List<CityModel> GetCity(Int32 city);
        string InsertUpdateCity(CityModel city);
        string InsertUpdateSymptom(SymptomModel symptom);

        List<VitalSignModel> GetVitalSign(Int32 vitalsign);
        string InsertUpdateVitalSign(VitalSignModel vitalsign);
        List<MovementModel> GetMovement(Int32 movement);
        string InsertUpdateMovement(MovementModel movement);

        List<PackageModel> GetPackage(PackageModel pm);
        string InsertUpdatePackage(PackageModel package);

        List<LocationModel> GetLocation(Int32 location);
        string InsertUpdateLocation(LocationModel package);

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
        List<SymptomModel> GetActiveSymptoms();
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
