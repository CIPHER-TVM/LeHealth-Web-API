using LeHealth.Core.DataManager;
using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface IEMRDefaultService
    {
        List<ConsultationEMRModel> GetConsultation(ConsultationEMRModelAll schedule);
        List<PatientBasicModel> GetBasicPatientDetails(PatientBasicModel schedule);
        VisitModel InsertVisit(VisitModel visit);
        ComplaintsModel InsertComplaints(ComplaintsModel complaints);
        List<ComplaintsModel> GetChiefComplaints(ComplaintsModel schedule);
        PhysicalExaminationModel InsertPhysicalExamination(PhysicalExaminationModel pe);
        List<PhysicalExaminationModel> GetPEDetails(PhysicalExaminationModel schedule);
        SymptomReviewModel InsertReviewOfSymptoms(SymptomReviewModel srm);
        List<SymptomReviewModel> GetReviewOfSymptoms(SymptomReviewModel srm);

        MedicalDecisionModel InsertMedicalDecision(MedicalDecisionModel srm);
        List<MedicalDecisionModel> GetMedicalDecision(MedicalDecisionModel srm);

        PlanAndProcedureModel InsertPlanAndProcedure(PlanAndProcedureModel srm);
        List<PlanAndProcedureModel> GetPlanAndProcedure(PlanAndProcedureModel srm);
        List<VisitModel> GetVisitDetails(VisitModel visit);
        MenstrualHistoryModel InsertMenstrualHistory(MenstrualHistoryModel mh);
        List<MenstrualHistoryModel> GetMenstrualHistory(MenstrualHistoryModel mh);
        NarrativeDiagnosisICDModel InsertNarrativeDiagnosisICD(NarrativeDiagnosisICDModel ndim);
        List<NarrativeDiagnosisICDModel> GetNarrativeDiagnosisICD(NarrativeDiagnosisICDModel ndim);
        VitalSignEMRModel InsertEMRVitalSign(VitalSignEMRModel vsem);
        List<VitalSignEMRHistory> GetEMRVitalSignHistory(VitalSignEMRModel vsem);
        List<VitalSignEMRData> GetEMRVitalSign(VitalSignEMRModel vsem);
        List<VitalSignEMRAll> GetAllEMRVitalSignByVisitId(VitalSignEMRModel vsem);
        List<DrugModelAutoComplete> GetDrugsAutoComplete(DrugModelAutoComplete dma);
        DrugsEMRModel InsertDrugsEMR(DrugsEMRModel dem);
        List<DrugsEMRModel> GetDrugsEMR(DrugsEMRModel dac);
        PatientHistoryEMRModel InsertUpdatePatientHistoryEMR(PatientHistoryEMRModel vsem);
        PatientHistoryEMRModel GetPatientHistoryEMR(PatientHistoryEMRModel dac);
        List<PatientQuestionareModel> GetPatientQuestionareEMR(PatientQuestionareModel dac);
        PatientQuestionareModelInput InsertUpdatePatientQuestionareEMR(PatientQuestionareModelInput vsem);
        List<PatientFoldersEMRModel> GetPatientFoldersEMR(EMRInputModel dac);
        PatientFoldersEMRModel InsertUpdateFolderEMR(EMRInputModel vsem);
        EMRSaveFilesModel UploadFileEMR(EMRSaveFilesModel vsem);
        List<ItemEMR> GetEMRServiceItem(EMRInputModel dac);
        ItemEMRInputModel InsertServiceItemsEMR(ItemEMRInputModel dem);
        List<ItemEMRInputModel> GetServiceItemsEMR(EMRInputModel dac);
        DentalExaminationModel InsertDentalExamination(DentalExaminationModel dem);
        List<DentalExaminationModel> GetDentalExaminationEMR(EMRInputModel dac);
        DentalProcedureEMRModel InsertDentalProcedureEMR(DentalProcedureEMRModel dem);
        List<DentalProcedureEMRModel> GetDentalProcedureEMR(EMRInputModel dac);
        DentalProcedureEMR CompleteDentalProcedureEMR(DentalProcedureEMR dem);
        PhysioAnalysisHistoryModel InsertUpdatePhysioAnalysisHistoryTreatment(PhysioAnalysisHistoryModel dem);
        List<PhysioAnalysisHistoryModel> GetPhysioAnalysisHistoryTreatment(PhysioAnalysisHistoryModel dac);
    }
}
