using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
   public interface ITodaysPatientManager
    {
        
        List<CountryModel> GetCountry(CountryModel countryDetails);
        List<SearchAppointmentModel> GetAllAppointments(AppointmentModel appointment);
        List<AppSearchModel> SearchAppointment(AppointmentModel appointment);
        List<PatientListModel> SearchPatient(PatientSearchModel patientList);
        FrontOfficePBarModel GetFrontOfficeProgressBars(string patientList);
        List<MandatoryFieldsModel> GetSavingSchemaMandatory(string formname);
        List<SchemeModel> GetSchemeByConsultant(int consultantid);
        List<VisaTypeModel> GetVisaType();
        List<GetAppNoModel> GetAppNumber(GetAppNumberIPModel gap);
        List<GetAppTimeModel> GetAppTime(GetAppNumberIPModel gap);
        List<StateModel> GetStateByCountryId(int countryId);
        List<ReligionModel> GetReligion();
        //string SendAddPatientInformation(int patientid);
        //
        string InsertZone(ZoneModel zone);
        string UpdateZone(ZoneModel zone);
        string DeleteZone(int zoneId);
        string DeleteAppointment(AppointmentModel appointment);
        List<ZoneModel> GetZoneById(int zoneId);
        List<SheduleGetDataModel> GetScheduleData(GetScheduleInputModel gsi); 
        List<ZoneModel> GetAllZone();

        /// <summary>
        ///adding a new Consultation details
        /// </summary>
        List<ConsultationModel> InsertUpdateConsultation(ConsultationModel appointments);
        List<RecentConsultationModel> GetRecentConsultationData();

        List<TokenModel> GetNewTokenNumber(ConsultationModel cm); 
        List<SponsorModel> GetSponsorListByPatientId(int patientId);  
        List<SymptomModel> GetActiveSymptoms();  
        List<ConsultRateModel> GetConsultRate(ConsultationModel cm);

        /// <summary>
        /// To list of  all Consultants by dept id
        /// </summary>
        List<ConsultantModel> GetConsultant(ConsultantByDeptModel cm); 
        List<ConsultationByPatientIdModel> GetConsultationByPatientId(ConsultationModel cm); 
        List<PatRegByPatientIdModel> GetPatRegByPatientId(ConsultationModel cm);  
        List<ConsultRateModel> GetRegSchmAmtOfPatient(ConsultationModel cm);  
        List<PatientModel> GetPatient(int pid);   
        List<GetNumberModel> GetNumber(string numid);    
        List<GetConsultantItemSchemeRateModel> GetConsultantItemSchemeRate(ConsultantItemSchemeRateIPModel cisr);    
        List<ItemsByTypeModel> GetItemsByType(ItemsByTypeModel ibt);
        List<LeadAgentModel> GetLeadAgent(LeadAgentModel la);
        string CancelConsultation(ConsultationModel cons); 
        string SetUrgentConsultation(ConsultationModel cons);  
        List<CompanyModel> GetCompany();
        
    } 
} 
