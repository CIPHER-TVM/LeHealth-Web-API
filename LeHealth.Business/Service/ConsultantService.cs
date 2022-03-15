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
        public List<ConsultationModel> SearchConsultationById(int consultantId)
        {
            return consultantManager.SearchConsultationById(consultantId);
        }
        public List<SearchAppointmentModel> SearchAppointmentByConsultantId(int consultantId)
        {
            return consultantManager.SearchAppointmentByConsultantId(consultantId);
        }
        public List<PatientListModel> SearchPatientByConsultantId(int consultantId)
        {
            return consultantManager.SearchPatientByConsultantId(consultantId);
        }
        public string InsertUpdateConsultant(ConsultantMasterModel consultant)
        {
            return consultantManager.InsertUpdateConsultant(consultant);
        }
        public List<ConsultantMasterModel> GetAllConsultants(int consultantType)
        {
            return consultantManager.GetAllConsultants(consultantType);
        }
    }
}
