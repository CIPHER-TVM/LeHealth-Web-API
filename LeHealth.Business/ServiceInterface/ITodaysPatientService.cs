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
        List<PatientModel> InsertPatient(PatientModel patientDetail);
        List<CountryModel> GetCountry(CountryModel countryDetail);
        List<SearchAppointmentModel> GetAllAppointments(AppointmentModel appointment);
        List<AppSearchModel> SearchAppointment(AppointmentModel appointment);
        List<AllPatientModel> GetAllPatient();
        List<PatientListModel> SearchPatient(PatientSearchModel patientList);


    }
}
