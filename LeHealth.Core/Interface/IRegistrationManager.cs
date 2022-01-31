using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface IRegistrationManager
    {
        List<PatientRegModel> InsertPatient(PatientRegModel patientDetail);
        String UploadPatientDocuments(PatientRegModel patientDetail);
        String ValidateHL7(String nabidh);
        List<AllPatientModel> GetAllPatient();
        List<GenderModel> GetGender();
        List<KinRelationModel> GetKinRelation();
        List<MaritalStatusModel> GetMaritalStatus();
        List<CommunicationTypeModel> GetCommunicationType();
        List<AllPatientModel> SearchPatientInList(PatientSearchModel patientList);
        List<AllPatientModel> ViewPatientFiles(int patientId);
        List<PatientModel> GetRegisteredDataById(int patientId);
        String SaveReRegistration(PatientModel patient);
        String BlockPatient(PatientModel patient);
        String DeletePatRegFiles(int Id);
        String UnblockPatient(PatientModel patient);
    }
}
