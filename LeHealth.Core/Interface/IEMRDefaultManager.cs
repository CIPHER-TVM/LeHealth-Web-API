using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface IEMRDefaultManager
    {
        List<ConsultationEMRModel> GetConsultation(ConsultationEMRModelAll schedule);
        List<PatientBasicModel> GetBasicPatientDetails(PatientBasicModel schedule);
        //VisitModel InsertVisit(VisitModel visit);
    }
}
