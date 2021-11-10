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
        string SendAddPatientInformation(int patientId);
        string InsertZone(ZoneModel zone);
        string UpdateZone(ZoneModel zone);
        string DeleteZone(int zoneId);
        string DeleteAppointment(AppointmentModel appointment);
        List<ZoneModel> GetZoneById(int zoneId);
        List<ZoneModel> GetAllZone();
        List<ConsultationModel> InsertUpdateConsultation(ConsultationModel consultations);
        List<int> GetNewTokenNumber(ConsultationModel cm);
        List<SponsorModel> GetSponsorListByPatientId(int patientId);
    }
}
