using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface ITodaysPatientService
    {
        /// <summary>
        /// adding a new patient registration 
        /// </summary>
        string InsertPatient(PatientModel patientDetail);
        List<CountryModel> GetCountry(CountryModel countryDetail);
        List<SearchAppointmentModel> GetAllAppointments(AppointmentModel appointment);
        List<AppSearchModel> SearchAppointment(AppointmentModel appointment);
        List<PatientListModel> SearchPatient(PatientSearchModel patientList);
        List<MandatoryFieldsModel> GetSavingSchemaMandatory(string formname);
        List<SchemeModel> GetSchemeByConsultant(int consultantid);
        List<VisaTypeModel> GetVisaType();
        List<GetAppNoModel> GetAppNumber(GetAppNumberIPModel gap);
        List<GetAppTimeModel> GetAppTime(GetAppNumberIPModel gap);
        List<StateModel> GetStateByCountryId(int countryId);
        List<ReligionModel> GetReligion();
        string SendAddPatientInformation(int patientId);
        string InsertZone(ZoneModel zone);
        string UpdateZone(ZoneModel zone);
        string DeleteZone(int zoneId);
        string DeleteAppointment(AppointmentModel appointment);
        List<ZoneModel> GetZoneById(int zoneId);
        List<ZoneModel> GetAllZone();
        List<ConsultationModel> InsertUpdateConsultation(ConsultationModel consultations);
        List<TokenModel> GetNewTokenNumber(ConsultationModel cm); 
        List<SheduleGetDataModel> GetScheduleData(GetScheduleInputModel gsi); 
        List<SponsorModel> GetSponsorListByPatientId(int patientId);
        List<RecentConsultationModel> GetRecentConsultationData();
        List<ConsultRateModel> GetConsultRate(ConsultationModel cm);
        List<SymptomModel> GetActiveSymptoms();
        List<ConsultantModel> GetConsultant(ConsultantByDeptModel cm);
        List<ConsultationByPatientIdModel> GetConsultationByPatientId(ConsultationModel cm);
        List<PatRegByPatientIdModel> GetPatRegByPatientId(ConsultationModel cm);
        List<ConsultRateModel> GetRegSchmAmtOfPatient(ConsultationModel cm);
        List<PatientModel> GetPatient(int pid);
        List<GetNumberModel> GetNumber(String nid);
        List<GetConsultantItemSchemeRateModel> GetConsultantItemSchemeRate(ConsultantItemSchemeRateIPModel cisr);
        List<ItemsByTypeModel> GetItemsByType(ItemsByTypeModel ibt);
        List<LeadAgentModel> GetLeadAgent(LeadAgentModel la);
        List<CompanyModel> GetCompany();
        
    }
}
