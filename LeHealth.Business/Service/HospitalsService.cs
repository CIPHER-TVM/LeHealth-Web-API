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
    public class HospitalsService : IHospitalsService
    {
        private readonly IHospitalsManager hospitalsManager;
        /// <summary>
        /// Initialising hospital manager object
        /// </summary>
        public HospitalsService(IHospitalsManager _hospitalsManager)
        {
            hospitalsManager = _hospitalsManager;
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
        public List<TabOrderModel> GetTabOrder(string screenname)
        {
            return hospitalsManager.GetTabOrder(screenname);
        }
        /// <summary>
        ///adding an appointment detail.Step two in code execution flow
        /// </summary>
        public List<Appointments> InsertUpdateAppointment(Appointments appointments)
        {
            return hospitalsManager.InsertUpdateAppointment(appointments);
        }
        /// <summary>
        ///For Updating appointment data.Step two in code execution flow
        /// </summary>
        public string UpdateAppointment(Appointments appointments)
        {
            return hospitalsManager.UpdateAppointment(appointments);
        }
        /// <summary>
        ///For returning all Consultation data.Step two in code execution flow
        /// </summary>
        public List<ConsultationModel> GetAllConsultation()
        {
            return hospitalsManager.GetAllConsultation();
        }
        /// <summary>
        ///For Consultation searching.Step two in code execution flow
        /// </summary>
        public List<ConsultationModel> SearchConsultation(ConsultationModel consultation)
        {
            return hospitalsManager.SearchConsultation(consultation);
        }
    }
}
