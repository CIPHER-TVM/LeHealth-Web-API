using AutoMapper;
using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;

using LeHealth.Service.ServiceInterface;
using Microsoft.Extensions.Configuration;
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
        private readonly string _uploadpath;
        public ConsultantService(IConsultantManager _consultantManager, IConfiguration _configuration, IFileUploadService _fileUploadService)
        {
            consultantManager = _consultantManager;
            fileUploadService = _fileUploadService;
            _uploadpath = _configuration["UploadPathConfig:UplodPath"].ToString();
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
        public string InsertUpdateConsultant(ConsultantRegModel consultant)
        {
            if (consultant.PhotoFile != null)
            {
                consultant.SignatureLoc = fileUploadService.SaveFile(consultant.PhotoFile, "documents");
            }
            else if (consultant.SignatureLoc != "" && consultant.SignatureLoc != null)
            {
                consultant.SignatureLoc = consultant.SignatureLoc.Replace(_uploadpath, "");
            }
            else
            {
                consultant.SignatureLoc = "";
            }
            return consultantManager.InsertUpdateConsultant(consultant);
        }
        public string InsertUpdateConsultantUser(ConsultantMasterModel consultant)
        {
            return consultantManager.InsertUpdateConsultantUser(consultant); 
        }
        public List<ConsultantMasterModel> GetAllConsultants(ConsultantMasterModel consultant)
        {
            return consultantManager.GetAllConsultants(consultant);
        }
        public string InsertConsultantService(ConsultantServiceModel consultant)
        {
            return consultantManager.InsertConsultantService(consultant);
        }
        public string DeleteConsultantService(ConsultantItemModel ci)
        {
            return consultantManager.DeleteConsultantService(ci);
        }
        public List<ConsultantServiceModel> GetConsultantServices(int consultantId)
        {
            return consultantManager.GetConsultantServices(consultantId);
        }
        public string InsertConsultantDrugs(ConsultantDrugsModel consultantDrugs)
        {
            return consultantManager.InsertConsultantDrugs(consultantDrugs);
        }
        public string UpdateConsultantDrugs(ConsultantDrugModel consultantDrug)
        {
            return consultantManager.UpdateConsultantDrugs(consultantDrug);
        }
        public List<ConsultantDrugModel> GetConsultantDrugs(ConsultantDrugModel consultant)
        {
            return consultantManager.GetConsultantDrugs(consultant);
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
        public List<DiseaseSignModel> GetDiseaseSigns(int diseaseId)
        {
            return consultantManager.GetDiseaseSigns(diseaseId);
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
        public string InsertUpdateSchedule(ScheduleModel schedule)
        {
            return consultantManager.InsertUpdateSchedule(schedule);
        }
        public List<ScheduleModel> GetSchedules(ScheduleModelAll schedule)
        {
            return consultantManager.GetSchedules(schedule);
        }
        public string DeleteSchedule(int scheduleId)
        {
            return consultantManager.DeleteSchedule(scheduleId);
        }
        public string InsertUpdateTimer(TimerModel timer)
        {
            return consultantManager.InsertUpdateTimer(timer);
        }
        public string InsertConsultantItem(ConsultantItemModel timer)
        {
            return consultantManager.InsertConsultantItem(timer);
        }

        public List<AvailableServiceModel> GetServicesOrderLoadByConsultantId(AvailableServiceModel availableService)
        {
            return consultantManager.GetServicesOrderLoadByConsultantId(availableService);
        }
        public List<ConsultantItemModel> GetConsultantServicesItems(AvailableServiceModel availableService)
        {
            return consultantManager.GetConsultantServicesItems(availableService);
        }
        public FrontOfficePBarModel GetFrontOfficeProgressBarsByConsultantId(AppointmentModel appointment)
        {
            return consultantManager.GetFrontOfficeProgressBarsByConsultantId(appointment);
        }
        public FrontOfficeProgressBarModel GetFrontOfficeProgressBarByConsultantId(AppointmentModel appointment)
        {
            return consultantManager.GetFrontOfficeProgressBarByConsultantId(appointment);
        }
        public List<ICDModel> GetICDBySymptomSign(SymptomSignModel ss)
        {
            return consultantManager.GetICDBySymptomSign(ss);
        }


        public DiseaseModel GetDiseaseDetailsById(DiseaseModel diseaseId)
        {
            return consultantManager.GetDiseaseDetailsById(diseaseId);
        }
        public List<DiseaseModel> GetDiseaseByConsultantId(int consultantId)
        {
            return consultantManager.GetDiseaseByConsultantId(consultantId);
        }
        public List<ConsultantDrugModel> GetConsultantDrugsById(ConsultantDrugModel cdm)
        {
            return consultantManager.GetConsultantDrugsById(cdm);
        }
        public List<ItemRateDetailModel> GetConsultantBaseCost(ConsultantBaseCostModelAll cbcm)
        {
            return consultantManager.GetConsultantBaseCost(cbcm);
        } 
        public List<ItemRateDetailModel> GetConsultantBaseCosts(ConsultantBaseCostModelAll cbcm)
        {
            return consultantManager.GetConsultantBaseCosts(cbcm);
        }
        public string InsertUpdateConsultantBaseCost(ConsultantBaseCostModelAll cbcm)
        {
            return consultantManager.InsertUpdateConsultantBaseCost(cbcm);
        }
        public List<ConsultantItemModel> GetConsultantItemByType(ConsultantItemModel cbcm)
        {
            return consultantManager.GetConsultantItemByType(cbcm);
        }


        public string InsertConsultantSketch(SketchModelAll sketch)
        {
            if (sketch.Base64Img != "")
            {
                string[] values = sketch.Base64Img.Split(',');
                sketch.Base64Img = values[1];
                sketch.FileLocation = fileUploadService.SaveBase64Fn(sketch.Base64Img, "sketches");
            }
            return consultantManager.InsertConsultantSketch(sketch);
        }
        public List<SketchModel> GetConsultantSketch(SketchModelAll sketch)
        {
            return consultantManager.GetConsultantSketch(sketch);
        }

        public string InsertUpdateConsultantMarking(ConsultantMarkingModel consultantMarking)
        {
            if (consultantMarking.Base64Img != "")
            {
                consultantMarking.ConsultantMarkingImageLocation = fileUploadService.SaveBase64Fn(consultantMarking.Base64Img, "consultantmarkings");
            }
            return consultantManager.InsertUpdateConsultantMarking(consultantMarking);
        }
        public List<ConsultantMarkingModel> GetConsultantMarkings(ConsultantMarkingModel consultantId)
        {
            return consultantManager.GetConsultantMarkings(consultantId);
        }
        public string DeleteConsultantMarkings(int markId)
        {
            return consultantManager.DeleteConsultantMarkings(markId);
        }
        public List<ConsultantMarkingModel> GetConsultantMarkingsById(int markId)
        {
            return consultantManager.GetConsultantMarkingsById(markId);
        }
        public List<DiseaseSymptomModel> GetDiseaseSymptomsById(int symptomId)
        {
            return consultantManager.GetDiseaseSymptoms(symptomId);
        }
        public List<DiseaseSignModel> GetDiseaseSignsById(int signId)
        {
            return consultantManager.GetDiseaseSigns(signId);
        }
        public List<DiseaseICDModel> GetDiseaseICDById(int icdId)
        {
            return consultantManager.GetDiseaseICD(icdId);
        }
        public string DeleteConsultantDisease(int diseaseId)
        {
            return consultantManager.DeleteConsultantDisease(diseaseId);
        }
        public ConsultantMasterModel GetConsultantById(int consultantId)
        {
            return consultantManager.GetConsultantById(consultantId);
        }
        public string InsertUpdateConsultantTimeSchedule(ConsultantTimeScheduleMaster timeScheduleMaster)
        {
            return consultantManager.InsertUpdateConsultantTimeSchedule(timeScheduleMaster);
        }
        public ConsultantTimeScheduleMaster GetConsultantTimeSchedule(ConsultantTimeScheduleMaster timeScheduleMaster)
        {
            return consultantManager.GetConsultantTimeSchedule(timeScheduleMaster);
        }
        public string DeleteConsultant(int id)
        {
            return consultantManager.DeleteConsultant(id);
        }

    }
}
