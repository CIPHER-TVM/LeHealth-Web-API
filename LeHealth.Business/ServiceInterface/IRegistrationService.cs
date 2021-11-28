using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface IRegistrationService
    {
        string InsertPatient(PatientRegModel patientDetail);
        List<GenderModel> GetGender();
        List<SalutationModel> GetSalutation();
        List<KinRelationModel> GetKinRelation();
        List<RateGroupModel> GetRateGroup(int rgroup);
        List<AllPatientModel> GetAllPatient();
        List<MaritalStatusModel> GetMaritalStatus();
        List<CommunicationTypeModel> GetCommunicationType();
        List<AllPatientModel> SearchPatientInList(PatientSearchModel patientList);
        List<PatientModel> GetRegisteredDataById(int patientId); 
        string SaveReRegistration(PatientModel patient);
        string BlockPatient(PatientModel patient); 
        string UnblockPatient(PatientModel patient); 
    } 
}
