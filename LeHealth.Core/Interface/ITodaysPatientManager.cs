using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
   public interface ITodaysPatientManager
    {
        List<PatientModel> InsertPatient(PatientModel patientDetail);
        List<CountryModel> GetCountry(CountryModel countryDetails);

    }
}
