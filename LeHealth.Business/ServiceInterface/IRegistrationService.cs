using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface IRegistrationService
    {
        List<PatientRegModel> InsertPatient(PatientRegModel patientDetail);
        String UploadPatientDocuments(PatientRegModel patientDetail);
        String ValidateHL7(String nabidh); 
        List<GenderModel> GetGender();
        List<KinRelationModel> GetKinRelation();
        List<AllPatientModel> GetAllPatient();
        List<MaritalStatusModel> GetMaritalStatus();
        List<CommunicationTypeModel> GetCommunicationType();
        List<AllPatientModel> SearchPatientInList(PatientSearchModel patient);
        List<AllPatientModel> ViewPatientFiles(int patientId); 
        List<PatientModel> GetRegisteredDataById(int patientId); 
        String SaveReRegistration(PatientModel patient);
        String BlockPatient(PatientModel patient); 
        String DeletePatRegFiles(int patient); 
        String UnblockPatient(PatientModel patient); 
    } 
}
