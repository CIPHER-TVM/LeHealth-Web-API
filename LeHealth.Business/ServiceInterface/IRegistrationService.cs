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
        string ValidateHL7(string nabidh); 
        List<GenderModel> GetGender();
        List<KinRelationModel> GetKinRelation();
        List<AllPatientModel> GetAllPatient();
        List<MaritalStatusModel> GetMaritalStatus();
        List<CommunicationTypeModel> GetCommunicationType();
        List<AllPatientModel> SearchPatientInList(PatientSearchModel patient);
        List<AllPatientModel> ViewPatientFiles(Int32 patientId); 
        List<PatientModel> GetRegisteredDataById(Int32 patientId); 
        string SaveReRegistration(PatientModel patient);
        string BlockPatient(PatientModel patient); 
        string DeletePatRegFiles(Int32 patient); 
        string UnblockPatient(PatientModel patient); 
    } 
}
