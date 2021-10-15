using LeHealth.Entity.DataModel;
using LeHealth.Entity.ViewModel;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace LeHealth.Service.ServiceInterface
{
    public interface IHospitalsService
    {
        List<HospitalModel> GetUserHospitals();
        List<DepartmentModel> GetDepartments();
        List<ConsultantModel> GetConsultant();
        List<Appointments> GetAppointments();
        List<ConsultationModel> GetConsultation();
    }
}
