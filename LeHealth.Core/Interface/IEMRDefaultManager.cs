using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface IEMRDefaultManager
    {
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
        List<VisitModel> GetVisitDetails(VisitModel visit);
    }
}
