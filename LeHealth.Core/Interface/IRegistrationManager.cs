using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface IRegistrationManager
    {
        string InsertPatient(PatientRegModel patientDetail);
        string ValidateHL7(string nabidh);
        List<RateGroupModel> GetRateGroup(int rgroup);
        List<AllPatientModel> GetAllPatient();
        List<GenderModel> GetGender();
        List<KinRelationModel> GetKinRelation();
        List<SalutationModel> GetSalutation();
        List<MaritalStatusModel> GetMaritalStatus();
        List<CommunicationTypeModel> GetCommunicationType();
        List<AllPatientModel> SearchPatientInList(PatientSearchModel patientList);
        List<AllPatientModel> ViewPatientFiles(int patientId);
        List<PatientModel> GetRegisteredDataById(int patientId);
        string SaveReRegistration(PatientModel patient);
        string BlockPatient(PatientModel patient);
        string DeletePatRegFiles(int Id);
        string UnblockPatient(PatientModel patient);
    }
}
