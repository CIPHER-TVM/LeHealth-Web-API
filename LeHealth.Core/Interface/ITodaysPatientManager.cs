using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
   public interface ITodaysPatientManager
    {
        string InsertPatient(PatientModel patientDetail);
        List<CountryModel> GetCountry(CountryModel countryDetails);
        List<SearchAppointmentModel> GetAllAppointments(AppointmentModel appointment);
        List<AppSearchModel> SearchAppointment(AppointmentModel appointment);
        List<AllPatientModel> GetAllPatient();
        List<PatientListModel> SearchPatient(PatientSearchModel patientList);
        List<AllPatientModel> SearchPatientInList(PatientSearchModel patientList);
        List<MandatoryFieldsModel> GetSavingSchemaMandatory(string formname);
        List<SchemeModel> GetSchemeByConsultant(int consultantid);
        List<VisaTypeModel> GetVisaType();
        List<GetAppNoModel> GetAppNumber(GetAppNumberIPModel gap);
        List<GetAppTimeModel> GetAppTime(GetAppNumberIPModel gap);
        List<StateModel> GetStateByCountryId(int countryId);
        List<ReligionModel> GetReligion();
        string SendAddPatientInformation(int patientid);
        //
        string InsertZone(ZoneModel zone);
        string UpdateZone(ZoneModel zone);
        string DeleteZone(int zoneId);
        string DeleteAppointment(AppointmentModel appointment);
        List<ZoneModel> GetZoneById(int zoneId);
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
    } 
}
