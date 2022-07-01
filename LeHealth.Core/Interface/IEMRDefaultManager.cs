using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface IEMRDefaultManager
    {
        List<VisitModel> GetVisitDetails(VisitModel visit);
        List<ConsultationEMRModel> GetConsultation(ConsultationEMRModelAll consultation);
        List<PatientBasicModel> GetBasicPatientDetails(PatientBasicModel pbm);
        VisitModel InsertVisit(VisitModel visit);
        ComplaintsModel InsertComplaints(ComplaintsModel complaints);
        List<ComplaintsModel> GetChiefComplaints(ComplaintsModel complaints);
        PhysicalExaminationModel InsertPhysicalExamination(PhysicalExaminationModel pem);
        List<PhysicalExaminationModel> GetPEDetails(PhysicalExaminationModel pem);
        SymptomReviewModel InsertReviewOfSymptoms(SymptomReviewModel srm);
        List<SymptomReviewModel> GetReviewOfSymptoms(SymptomReviewModel srm);
        MedicalDecisionModel InsertMedicalDecision(MedicalDecisionModel srm);
        List<MedicalDecisionModel> GetMedicalDecision(MedicalDecisionModel srm);
        PlanAndProcedureModel InsertPlanAndProcedure(PlanAndProcedureModel srm);
        List<PlanAndProcedureModel> GetPlanAndProcedure(PlanAndProcedureModel srm);
        MenstrualHistoryModel InsertMenstrualHistory(MenstrualHistoryModel mh);
        List<MenstrualHistoryModel> GetMenstrualHistory(MenstrualHistoryModel mh);
        NarrativeDiagnosisICDModel InsertNarrativeDiagnosisICD(NarrativeDiagnosisICDModel ndim);
        List<NarrativeDiagnosisICDModel> GetNarrativeDiagnosisICD(NarrativeDiagnosisICDModel ndim);
        VitalSignEMRModel InsertEMRVitalSign(VitalSignEMRModel vsem);
        List<VitalSignEMRData> GetEMRVitalSign(VitalSignEMRModel vsem);
        List<VitalSignEMRHistory> GetEMRVitalSignHistory(VitalSignEMRModel vsem);
        List<VitalSignEMRAll> GetAllEMRVitalSignByVisitId(VitalSignEMRModel vsem);
        List<DrugModelAutoComplete> GetDrugsAutoComplete(DrugModelAutoComplete dac);
        DrugsEMRModel InsertDrugsEMR(DrugsEMRModel vsem);
        List<DrugsEMRModel> GetDrugsEMR(DrugsEMRModel dac);
        PatientHistoryEMRModel InsertUpdatePatientHistoryEMR(PatientHistoryEMRModel vsem);
        PatientHistoryEMRModel GetPatientHistoryEMR(PatientHistoryEMRModel dac);
        List<PatientQuestionareModel> GetPatientQuestionareEMR(PatientQuestionareModel dac);
        PatientQuestionareModelInput InsertUpdatePatientQuestionareEMR(PatientQuestionareModelInput vsem);
        List<PatientFoldersEMRModel> GetPatientFoldersEMR(EMRInputModel dac);
        PatientFoldersEMRModel InsertUpdateFolderEMR(EMRInputModel vsem);
        EMRSaveFilesModel UploadFileEMR(EMRSaveFilesModel vsem);
    }
}
