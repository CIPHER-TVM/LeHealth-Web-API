using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.Service
{
    public class TodaysPatientService : ITodaysPatientService
    {
        private readonly ITodaysPatientManager todaysPatientManager;
        private readonly IFileUploadService fileUploadService;
        /// <summary>
        /// Initialising todaysPatientManager object
        /// </summary>
        /// <param name="_todaysPatientManager"></param>
        public TodaysPatientService(ITodaysPatientManager _todaysPatientManager, IFileUploadService _fileUploadService)
        {
            todaysPatientManager = _todaysPatientManager;
            fileUploadService = _fileUploadService;
        }

        
        public List<SearchAppointmentModel> GetAllAppointments(AppointmentModel countryDetails)
        {
            return todaysPatientManager.GetAllAppointments(countryDetails);
        }
         public List<SearchAppointmentModel> GetAppointmentById(AppointmentModel countryDetails)
        {
            return todaysPatientManager.GetAppointmentById(countryDetails);
        }


        public List<SearchAppointmentModel> SearchAppointment(AppointmentModel countryDetails)
        {
            return todaysPatientManager.SearchAppointment(countryDetails);
        }



        public List<PatientListModel> SearchPatient(PatientSearchModel patientList)
        {
            return todaysPatientManager.SearchPatient(patientList);
        }
        public List<PatientListModel> GetPatientByRegNo(string regNo)
        {
            return todaysPatientManager.GetPatientByRegNo(regNo);
        }


        public FrontOfficePBarModel GetFrontOfficeProgressBars(string patientList)
        {
            return todaysPatientManager.GetFrontOfficeProgressBars(patientList);
        }


        public List<MandatoryFieldsModel> GetSavingSchemaMandatory(string formname)
        {
            return todaysPatientManager.GetSavingSchemaMandatory(formname);
        }
        public List<SchemeModel> GetSchemeByConsultant(int consultantid)
        {
            return todaysPatientManager.GetSchemeByConsultant(consultantid);
        }
        public List<VisaTypeModel> GetVisaType()
        {
            return todaysPatientManager.GetVisaType();
        }
        public List<GetAppNoModel> GetAppNumber(GetAppNumberIPModel gap)
        {
            return todaysPatientManager.GetAppNumber(gap);
        }
        public List<GetAppTimeModel> GetAppTime(GetAppNumberIPModel gap)
        {
            return todaysPatientManager.GetAppTime(gap);
        }
        //public string SendAddPatientInformation(int patientid)
        //{
        //    return todaysPatientManager.SendAddPatientInformation(patientid);
        //}
        public List<StateModel> GetStateByCountryId(int countryid)
        {
            return todaysPatientManager.GetStateByCountryId(countryid);
        }
        
        public List<SheduleGetDataModel> GetScheduleData(GetScheduleInputModel gsi)
        {
            return todaysPatientManager.GetScheduleData(gsi);
        }
        //
        
        public string DeleteAppointment(AppointmentModel appointment)
        {
            return todaysPatientManager.DeleteAppointment(appointment);
        }
        public string CancelConsultation(ConsultationModel consultation)
        {
            return todaysPatientManager.CancelConsultation(consultation);
        }
        public string PostponeAppointment(Appointments appointments)
        {
            return todaysPatientManager.PostponeAppointment(appointments);
        }


        public string SetUrgentConsultation(ConsultationModel consultation)
        {
            return todaysPatientManager.SetUrgentConsultation(consultation);
        }

        /// <summary>
        /// adding a new consultation details.Step two in code execution flow
        /// </summary>
        public List<ConsultationModel> InsertUpdateConsultation(ConsultationModel consultations)
        {
            return todaysPatientManager.InsertUpdateConsultation(consultations);
        }
        public List<TokenModel> GetNewTokenNumber(ConsultationModel consultations)
        {
            return todaysPatientManager.GetNewTokenNumber(consultations);
        }
        public List<SponsorModel> GetSponsorListByPatientId(int patientId)
        {
            return todaysPatientManager.GetSponsorListByPatientId(patientId);
        }
        public List<RecentConsultationModel> GetRecentConsultationData()
        {
            return todaysPatientManager.GetRecentConsultationData();
        }
        public List<SymptomModel> GetActiveSymptoms()
        {
            return todaysPatientManager.GetActiveSymptoms();
        }
        public List<ConsultRateModel> GetConsultRate(ConsultationModel cm)
        {
            return todaysPatientManager.GetConsultRate(cm);
        }
        /// <summary>
        /// Returns all consultants by dept id as Generic List. Step two in code execution flow
        /// </summary>
        public List<ConsultantModel> GetConsultant(ConsultantByDeptModel cm)
        {
            return todaysPatientManager.GetConsultant(cm);
        }
         public string AppoinmentValidCheck(AppoinmentValidCheckModel cm)
        {
            return todaysPatientManager.AppoinmentValidCheck(cm);
        }


        public List<ConsultationByPatientIdModel> GetConsultationByPatientId(ConsultationModel cm)
        {
            return todaysPatientManager.GetConsultationByPatientId(cm);
        }
        public List<PatRegByPatientIdModel> GetPatRegByPatientId(ConsultationModel cm)
        {
            return todaysPatientManager.GetPatRegByPatientId(cm);
        }
        public List<ConsultRateModel> GetRegSchmAmtOfPatient(ConsultationModel cm)
        {
            return todaysPatientManager.GetRegSchmAmtOfPatient(cm);
        }
        public List<PatientModel> GetPatient(int pid)
        {
            return todaysPatientManager.GetPatient(pid);
        }
        public List<GetNumberModel> GetNumber(string numid)
        {
            return todaysPatientManager.GetNumber(numid);
        }
        public List<GetConsultantItemSchemeRateModel> GetConsultantItemSchemeRate(ConsultantItemSchemeRateIPModel cisr)
        {
            return todaysPatientManager.GetConsultantItemSchemeRate(cisr);
        }
        public List<ItemsByTypeModel> GetItemsByType(ItemsByTypeModel ibt)
        {
            return todaysPatientManager.GetItemsByType(ibt);
        }
    }
}
