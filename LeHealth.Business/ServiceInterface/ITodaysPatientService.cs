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
       
        List<CountryModel> GetCountry(CountryModel countryDetail);
        List<SearchAppointmentModel> GetAllAppointments(AppointmentModel appointment); 
        List<SearchAppointmentModel> GetAppointmentById(AppointmentModel appointment);
        List<SearchAppointmentModel> SearchAppointment(AppointmentModel appointment);
        List<PatientListModel> SearchPatient(PatientSearchModel patientList);
        List<PatientListModel> GetPatientByRegNo(string Regno);
        FrontOfficePBarModel GetFrontOfficeProgressBars(string patientList);
        List<MandatoryFieldsModel> GetSavingSchemaMandatory(string formname);
        List<SchemeModel> GetSchemeByConsultant(int consultantid);
        List<VisaTypeModel> GetVisaType();
        List<GetAppNoModel> GetAppNumber(GetAppNumberIPModel gap);
        List<GetAppTimeModel> GetAppTime(GetAppNumberIPModel gap);
        List<StateModel> GetStateByCountryId(int countryId);
        
        string DeleteAppointment(AppointmentModel appointment);
        string CancelConsultation(ConsultationModel consultantion); 
        string PostponeAppointment(Appointments appointments); 
        string SetUrgentConsultation(ConsultationModel consultantion);  
        
        List<ConsultationModel> InsertUpdateConsultation(ConsultationModel consultations);
        List<TokenModel> GetNewTokenNumber(ConsultationModel cm); 
        List<SheduleGetDataModel> GetScheduleData(GetScheduleInputModel gsi); 
        List<SponsorModel> GetSponsorListByPatientId(int patientId);
        List<RecentConsultationModel> GetRecentConsultationData();
        List<ConsultRateModel> GetConsultRate(ConsultationModel cm);
        List<SymptomModel> GetActiveSymptoms();
        List<ConsultantModel> GetConsultant(ConsultantByDeptModel cm);
        string AppoinmentValidCheck(AppoinmentValidCheckModel cm);
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
