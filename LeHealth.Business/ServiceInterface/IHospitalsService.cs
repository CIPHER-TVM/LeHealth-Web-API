﻿using LeHealth.Entity.DataModel;
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
        List<ConsultationModel> GetAllConsultation();
        List<ConsultationModel> SearchConsultation(ConsultationModel consultation);
        List<TabOrderModel> GetTabOrder(string formname); 
        List<Appointments> InsertUpdateAppointment(Appointments appointments);
        
    }
}
