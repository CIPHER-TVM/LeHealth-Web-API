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
        List<VisitModel> GetVisitDetails(VisitModel visit);
    }
}
