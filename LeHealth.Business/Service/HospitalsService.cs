using AutoMapper;
using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Entity.ViewModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace LeHealth.Service
{
    public class HospitalsService: IHospitalsService
    {
        private readonly IHospitalsManager hospitalsManager;
        //private readonly IMapper mapper;

        public HospitalsService(/*IMapper _mapper,*/ IHospitalsManager _hospitalsManager)
        {
            //mapper = _mapper;
            hospitalsManager = _hospitalsManager;

        }
        public List<DepartmentModel> GetDepartments()
        {
            return hospitalsManager.GetDepartments();
        }
        public List<ConsultantModel> GetConsultant(int deptId)
        {
            return hospitalsManager.GetConsultant(deptId);
        }
        public List<Appointments> GetAppointments(AppointmentModel appointment)
        {
            return hospitalsManager.GetAppointments(appointment);
        }
        public List<ConsultationModel> GetConsultation(ConsultantModel consultation)
        {
            return hospitalsManager.GetConsultation(consultation);
        }
        public List<Appointments> InsertUpdateAppointment(Appointments appointments)
        {
            return hospitalsManager.InsertUpdateAppointment(appointments);
        }
        public List<ConsultationModel> InsertUpdateConsultation(ConsultationModel consultations)
        {
            return hospitalsManager.InsertUpdateConsultation(consultations);
        }
        public List<HospitalModel> GetUserHospitals()
        {
            return hospitalsManager.GetUserHospitals();
        }

       
    }
}
