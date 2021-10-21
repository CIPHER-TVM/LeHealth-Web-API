using LeHealth.Entity.DataModel;
//using LeHealth.Entity.ViewModel;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace LeHealth.Service.ServiceInterface
{
    public interface IHospitalsService
    {
        List<HospitalModel> GetUserHospitals();
        List<DepartmentModel> GetDepartments();
        List<ConsultantModel> GetConsultant(int deptId);
        List<Appointments> GetAppointments(AppointmentModel appointment);
        List<ConsultationModel> GetConsultation(ConsultantModel consultation);
        List<Appointments> InsertUpdateAppointment(Appointments appointments);
        List<ConsultationModel> InsertUpdateConsultation(ConsultationModel consultations);
        //List<CountryModel> GetCountry(CountryModel countryDetails);

    }
}
