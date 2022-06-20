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
        private readonly IEMRDefaultManager masterdataManager;
        public EMRDefaultService(IEMRDefaultManager _masterdataManager)
        {
            masterdataManager = _masterdataManager;
        }
        public List<ConsultationEMRModel> GetConsultation(ConsultationEMRModelAll emr)
        {
            return masterdataManager.GetConsultation(emr);
        }
        public List<PatientBasicModel> GetBasicPatientDetails(PatientBasicModel emr)
        {
            return masterdataManager.GetBasicPatientDetails(emr);
        }
        public VisitModel InsertVisit(VisitModel visit)
        {
            return masterdataManager.InsertVisit(visit);
        }
        public ComplaintsModel InsertComplaints(ComplaintsModel visit)
        {
            return masterdataManager.InsertComplaints(visit);
        }
        public List<ComplaintsModel> GetChiefComplaints(ComplaintsModel emr)
        {
            return masterdataManager.GetChiefComplaints(emr);
        }
        public PhysicalExaminationModel InsertPhysicalExamination(PhysicalExaminationModel pe)
        {
            return masterdataManager.InsertPhysicalExamination(pe);
        }
        public List<PhysicalExaminationModel> GetPEDetails(PhysicalExaminationModel emr)
        {
            return masterdataManager.GetPEDetails(emr);
        }
        public SymptomReviewModel InsertReviewOfSymptoms(SymptomReviewModel srm)
        {
            return masterdataManager.InsertReviewOfSymptoms(srm);
        }
        public List<SymptomReviewModel> GetReviewOfSymptoms(SymptomReviewModel srm)
        {
            return masterdataManager.GetReviewOfSymptoms(srm); 
        }

        public List<VisitModel> GetVisitDetails(VisitModel visit)
        {
            return masterdataManager.GetVisitDetails(visit);
        }
    }

}
