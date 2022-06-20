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
        public List<VisitModel> GetVisitDetails(VisitModel visit)
        {
            return masterdataManager.GetVisitDetails(visit);
        }
    }

}
