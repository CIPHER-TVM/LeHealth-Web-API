using LeHealth.Entity.DataModel;
//using LeHealth.Entity.ViewModel;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace LeHealth.Service.ServiceInterface
{
    public interface IHospitalsService
    {
        
        List<ConsultationModel> GetConsultation(ConsultantModel consultant);
        List<ConsultationModel> GetAllConsultation();
        List<ConsultationModel> SearchConsultation(ConsultationModel consultation);
        List<TabOrderModel> GetTabOrder(String formname);
        String InsertAppointment(Appointments appointments);
        String UpdateAppointment(Appointments appointments);
    }
}
