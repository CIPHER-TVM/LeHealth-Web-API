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
        public EMRDefaultService(IEMRDefaultManager _emrdataManager)
        {
            emrdataManager = _emrdataManager;
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
        public List<VitalSignEMRAll> GetAllEMRVitalSignByVisitId(VitalSignEMRModel vsem)
        {
            return emrdataManager.GetAllEMRVitalSignByVisitId(vsem);
        }

    }

}
