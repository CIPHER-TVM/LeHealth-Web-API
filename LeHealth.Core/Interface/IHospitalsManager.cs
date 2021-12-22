using LeHealth.Entity.DataModel;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace LeHealth.Core.Interface
{
    public interface IHospitalsManager
    {     
        /// <summary>
        /// To list of all hospital details
        /// </summary>
        
        /// <summary>
        /// To list of  all appointments by today
        /// </summary>
        List<Appointments> GetAppointments(AppointmentModel appointment);
        /// <summary>
        /// To list of  all Consultation by today
        /// </summary>
        List<ConsultationModel> GetConsultation(ConsultantModel consultation);
        List<TabOrderModel> GetTabOrder(string screenname);   
        /// <summary>
        /// adding a new appointments details
        /// </summary>
        List<Appointments> InsertUpdateAppointment(Appointments appointments);
        string UpdateAppointment(Appointments appointments);
     
        List<ConsultationModel> GetAllConsultation();
        List<ConsultationModel> SearchConsultation(ConsultationModel consultation);

    }
}
