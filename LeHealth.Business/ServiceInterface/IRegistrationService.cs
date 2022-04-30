using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface IRegistrationService
    {
        List<PatientRegModel> InsertPatient(PatientRegModel patientDetail);
        string UploadPatientDocuments(PatientRegModel patientDetail);
        List<AllPatientModel> GetAllPatient(int BranchId);
        List<AllPatientModel> SearchPatientInList(PatientSearchModel patient);
        List<AllPatientModel> ViewPatientFiles(Int32 patientId); 
        List<PatientModel> GetRegisteredDataById(Int32 patientId); 
        string SaveReRegistration(PatientModel patient);
        string BlockPatient(PatientModel patient); 
        string DeletePatRegFiles(Int32 patient); 
        string UnblockPatient(PatientModel patient); 
    } 
}
