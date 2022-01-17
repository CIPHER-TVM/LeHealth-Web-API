using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface IRegistrationService
    {
        string InsertPatient(PatientRegModel patientDetail);
        string ValidateHL7(string nabidh); 
        List<GenderModel> GetGender();
        List<KinRelationModel> GetKinRelation();
        List<AllPatientModel> GetAllPatient();
        List<MaritalStatusModel> GetMaritalStatus();
        List<CommunicationTypeModel> GetCommunicationType();
        List<AllPatientModel> SearchPatientInList(PatientSearchModel patient);
        List<AllPatientModel> ViewPatientFiles(int patientId); 
        List<PatientModel> GetRegisteredDataById(int patientId); 
        string SaveReRegistration(PatientModel patient);
        string BlockPatient(PatientModel patient); 
        string DeletePatRegFiles(int patient); 
        string UnblockPatient(PatientModel patient); 
    } 
}
