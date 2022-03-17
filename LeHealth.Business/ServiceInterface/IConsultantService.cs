using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface IConsultantService
    {
        List<ConsultationModel> SearchConsultationById(int consultantId);
        List<SearchAppointmentModel> SearchAppointmentByConsultantId(int consultantId);
        List<PatientListModel> SearchPatientByConsultantId(int consultantId);
        string InsertUpdateConsultant(ConsultantMasterModel consultant);
        List<ConsultantMasterModel> GetAllConsultants(int consultantType);
      
        string InsertConsultantService(ConsultantServiceModel consultant);
        string DeleteConsultantService(int serviceId);
        List<ConsultantServiceModel> GetConsultantServices(int consultantId);

        string InsertConsultantDrugs(ConsultantDrugModel consultantDrug);
        List<ConsultantDrugModel> GetConsultantDrugs(int consultantId);
        string DeleteConsultantDrug(int drugId);

        string UpdateConsultantDrugs(ConsultantDrugModel consultantDrug);
    }
}
