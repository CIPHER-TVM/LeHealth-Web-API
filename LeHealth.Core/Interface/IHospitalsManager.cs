using LeHealth.Entity.DataModel;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace LeHealth.Core.Interface
{
    public interface IHospitalsManager
    {
        List<ConsultationModel> GetConsultation(ConsultantModel consultation);
        List<TabOrderModel> GetTabOrder(string screenname);
        string InsertAppointment(Appointments appointments);
        string UpdateAppointment(Appointments appointments);
        List<ConsultationModel> GetAllConsultation();
        List<ConsultationModel> SearchConsultation(ConsultationModel consultation);
    }
}
