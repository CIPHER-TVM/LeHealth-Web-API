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
        List<Appointments> GetAllAppointments(AppointmentModel appointment);
        List<Appointments> SearchAppointment(AppointmentModel appointment);
        List<PatientListModel> GetAllPatient();


    }
}
