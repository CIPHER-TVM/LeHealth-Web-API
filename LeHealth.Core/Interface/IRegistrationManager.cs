using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface IRegistrationManager
    {
        List<PatientRegModel> InsertPatient(PatientRegModel patientDetail);
        string UploadPatientDocuments(PatientRegModel patientDetail);
        string ValidateHL7(string nabidh);
        List<AllPatientModel> GetAllPatient(int BranchId);
      
        List<AllPatientModel> SearchPatientInList(PatientSearchModel patientList);
        List<AllPatientModel> ViewPatientFiles(Int32 patientId);
        List<PatientModel> GetRegisteredDataById(Int32 patientId);
        string SaveReRegistration(PatientModel patient);
        string BlockPatient(PatientModel patient);
        string DeletePatRegFiles(Int32 Id);
        string UnblockPatient(PatientModel patient);
    }
}
