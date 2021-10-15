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
        private readonly IMapper mapper;

        public HospitalsService(IMapper _mapper, IHospitalsManager _hospitalsManager)
        {
            mapper = _mapper;
            hospitalsManager = _hospitalsManager;

        }
        public List<DepartmentModel> GetDepartments()
        {
            return hospitalsManager.GetDepartments();
        }
        public List<ConsultantModel> GetConsultant()
        {
            return hospitalsManager.GetConsultant();
        }
        public List<Appointments> GetAppointments()
        {
            return hospitalsManager.GetAppointments();
        }
        public List<ConsultationModel> GetConsultation()
        {
            return hospitalsManager.GetConsultation();
        }

        public List<HospitalModel> GetUserHospitals()
        {
            return hospitalsManager.GetUserHospitals();
        }
       
    }
}
