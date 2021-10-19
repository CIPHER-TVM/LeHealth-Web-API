using AutoMapper;
using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
//using LeHealth.Entity.ViewModel;
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

        public HospitalsService( IHospitalsManager _hospitalsManager)
        {
            hospitalsManager = _hospitalsManager;

        }
        /// <summary>
        ///To list of all departments from the hospitals
        /// </summary>
        public List<DepartmentModel> GetDepartments()
        {
            return hospitalsManager.GetDepartments();
        }
        /// <summary>
        /// To list of all consultants by dept id
        /// </summary>
        public List<ConsultantModel> GetConsultant(int deptId)
        {
            return hospitalsManager.GetConsultant(deptId);
        }
        /// <summary>
        /// To list of all appointments by today
        /// </summary>
        public List<Appointments> GetAppointments(AppointmentModel appointment)
        {
            return hospitalsManager.GetAppointments(appointment);
        }
        public List<ConsultationModel> GetConsultation(ConsultantModel consultation)
        {
            return hospitalsManager.GetConsultation(consultation);
        }
        /// <summary>
        ///adding a appointment details
        /// </summary>
        public List<Appointments> InsertUpdateAppointment(Appointments appointments)
        {
            return hospitalsManager.InsertUpdateAppointment(appointments);
        }
        /// <summary>
        /// adding a new consultation details
        /// </summary>
        /// <param name="consultations"></param>
        public List<ConsultationModel> InsertUpdateConsultation(ConsultationModel consultations)
        {
            return hospitalsManager.InsertUpdateConsultation(consultations);
        }
        /// <summary>
        /// To list of all hospital details 
        /// </summary>
        public List<HospitalModel> GetUserHospitals()
        {
            return hospitalsManager.GetUserHospitals();
        }

       
    }
}
