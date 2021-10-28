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
        /// <summary>
        /// Initialising hospital manager object
        /// </summary>
        public HospitalsService( IHospitalsManager _hospitalsManager)
        {
            hospitalsManager = _hospitalsManager;

        }
        /// <summary>
        ///Returns  all departments from the hospital as Generic List. Step two in code execution flow
        /// </summary>
        public List<DepartmentModel> GetDepartments()
        {
            return hospitalsManager.GetDepartments();
        }
        /// <summary>
        /// Returns all consultants by dept id as Generic List. Step two in code execution flow
        /// </summary>
        public List<ConsultantModel> GetConsultant(int deptId)
        {
            return hospitalsManager.GetConsultant(deptId);
        }
        /// <summary>
        /// Returns list of all appointments on present day as Generic List. Step two in code execution flow
        /// </summary>
        public List<Appointments> GetAppointments(AppointmentModel appointment)
        {
            return hospitalsManager.GetAppointments(appointment);
        }
        /// <summary>
        /// Returns Consultation Details as Generic List. Step two in code execution flow
        /// </summary>
        public List<ConsultationModel> GetConsultation(ConsultantModel consultation)
        {
            return hospitalsManager.GetConsultation(consultation);
        }
        public List<ConsultationModel> GetAllConsultation()
        {
            return hospitalsManager.GetAllConsultation(); 
        }
        public List<ConsultationModel> SearchConsultation(ConsultationModel consultation)
        {
            return hospitalsManager.SearchConsultation(consultation); 
        }
        public List<TabOrderModel> GetTabOrder(string screenname)
        {
            return hospitalsManager.GetTabOrder(screenname);
        }
        public List<PatientModel> SearchPatient(PatientModel patient)
        {
            return hospitalsManager.SearchPatient(patient); 
        }


        /// <summary>
        ///adding an appointment detail.Step two in code execution flow
        /// </summary>
        public List<Appointments> InsertUpdateAppointment(Appointments appointments)
        {
            return hospitalsManager.InsertUpdateAppointment(appointments);
        }
        /// <summary>
        /// adding a new consultation details.Step two in code execution flow
        /// </summary>
        public List<ConsultationModel> InsertUpdateConsultation(ConsultationModel consultations)
        {
            return hospitalsManager.InsertUpdateConsultation(consultations);
        }
        /// <summary>
        /// To list of all hospital details .Step two in code execution flow
        /// </summary>
        public List<HospitalModel> GetUserHospitals()
        {
            return hospitalsManager.GetUserHospitals();
        }

       
    }
}
