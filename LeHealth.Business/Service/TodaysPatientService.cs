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
        public TodaysPatientService( ITodaysPatientManager _todaysPatientManager)
        {
            todaysPatientManager = _todaysPatientManager;

        }
        /// <summary>
        /// adding a new patient registration 
        /// </summary>
        public List<PatientModel> InsertPatient(PatientModel patientDetail)
        {
            return todaysPatientManager.InsertPatient(patientDetail);
        }
        public List<CountryModel> GetCountry(CountryModel countryDetails)
        {
            return todaysPatientManager.GetCountry(countryDetails);
        }
    }
}
