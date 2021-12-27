using LeHealth.Entity.DataModel;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace LeHealth.Core.Interface
{
    public interface IHospitalsManager
    {   
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
        /// <summary>
        /// update an appointments details
        /// </summary>
        string UpdateAppointment(Appointments appointments);
        /// <summary>
        /// get all consultation details
        /// </summary>
        List<ConsultationModel> GetAllConsultation();
        /// <summary>
        /// search in consultation details
        /// </summary>
        List<ConsultationModel> SearchConsultation(ConsultationModel consultation);
    }
}
