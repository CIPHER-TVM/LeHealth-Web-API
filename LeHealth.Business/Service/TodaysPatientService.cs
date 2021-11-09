using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.Service
{
    public class TodaysPatientService : ITodaysPatientService
    {
        private readonly ITodaysPatientManager todaysPatientManager;
        /// <summary>
        /// Initialising todaysPatientManager object
        /// </summary>
        /// <param name="_todaysPatientManager"></param>
        public TodaysPatientService(ITodaysPatientManager _todaysPatientManager)
        {
            todaysPatientManager = _todaysPatientManager;

        }
        /// <summary>
        /// adding a new patient registration 
        /// </summary>
        public string InsertPatient(PatientModel patientDetail)
        {
            return todaysPatientManager.InsertPatient(patientDetail);
        }
        public List<CountryModel> GetCountry(CountryModel countryDetails)
        {
            return todaysPatientManager.GetCountry(countryDetails);
        }
        public List<SearchAppointmentModel> GetAllAppointments(AppointmentModel countryDetails)
        {
            return todaysPatientManager.GetAllAppointments(countryDetails);
        }
        public List<AppSearchModel> SearchAppointment(AppointmentModel countryDetails)
        {
            return todaysPatientManager.SearchAppointment(countryDetails);
        }
        public List<AllPatientModel> GetAllPatient()
        {
            return todaysPatientManager.GetAllPatient();
        }


        public List<PatientListModel> SearchPatient(PatientSearchModel patientList)
        {
            return todaysPatientManager.SearchPatient(patientList);
        }
        public List<AllPatientModel> SearchPatientInList(PatientSearchModel patientList)
        {
            return todaysPatientManager.SearchPatientInList(patientList);
        }
        public List<MandatoryFieldsModel> GetSavingSchemaMandatory(string formname)
        {
            return todaysPatientManager.GetSavingSchemaMandatory(formname);
        }
        public List<SchemeModel> GetSchemeByConsultant(int consultantid)
        {
            return todaysPatientManager.GetSchemeByConsultant(consultantid);
        }
        public List<VisaTypeModel> GetVisaType()
        {
            return todaysPatientManager.GetVisaType();
        }
        public List<GetAppNoModel> GetAppNumber(GetAppNumberIPModel gap)
        {
            return todaysPatientManager.GetAppNumber(gap);
        }
        public List<GetAppTimeModel> GetAppTime(GetAppNumberIPModel gap)
        {
            return todaysPatientManager.GetAppTime(gap);
        }
        public string SendAddPatientInformation(int patientid)
        {
            return todaysPatientManager.SendAddPatientInformation(patientid);
        }
        public List<StateModel> GetStateByCountryId(int countryid)
        {
            return todaysPatientManager.GetStateByCountryId(countryid);
        }
        public List<ReligionModel> GetReligion()
        {
            return todaysPatientManager.GetReligion();
        }
        //
        public string InsertZone(ZoneModel zone)
        {
            return todaysPatientManager.InsertZone(zone);
        }
        public string DeleteAppointment(AppointmentModel appointment)
        {
            return todaysPatientManager.DeleteAppointment(appointment);
        }
        public string UpdateZone(ZoneModel zone)
        {
            return todaysPatientManager.UpdateZone(zone);
        }
        public string DeleteZone(int zoneId)
        {
            return todaysPatientManager.DeleteZone(zoneId);
        }
        public List<ZoneModel> GetZoneById(int zoneId)
        {
            return todaysPatientManager.GetZoneById(zoneId);
        }
        public List<ZoneModel> GetAllZone()
        {
            return todaysPatientManager.GetAllZone();
        }

    }
}
