using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.Service
{
    public class EMRDefaultService : IEMRDefaultService
    {
        private readonly IEMRDefaultManager emrdataManager;
        private readonly IFileUploadService fileUploadService;
        public EMRDefaultService(IEMRDefaultManager _emrdataManager, IFileUploadService _fileUploadService)
        {
            emrdataManager = _emrdataManager;
            fileUploadService = _fileUploadService;
        }
        public List<ConsultationEMRModel> GetConsultation(ConsultationEMRModelAll emr)
        {
            return emrdataManager.GetConsultation(emr);
        }
        public List<PatientBasicModel> GetBasicPatientDetails(PatientBasicModel emr)
        {
            return emrdataManager.GetBasicPatientDetails(emr);
        }
        public VisitModel InsertVisit(VisitModel visit)
        {
            return emrdataManager.InsertVisit(visit);
        }
        public ComplaintsModel InsertComplaints(ComplaintsModel visit)
        {
            return emrdataManager.InsertComplaints(visit);
        }
        public List<ComplaintsModel> GetChiefComplaints(ComplaintsModel emr)
        {
            return emrdataManager.GetChiefComplaints(emr);
        }
        public PhysicalExaminationModel InsertPhysicalExamination(PhysicalExaminationModel pe)
        {
            return emrdataManager.InsertPhysicalExamination(pe);
        }
        public List<PhysicalExaminationModel> GetPEDetails(PhysicalExaminationModel emr)
        {
            return emrdataManager.GetPEDetails(emr);
        }
        public SymptomReviewModel InsertReviewOfSymptoms(SymptomReviewModel srm)
        {
            return emrdataManager.InsertReviewOfSymptoms(srm);
        }
        public List<SymptomReviewModel> GetReviewOfSymptoms(SymptomReviewModel srm)
        {
            return emrdataManager.GetReviewOfSymptoms(srm);
        }
        public MedicalDecisionModel InsertMedicalDecision(MedicalDecisionModel pe)
        {
            return emrdataManager.InsertMedicalDecision(pe);
        }
        public List<MedicalDecisionModel> GetMedicalDecision(MedicalDecisionModel emr)
        {
            return emrdataManager.GetMedicalDecision(emr);
        }
        public PlanAndProcedureModel InsertPlanAndProcedure(PlanAndProcedureModel pe)
        {
            return emrdataManager.InsertPlanAndProcedure(pe);
        }
        public List<PlanAndProcedureModel> GetPlanAndProcedure(PlanAndProcedureModel emr)
        {
            return emrdataManager.GetPlanAndProcedure(emr);
        }
        public List<VisitModel> GetVisitDetails(VisitModel visit)
        {
            return emrdataManager.GetVisitDetails(visit);
        }
        public MenstrualHistoryModel InsertMenstrualHistory(MenstrualHistoryModel pe)
        {
            return emrdataManager.InsertMenstrualHistory(pe);
        }
        public List<MenstrualHistoryModel> GetMenstrualHistory(MenstrualHistoryModel emr)
        {
            return emrdataManager.GetMenstrualHistory(emr);
        }
        public NarrativeDiagnosisICDModel InsertNarrativeDiagnosisICD(NarrativeDiagnosisICDModel ndim)
        {
            return emrdataManager.InsertNarrativeDiagnosisICD(ndim);
        }
        public List<NarrativeDiagnosisICDModel> GetNarrativeDiagnosisICD(NarrativeDiagnosisICDModel ndim)
        {
            return emrdataManager.GetNarrativeDiagnosisICD(ndim);
        }

        public VitalSignEMRModel InsertEMRVitalSign(VitalSignEMRModel vsem)
        {
            return emrdataManager.InsertEMRVitalSign(vsem);
        }
        public List<VitalSignEMRData> GetEMRVitalSign(VitalSignEMRModel vsem)
        {
            return emrdataManager.GetEMRVitalSign(vsem);
        }
        public List<VitalSignEMRHistory> GetEMRVitalSignHistory(VitalSignEMRModel vsem)
        {
            return emrdataManager.GetEMRVitalSignHistory(vsem);
        }
        public List<VitalSignEMRAll> GetAllEMRVitalSignByVisitId(VitalSignEMRModel vsem)
        {
            return emrdataManager.GetAllEMRVitalSignByVisitId(vsem);
        }
        public List<DrugModelAutoComplete> GetDrugsAutoComplete(DrugModelAutoComplete dmac)
        {
            return emrdataManager.GetDrugsAutoComplete(dmac);
        }
        public DrugsEMRModel InsertDrugsEMR(DrugsEMRModel vsem)
        {
            return emrdataManager.InsertDrugsEMR(vsem);
        }
        public List<DrugsEMRModel> GetDrugsEMR(DrugsEMRModel dmac)
        {
            return emrdataManager.GetDrugsEMR(dmac);
        }
        public PatientHistoryEMRModel InsertUpdatePatientHistoryEMR(PatientHistoryEMRModel vsem)
        {
            return emrdataManager.InsertUpdatePatientHistoryEMR(vsem);
        }
        public PatientHistoryEMRModel GetPatientHistoryEMR(PatientHistoryEMRModel dmac)
        {
            return emrdataManager.GetPatientHistoryEMR(dmac);
        }
        public PatientQuestionareModelInput InsertUpdatePatientQuestionareEMR(PatientQuestionareModelInput vsem)
        {
            return emrdataManager.InsertUpdatePatientQuestionareEMR(vsem);
        }
        public List<PatientQuestionareModel> GetPatientQuestionareEMR(PatientQuestionareModel dmac)
        {
            return emrdataManager.GetPatientQuestionareEMR(dmac);
        }
        public List<PatientFoldersEMRModel> GetPatientFoldersEMR(EMRInputModel dmac)
        {
            return emrdataManager.GetPatientFoldersEMR(dmac);
        }
        public PatientFoldersEMRModel InsertUpdateFolderEMR(EMRInputModel vsem)
        {
            return emrdataManager.InsertUpdateFolderEMR(vsem);
        }
        public EMRSaveFilesModel UploadFileEMR(EMRSaveFilesModel vsem)
        {

            if (vsem.EMRFiles != null)
                vsem.FolderLocation = fileUploadService.SaveEMRFileMultiple(vsem.EMRFiles, vsem.PatientId);
            //if (patientDetail.PatientPhoto != null)
            //{
            //    patientDetail.PatientPhotoName = fileUploadService.SaveFile(patientDetail.PatientPhoto, "documents");
            //}
            //else
            //{
            //    patientDetail.PatientPhotoName = "";
            //}
            return emrdataManager.UploadFileEMR(vsem);
        }
        public List<ItemEMR> GetEMRServiceItem(EMRInputModel dmac)
        {
            return emrdataManager.GetEMRServiceItem(dmac);
        }
        public ItemEMRInputModel InsertServiceItemsEMR(ItemEMRInputModel vsem)
        {
            return emrdataManager.InsertServiceItemsEMR(vsem);
        }
        public List<ItemEMRInputModel> GetServiceItemsEMR(EMRInputModel dmac)
        {
            return emrdataManager.GetServiceItemsEMR(dmac);
        }
        public DentalExaminationModel InsertDentalExamination(DentalExaminationModel vsem)
        {
            return emrdataManager.InsertDentalExamination(vsem);
        }
        public List<DentalExaminationModel> GetDentalExaminationEMR(EMRInputModel dmac)
        {
            return emrdataManager.GetDentalExaminationEMR(dmac);
        }
        public DentalProcedureEMRModel InsertDentalProcedureEMR(DentalProcedureEMRModel vsem)
        {
            return emrdataManager.InsertDentalProcedureEMR(vsem);
        }
        public List<DentalProcedureEMRModel> GetDentalProcedureEMR(EMRInputModel dmac)
        {
            return emrdataManager.GetDentalProcedureEMR(dmac);
        }
    }
}
