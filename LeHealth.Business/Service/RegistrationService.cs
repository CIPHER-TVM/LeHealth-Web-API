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
        public List<PatientRegModel> InsertPatient(PatientRegModel patientDetail)
        {
            if (patientDetail.PatientDocs != null)
                patientDetail.RegDocLocation = fileUploadService.SaveFileMultiple(patientDetail.PatientDocs);
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
        public string UploadPatientDocuments(PatientRegModel patientDetail)
        {
            if (patientDetail.PatientDocs != null)
                patientDetail.RegDocLocation = fileUploadService.SaveFileMultiple(patientDetail.PatientDocs);
            if (patientDetail.PatientPhoto != null)
            {
                patientDetail.PatientPhotoName = fileUploadService.SaveFile(patientDetail.PatientPhoto);
            }
            else
            {
                patientDetail.PatientPhotoName = "";
            }
            return registrationManager.UploadPatientDocuments(patientDetail);
        }
        public List<AllPatientModel> GetAllPatient(int BranchId)
        {
            return registrationManager.GetAllPatient(BranchId);
        }
        public List<AllPatientModel> SearchPatientInList(PatientSearchModel patientList)
        {
            return registrationManager.SearchPatientInList(patientList);
        }
        public List<AllPatientModel> ViewPatientFiles(Int32 patientId)
        {
            return registrationManager.ViewPatientFiles(patientId);
        }
        public List<PatientModel> GetRegisteredDataById(Int32 patientId)
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
        public string DeletePatRegFiles(Int32 Id)
        {
            return registrationManager.DeletePatRegFiles(Id);
        }
        public string UnblockPatient(PatientModel patient)
        {
            return registrationManager.UnblockPatient(patient);
        }
    }
}
