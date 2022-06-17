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
    }
}
