using AutoMapper;
using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;

using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace LeHealth.Service.Service
{
    public class ConsultantService : IConsultantService
    {
        private readonly IConsultantManager consultantManager;
        private readonly IFileUploadService fileUploadService;
        public ConsultantService(IConsultantManager _consultantManager, IFileUploadService _fileUploadService)
        {
            consultantManager = _consultantManager;
            fileUploadService = _fileUploadService;
        }
        /// <summary>
        ///Getting Consultation details using ConsultantId, Step two in code execution flow
        /// </summary>
        public List<ConsultationModel> SearchConsultationById(ConsultationModel consultation)
        {
            return consultantManager.SearchConsultationById(consultation);
        }
        public List<SearchAppointmentModel> SearchAppointmentByConsultantId(SearchAppointmentModel appointment)
        {
            return consultantManager.SearchAppointmentByConsultantId(appointment);
        }
        public List<ConsultantPatientModel> SearchPatientByConsultantId(PatientSearchModel patient)
        {
            return consultantManager.SearchPatientByConsultantId(patient);
        }
        public string InsertUpdateConsultant(ConsultantMasterModel consultant)
        {
            return consultantManager.InsertUpdateConsultant(consultant);
        }
        public List<ConsultantMasterModel> GetAllConsultants(int consultantType)
        {
            return consultantManager.GetAllConsultants(consultantType);
        }
        public string InsertConsultantService(ConsultantServiceModel consultant)
        {
            return consultantManager.InsertConsultantService(consultant);
        }
        public string DeleteConsultantService(int serviceId)
        {
            return consultantManager.DeleteConsultantService(serviceId);
        }
        public List<ConsultantServiceModel> GetConsultantServices(int consultantId)
        {
            return consultantManager.GetConsultantServices(consultantId);
        }
        public string InsertConsultantDrugs(ConsultantDrugModel consultantDrug)
        {
            return consultantManager.InsertConsultantDrugs(consultantDrug);
        }
        public string UpdateConsultantDrugs(ConsultantDrugModel consultantDrug)
        {
            return consultantManager.UpdateConsultantDrugs(consultantDrug);
        }
        public List<ConsultantDrugModel> GetConsultantDrugs(int consultantId)
        {
            return consultantManager.GetConsultantDrugs(consultantId);
        }
        public string DeleteConsultantDrug(int drugId)
        {
            return consultantManager.DeleteConsultantDrug(drugId);
        }
        public string InsertConsultantDiseases(DiseaseModel disease)
        {
            return consultantManager.InsertConsultantDiseases(disease);
        }
        public List<DiseaseSymptomModel> GetDiseaseSymptoms(int diseaseId)
        {
            return consultantManager.GetDiseaseSymptoms(diseaseId);
        }
        public List<DiseaseSignModel> GetDiseaseVitalSigns(int diseaseId)
        {
            return consultantManager.GetDiseaseVitalSigns(diseaseId);
        }
        public List<DiseaseICDModel> GetDiseaseICD(int diseaseId)
        {
            return consultantManager.GetDiseaseICD(diseaseId);
        }
        public string DeleteDiseaseICD(int diseaseId)
        {
            return consultantManager.DeleteDiseaseICD(diseaseId);
        }
        public string DeleteDiseaseSymptom(int diseaseId)
        {
            return consultantManager.DeleteDiseaseSymptom(diseaseId);
        }
        public string DeleteDiseaseSign(int diseaseId)
        {
            return consultantManager.DeleteDiseaseSign(diseaseId);
        }
        public string BlockDisease(DiseaseModel disease)
        {
            return consultantManager.BlockDisease(disease);
        }
        public string UnblockDisease(DiseaseModel disease)
        {
            return consultantManager.UnblockDisease(disease);
        }
        public List<Appointments> GetMyAppointments(AppointmentModel appointment)
        {
            return consultantManager.GetMyAppointments(appointment);
        }
        public List<ConsultationModel> GetMyConsultations(ConsultantModel consultant)
        {
            return consultantManager.GetMyConsultations(consultant);
        }
    }
}
