using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.Service
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationManager registrationManager;
        private readonly IFileUploadService fileUploadService;
        public RegistrationService(IRegistrationManager _registrationManager, IFileUploadService _fileUploadService)
        {
            registrationManager = _registrationManager;
            fileUploadService = _fileUploadService;
        }
        /// <summary>
        /// adding a new patient registration 
        /// </summary>
        public string InsertPatient(PatientRegModel patientDetail)
        {
            if (patientDetail.PatientDocs != null)
                patientDetail.PatientDocNames = fileUploadService.SaveFileMultiple(patientDetail.PatientDocs);
            if (patientDetail.PatientPhoto != null)
            {
                patientDetail.PatientPhotoName = fileUploadService.SaveFile(patientDetail.PatientPhoto);
            }
            else
            {
                patientDetail.PatientPhotoName = "";
            }
            return registrationManager.InsertPatient(patientDetail);
        }
        

        public List<GenderModel> GetGender()
        {
            return registrationManager.GetGender();
        }
        public List<KinRelationModel> GetKinRelation()
        {
            return registrationManager.GetKinRelation();
        }
        public List<SalutationModel> GetSalutation()
        {
            return registrationManager.GetSalutation();
        }



        public List<RateGroupModel> GetRateGroup(int rgroup)
        {
            return registrationManager.GetRateGroup(rgroup);
        }

        public List<AllPatientModel> GetAllPatient()
        {
            return registrationManager.GetAllPatient();
        }
        public List<MaritalStatusModel> GetMaritalStatus()
        {
            return registrationManager.GetMaritalStatus();
        }
        public List<CommunicationTypeModel> GetCommunicationType()
        {
            return registrationManager.GetCommunicationType();
        }


        public List<AllPatientModel> SearchPatientInList(PatientSearchModel patientList)
        {
            return registrationManager.SearchPatientInList(patientList);
        }
        public List<PatientModel> GetRegisteredDataById(int patientId)
        {
            return registrationManager.GetRegisteredDataById(patientId);
        }

        public string SaveReRegistration(PatientModel patient)
        {
            
            return registrationManager.SaveReRegistration(patient);
        }
        public string BlockPatient(PatientModel patient)
        {
            return registrationManager.BlockPatient(patient);
        }
        public string UnblockPatient(PatientModel patient)
        {
            return registrationManager.UnblockPatient(patient);
        }

    }
}
