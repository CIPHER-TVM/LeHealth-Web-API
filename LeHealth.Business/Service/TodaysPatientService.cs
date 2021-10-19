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
        public TodaysPatientService( ITodaysPatientManager _todaysPatientManager)
        {
            todaysPatientManager = _todaysPatientManager;

        }
        /// <summary>
        /// adding a new patient registration
        /// </summary>
        /// <param name="patientDetail"></param>
        public List<PatientModel> InsertPatient(PatientModel patientDetail)
        {
            return todaysPatientManager.InsertPatient(patientDetail);
        }
    }
}
