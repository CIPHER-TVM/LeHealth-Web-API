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
        public List<PatientListModel> SearchPatientByConsultantId(PatientSearchModel patient)
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
        public List<ConsultantDrugModel> GetConsultantDrugs(int consultantId)
        {
            return consultantManager.GetConsultantDrugs(consultantId);
        }
        public string DeleteConsultantDrug(int drugId)
        {
            return consultantManager.DeleteConsultantDrug(drugId);
        }
        public string UpdateConsultantDrugs(ConsultantDrugModel consultantDrug)
        {
            return consultantManager.UpdateConsultantDrugs(consultantDrug);
        }
        
        public string InsertConsultantDiseases(DiseaseModel disease)
        {
            return consultantManager.InsertConsultantDiseases(disease);
        }
    }
}
