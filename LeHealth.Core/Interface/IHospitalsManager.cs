using LeHealth.Entity.DataModel;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace LeHealth.Core.Interface
{
    public interface IHospitalsManager
    {
        List<HospitalModel> GetUserHospitals();
        List<DepartmentModel> GetDepartments();
        List<ConsultantModel> GetConsultant(int deptId);
        List<Appointments> GetAppointments(AppointmentModel appointment);
        List<ConsultationModel> GetConsultation(ConsultantModel consultation);
        List<Appointments> InsertUpdateAppointment(Appointments appointments);
        List<ConsultationModel> InsertUpdateConsultation(ConsultationModel appointments);


    }
}
